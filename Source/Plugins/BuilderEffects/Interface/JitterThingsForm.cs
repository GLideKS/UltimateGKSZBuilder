#region Namespaces

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CodeImp.DoomBuilder.Map;
using CodeImp.DoomBuilder.VisualModes;
using CodeImp.DoomBuilder.Geometry;
using CodeImp.DoomBuilder.Windows;

#endregion

namespace CodeImp.DoomBuilder.BuilderEffects
{
	public partial class JitterThingsForm : DelayedForm
	{
		#region Variables

		private readonly string editingModeName;
		private readonly List<Thing> selection;
		private readonly List<VisualThing> visualSelection;
		private readonly List<ThingData> thingData;
		private readonly int MaxSafeDistance;
		private readonly int MaxSafeHeightDistance;

		private static bool relativePitch;
		private static bool relativeRoll;
		private static bool allowNegativePitch;
		private static bool allowNegativeRoll;
		private static bool relativeScale;

		private struct ThingData 
		{
			public Vector3D Position;
			public int Angle;
			public int Pitch;
			public int Roll;
			public double Scale;
			public int SectorHeight;
			public int ZOffset;
			public int SafeDistance;
			public int OffsetAngle; //position jitter angle, not Thing angle!
			public float JitterRotation;
			public float JitterPitch;
			public float JitterRoll;
			public double JitterScale;
			public float JitterHeight;
		}

		#endregion

		#region Constructor

		public JitterThingsForm(string editingModeName) 
		{
			this.editingModeName = editingModeName;
			this.HelpRequested += JitterThingsForm_HelpRequested;

			InitializeComponent();

			//have thing height?
			heightJitterAmount.Enabled = General.Map.FormatInterface.HasThingHeight;
			bUpdateHeight.Enabled = General.Map.FormatInterface.HasThingHeight;

			//disable pitch/roll/scale?
			if(!General.Map.UDMF) 
			{
				pitchAmount.Enabled = false;
				rollAmount.Enabled = false;
				bUpdatePitch.Enabled = false;
				bUpdateRoll.Enabled = false;
				scalegroup.Enabled = false;
				cbRelativePitch.Enabled = false;
				cbRelativeRoll.Enabled = false;
				cbNegativePitch.Enabled = false;
				cbNegativeRoll.Enabled = false;
			}

			//get selection
			selection = new List<Thing>();

			if(editingModeName == "BaseVisualMode") 
			{
				visualSelection = ((VisualMode)General.Editing.Mode).GetSelectedVisualThings(false);
				foreach(VisualThing t in visualSelection) selection.Add(t.Thing);
			} 
			else 
			{
				ICollection<Thing> list = General.Map.Map.GetSelectedThings(true);
				foreach(Thing t in list) selection.Add(t);
			}

			//update window header
			this.Text = "Randomize " + selection.Count + (selection.Count > 1 ? " things" : " thing");

			//store intial properties
			thingData = new List<ThingData>();

			foreach(Thing t in selection)
			{
				ThingData d = new ThingData();

				Thing closest = MapSet.NearestThing(General.Map.Map.Things, t);

				if(closest != null)
				{
					d.SafeDistance = (int)Math.Round(Vector2D.Distance(t.Position, closest.Position));
				}
				else
				{
					d.SafeDistance = 512;
				}

				if(d.SafeDistance > 0) d.SafeDistance /= 2;
				if(MaxSafeDistance < d.SafeDistance) MaxSafeDistance = d.SafeDistance;
				d.Position = t.Position;
				d.Angle = t.AngleDoom;
				d.Pitch = t.Pitch;
				d.Roll = t.Roll;
				d.Scale = UniFields.GetFloat(t.Fields, "mobjscale", 1.0);

				if(General.Map.FormatInterface.HasThingHeight) 
				{
					if(t.Sector == null) t.DetermineSector();
					if(t.Sector != null)
					{
						d.SectorHeight = Math.Max(0, t.Sector.CeilHeight - (int)t.Height - t.Sector.FloorHeight);
						if(MaxSafeHeightDistance < d.SectorHeight) MaxSafeHeightDistance = d.SectorHeight;
						d.ZOffset = (int)t.Position.z;
					}
				}

				thingData.Add(d);
			}

			positionJitterAmount.Maximum = MaxSafeDistance;
			heightJitterAmount.Maximum = MaxSafeHeightDistance;

			//create undo
			General.Map.UndoRedo.ClearAllRedos();
			General.Map.UndoRedo.CreateUndo("Randomize " + selection.Count + (selection.Count > 1 ? " things" : " thing"));

			//update controls
			UpdateOffsetAngles();
			UpdateHeights();
			UpdateRotationAngles();
			UpdatePitchAngles();
			UpdateRollAngles();
			UpdateScale();

			//apply settings
			cbRelativeScale.Checked = relativeScale;
			cbRelativePitch.Checked = relativePitch;
			cbRelativeRoll.Checked = relativeRoll;
			cbNegativePitch.Checked = allowNegativePitch;
			cbNegativeRoll.Checked = allowNegativeRoll;
			

			//add event listeners
			cbRelativeScale.CheckedChanged += cbRelativeScale_CheckedChanged;
			cbRelativePitch.CheckedChanged += cbRelativePitch_CheckedChanged;
			cbRelativeRoll.CheckedChanged += cbRelativeRoll_CheckedChanged;
			cbNegativePitch.CheckedChanged += cbNegativePitch_CheckedChanged;
			cbNegativeRoll.CheckedChanged += cbNegativeRoll_CheckedChanged;

			//tricky way to actually store undo information...
			foreach(Thing t in selection) t.Move(t.Position);
		}

		#endregion

		#region Apply logic

		private void ApplyTranslation(int Amount) 
		{
			for(int i = 0; i < selection.Count; i++) 
			{
				int curAmount = Amount > thingData[i].SafeDistance ? thingData[i].SafeDistance : Amount;
				selection[i].Move(new Vector2D(thingData[i].Position.x + (int)(Math.Sin(thingData[i].OffsetAngle) * curAmount), thingData[i].Position.y + (int)(Math.Cos(thingData[i].OffsetAngle) * curAmount)));
				selection[i].DetermineSector();
			}

			UpdateGeometry();
		}

		private void ApplyRotation(int Amount) 
		{
			for(int i = 0; i < selection.Count; i++)
			{
				int newangle = (int)Math.Round(thingData[i].Angle + Amount * thingData[i].JitterRotation);
				if(General.Map.Config.DoomThingRotationAngles) newangle = newangle / 45 * 45;
				selection[i].Rotate(newangle % 360);
			}

			// Update view
			if(editingModeName == "ThingsMode") General.Interface.RedrawDisplay();
		}

		private void ApplyPitch(int Amount) 
		{
			for(int i = 0; i < selection.Count; i++) 
			{
				int p;
				if(cbRelativePitch.Checked) 
				{
					p = (int)((thingData[i].Pitch + Amount * thingData[i].JitterPitch) % 360);
				} 
				else 
				{
					p = (int)((Amount * thingData[i].JitterPitch) % 360);
				}
				
				selection[i].SetPitch(p);
			}

			//update view
			if(editingModeName == "ThingsMode") General.Interface.RedrawDisplay();
		}

		private void ApplyRoll(int Amount) 
		{
			for(int i = 0; i < selection.Count; i++) 
			{
				int r;
				if(cbRelativeRoll.Checked) 
				{
					r = (int)((thingData[i].Roll + Amount * thingData[i].JitterRoll) % 360);
				} 
				else 
				{
					r = (int)((Amount * thingData[i].JitterRoll) % 360);
				}

				selection[i].SetRoll(r);
			}

			//update view
			if(editingModeName == "ThingsMode") General.Interface.RedrawDisplay();
		}

		private void ApplyHeight(int Amount) 
		{
			for(int i = 0; i < selection.Count; i++) 
			{
				if(thingData[i].SectorHeight == 0) continue;
				int curAmount = Math.Min(thingData[i].SectorHeight, Math.Max(0, thingData[i].ZOffset + Amount));
				selection[i].Move(selection[i].Position.x, selection[i].Position.y, curAmount * thingData[i].JitterHeight);
			}

			UpdateGeometry();
		}

		private void ApplyScale() 
		{
			ApplyScale((float)minScale.Value, (float)maxScale.Value);

			//update view
			if(editingModeName == "ThingsMode") General.Interface.RedrawDisplay();
		}

		private void ApplyScale(double min, double max)
		{
			if (min > max) General.Swap(ref min, ref max);

			double diff = max - min;

			for (int i = 0; i < selection.Count; i++)
			{
				double jitter = thingData[i].JitterScale;
				double result;

				if (cbRelativeScale.Checked)
					result = thingData[i].Scale + min + diff * jitter;
				else
					result = min + diff * jitter;

				UniFields.SetFloat(selection[i].Fields, "mobjscale", Math.Round(result, 2));
			}
		}

		#endregion

		#region Update logic

		private void UpdateGeometry() 
		{
			// Update what must be updated
			if(editingModeName == "BaseVisualMode") 
			{
				VisualMode vm = ((VisualMode)General.Editing.Mode);

				for(int i = 0; i < selection.Count; i++)
				{
					visualSelection[i].SetPosition(new Vector3D(selection[i].Position.x, selection[i].Position.y, selection[i].Sector.FloorHeight + selection[i].Position.z));
					visualSelection[i].Update();

					if(vm.VisualSectorExists(visualSelection[i].Thing.Sector))
						vm.GetVisualSector(visualSelection[i].Thing.Sector).UpdateSectorGeometry(true);
				}
			} 
			else 
			{
				//update view
				General.Interface.RedrawDisplay();
			}
		}

		private void UpdateOffsetAngles() 
		{
			for(int i = 0; i < thingData.Count; i++) 
			{
				ThingData td = thingData[i];
				td.OffsetAngle = General.Random(0, 359);
				thingData[i] = td;
			}
		}

		private void UpdateHeights() 
		{
			for(int i = 0; i < thingData.Count; i++) 
			{
				ThingData td = thingData[i];
				td.JitterHeight = (General.Random(0, 100) / 100f);
				thingData[i] = td;
			}
		}

		private void UpdateRotationAngles() 
		{
			for(int i = 0; i < thingData.Count; i++) 
			{
				ThingData td = thingData[i];
				td.JitterRotation = (General.Random(-100, 100) / 100f);
				thingData[i] = td;
			}
		}

		private void UpdatePitchAngles() 
		{
			int min = (cbNegativePitch.Checked ? -100 : 0);
			for(int i = 0; i < thingData.Count; i++) 
			{
				ThingData td = thingData[i];
				td.JitterPitch = (General.Random(min, 100) / 100f);
				thingData[i] = td;
			}
		}

		private void UpdateRollAngles() 
		{
			int min = (cbNegativeRoll.Checked ? -100 : 0);
			for(int i = 0; i < thingData.Count; i++) 
			{
				ThingData td = thingData[i];
				td.JitterRoll = (General.Random(min, 100) / 100f);
				thingData[i] = td;
			}
		}

		private void UpdateScale()
		{
			for (int i = 0; i < thingData.Count; i++)
			{
				ThingData td = thingData[i];
				td.JitterScale = (General.Random(0, 100) / 100f);
				thingData[i] = td;
			}
		}

		#endregion

		#region Events

		private void bApply_Click(object sender, EventArgs e) 
		{
			// Store settings
			relativePitch = cbRelativePitch.Checked;
			relativeRoll = cbRelativeRoll.Checked;
			relativeScale = cbRelativeScale.Checked;
			allowNegativePitch = cbNegativePitch.Checked;
			allowNegativeRoll = cbNegativeRoll.Checked;

			// Update
			foreach(Thing t in selection) t.DetermineSector();

			// Clear selection
			General.Actions.InvokeAction("builder_clearselection");

			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void bCancel_Click(object sender, EventArgs e) 
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void JitterThingsForm_FormClosing(object sender, FormClosingEventArgs e) 
		{
			if(this.DialogResult == DialogResult.Cancel)
				General.Map.UndoRedo.WithdrawUndo(); //undo changes
		}

		private void positionJitterAmount_OnValueChanged(object sender, EventArgs e) 
		{
			ApplyTranslation(positionJitterAmount.Value);
		}

		private void rotationJitterAmount_OnValueChanged(object sender, EventArgs e) 
		{
			ApplyRotation(rotationJitterAmount.Value);
		}

		private void heightJitterAmount_OnValueChanging(object sender, EventArgs e) 
		{
			ApplyHeight(heightJitterAmount.Value);
		}

		private void pitchAmount_OnValueChanging(object sender, EventArgs e) 
		{
			ApplyPitch(pitchAmount.Value);
		}

		private void rollAmount_OnValueChanging(object sender, EventArgs e) 
		{
			ApplyRoll(rollAmount.Value);
		}

		private void minScale_ValueChanged(object sender, EventArgs e) 
		{
			ApplyScale();
		}

		#endregion

		#region Buttons & checkboxes events

		private void bUpdateTranslation_Click(object sender, EventArgs e) 
		{
			UpdateOffsetAngles();
			ApplyTranslation(positionJitterAmount.Value);
		}

		private void bUpdateHeight_Click(object sender, EventArgs e) 
		{
			UpdateHeights();
			ApplyHeight(heightJitterAmount.Value);
		}

		private void bUpdateAngle_Click(object sender, EventArgs e) 
		{
			UpdateRotationAngles();
			ApplyRotation(rotationJitterAmount.Value);
		}

		private void bUpdatePitch_Click(object sender, EventArgs e) 
		{
			UpdatePitchAngles();
			ApplyPitch(pitchAmount.Value);
		}

		private void bUpdateRoll_Click(object sender, EventArgs e) 
		{
			UpdateRollAngles();
			ApplyRoll(rollAmount.Value);
		}

		private void bUpdateScale_Click(object sender, EventArgs e) 
		{
			ApplyScale();
		}

		private void cbRelativePitch_CheckedChanged(object sender, EventArgs e) 
		{
			UpdatePitchAngles();
			ApplyPitch(pitchAmount.Value);
		}

		private void cbRelativeRoll_CheckedChanged(object sender, EventArgs e) 
		{
			UpdateRollAngles();
			ApplyRoll(rollAmount.Value);
		}

		private void cbNegativePitch_CheckedChanged(object sender, EventArgs e) 
		{
			UpdatePitchAngles();
			ApplyPitch(pitchAmount.Value);
		}

		private void cbNegativeRoll_CheckedChanged(object sender, EventArgs e) 
		{
			UpdateRollAngles();
			ApplyRoll(rollAmount.Value);
		}

		private void cbRelativeScale_CheckedChanged(object sender, EventArgs e) 
		{
			ApplyScale();
		}

		#endregion

		//HALP!
		private void JitterThingsForm_HelpRequested(object sender, HelpEventArgs hlpevent) 
		{
			General.ShowHelp("gzdb/features/all_modes/jitter.html");
			hlpevent.Handled = true;
		}
	}
}
