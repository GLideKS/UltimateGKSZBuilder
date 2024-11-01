namespace CodeImp.DoomBuilder.Controls
{
	partial class ThingInfoPanel
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label rolllabel;
			System.Windows.Forms.Label pitchlabel;
			System.Windows.Forms.Label anglelabel;
			System.Windows.Forms.Label taglabel;
			System.Windows.Forms.Label positionlabel;
			System.Windows.Forms.Label typelabel;
			this.labelaction = new System.Windows.Forms.Label();
			this.labelaction.AutoSize = true;
			this.infopanel = new System.Windows.Forms.GroupBox();
			this.anglecontrol = new CodeImp.DoomBuilder.Controls.AngleControlEx();
			this.classname = new System.Windows.Forms.Label();
			this.classname.AutoSize = true;
			this.labelclass = new System.Windows.Forms.Label();
			this.labelclass.AutoSize = true;
			this.arg5 = new System.Windows.Forms.Label();
			this.arg5.AutoSize = true;
			this.arglbl5 = new System.Windows.Forms.Label();
			this.arglbl5.AutoSize = true;
			this.arglbl4 = new System.Windows.Forms.Label();
			this.arglbl4.AutoSize = true;
			this.arg4 = new System.Windows.Forms.Label();
			this.arg4.AutoSize = true;
			this.arglbl3 = new System.Windows.Forms.Label();
			this.arglbl3.AutoSize = true;
			this.arglbl2 = new System.Windows.Forms.Label();
			this.arglbl2.AutoSize = true;
			this.arg3 = new System.Windows.Forms.Label();
			this.arg3.AutoSize = true;
			this.arglbl1 = new System.Windows.Forms.Label();
			this.arglbl1.AutoSize = true;
			this.arg2 = new System.Windows.Forms.Label();
			this.arg2.AutoSize = true;
			this.arg1 = new System.Windows.Forms.Label();
			this.arg1.AutoSize = true;
			this.angle = new System.Windows.Forms.Label();
			this.angle.AutoSize = true;
			this.pitch = new System.Windows.Forms.Label();
			this.pitch.AutoSize = true;
			this.roll = new System.Windows.Forms.Label();
			this.roll.AutoSize = true;
			this.tag = new System.Windows.Forms.Label();
			this.tag.AutoSize = true;
			this.position = new System.Windows.Forms.Label();
			this.position.AutoSize = true;
			this.action = new System.Windows.Forms.Label();
			this.action.AutoSize = true;
			this.type = new System.Windows.Forms.Label();
			this.type.AutoSize = true;
			this.spritepanel = new System.Windows.Forms.GroupBox();
			this.spritename = new System.Windows.Forms.Label();
			this.spritename.AutoSize = true;
			this.panel1 = new System.Windows.Forms.Panel();
			this.spritetex = new CodeImp.DoomBuilder.Controls.ConfigurablePictureBox();
			this.flagsPanel = new System.Windows.Forms.GroupBox();
			this.flags = new CodeImp.DoomBuilder.Controls.TransparentListView();
			rolllabel = new System.Windows.Forms.Label();
			pitchlabel = new System.Windows.Forms.Label();
			anglelabel = new System.Windows.Forms.Label();
			taglabel = new System.Windows.Forms.Label();
			positionlabel = new System.Windows.Forms.Label();
			typelabel = new System.Windows.Forms.Label();
			this.arglbl6 = new System.Windows.Forms.Label();
			this.arglbl7 = new System.Windows.Forms.Label();
			this.arglbl8 = new System.Windows.Forms.Label();
			this.arglbl9 = new System.Windows.Forms.Label();
			this.arglbl10 = new System.Windows.Forms.Label();
			this.arg6 = new System.Windows.Forms.Label();
			this.arg7 = new System.Windows.Forms.Label();
			this.arg8 = new System.Windows.Forms.Label();
			this.arg9 = new System.Windows.Forms.Label();
			this.arg10 = new System.Windows.Forms.Label();
			this.stringarg1 = new System.Windows.Forms.Label();
			this.stringarg2 = new System.Windows.Forms.Label();
			this.stringarglbl1 = new System.Windows.Forms.Label();
			this.stringarglbl2 = new System.Windows.Forms.Label();
			this.infopanel.SuspendLayout();
			this.spritepanel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spritetex)).BeginInit();
			this.flagsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// rolllabel
			// 
			rolllabel.AutoSize = true;
			rolllabel.Location = new System.Drawing.Point(30, 79);
			rolllabel.Name = "rolllabel";
			rolllabel.Size = new System.Drawing.Size(37, 13);
			rolllabel.TabIndex = 8;
			rolllabel.Text = "Roll:";
			// 
			// pitchlabel
			// 
			pitchlabel.AutoSize = true;
			pitchlabel.Location = new System.Drawing.Point(24, 64);
			pitchlabel.Name = "pitchlabel";
			pitchlabel.Size = new System.Drawing.Size(37, 13);
			pitchlabel.TabIndex = 8;
			pitchlabel.Text = "Pitch:";
			// 
			// anglelabel
			// 
			anglelabel.AutoSize = true;
			anglelabel.Location = new System.Drawing.Point(21, 49);
			anglelabel.Name = "anglelabel";
			anglelabel.Size = new System.Drawing.Size(37, 13);
			anglelabel.TabIndex = 8;
			anglelabel.Text = "Angle:";
			// 
			// taglabel
			// 
			taglabel.AutoSize = true;
			taglabel.Location = new System.Drawing.Point(163, 49);
			taglabel.Name = "taglabel";
			taglabel.Size = new System.Drawing.Size(29, 13);
			taglabel.TabIndex = 4;
			taglabel.Text = "Tag:";
			// 
			// positionlabel
			// 
			positionlabel.AutoSize = true;
			positionlabel.Location = new System.Drawing.Point(11, 34);
			positionlabel.Name = "positionlabel";
			positionlabel.Size = new System.Drawing.Size(47, 13);
			positionlabel.TabIndex = 3;
			positionlabel.Text = "Position:";
			// 
			// typelabel
			// 
			typelabel.AutoSize = true;
			typelabel.Location = new System.Drawing.Point(24, 19);
			typelabel.Name = "typelabel";
			typelabel.Size = new System.Drawing.Size(34, 13);
			typelabel.TabIndex = 0;
			typelabel.Text = "Type:";
			// 
			// labelaction
			// 
			this.labelaction.AutoSize = true;
			this.labelaction.Location = new System.Drawing.Point(18, 49);
			this.labelaction.Name = "labelaction";
			this.labelaction.Size = new System.Drawing.Size(40, 13);
			this.labelaction.TabIndex = 2;
			this.labelaction.Text = "Action:";
			this.labelaction.Visible = false;
			// 
			// infopanel
			// 
			this.infopanel.Controls.Add(this.anglecontrol);
			this.infopanel.Controls.Add(this.classname);
			this.infopanel.Controls.Add(this.labelclass);
			this.infopanel.Controls.Add(this.arg5);
			this.infopanel.Controls.Add(this.arglbl5);
			this.infopanel.Controls.Add(this.arglbl4);
			this.infopanel.Controls.Add(this.arg4);
			this.infopanel.Controls.Add(this.arglbl3);
			this.infopanel.Controls.Add(this.arglbl2);
			this.infopanel.Controls.Add(this.arg3);
			this.infopanel.Controls.Add(this.arglbl1);
			this.infopanel.Controls.Add(this.arg2);
			this.infopanel.Controls.Add(this.arg1);
			this.infopanel.Controls.Add(this.angle);
			this.infopanel.Controls.Add(this.pitch);
			this.infopanel.Controls.Add(this.roll);
			this.infopanel.Controls.Add(anglelabel);
			this.infopanel.Controls.Add(pitchlabel);
			this.infopanel.Controls.Add(rolllabel);
			this.infopanel.Controls.Add(this.tag);
			this.infopanel.Controls.Add(this.position);
			this.infopanel.Controls.Add(this.action);
			this.infopanel.Controls.Add(taglabel);
			this.infopanel.Controls.Add(positionlabel);
			this.infopanel.Controls.Add(this.labelaction);
			this.infopanel.Controls.Add(this.type);
			this.infopanel.Controls.Add(typelabel);
			this.infopanel.Controls.Add(this.arglbl6);
			this.infopanel.Controls.Add(this.arglbl7);
			this.infopanel.Controls.Add(this.arglbl8);
			this.infopanel.Controls.Add(this.arglbl9);
			this.infopanel.Controls.Add(this.arglbl10);
			this.infopanel.Controls.Add(this.arg6);
			this.infopanel.Controls.Add(this.arg7);
			this.infopanel.Controls.Add(this.arg8);
			this.infopanel.Controls.Add(this.arg9);
			this.infopanel.Controls.Add(this.arg10);
			this.infopanel.Controls.Add(this.stringarg1);
			this.infopanel.Controls.Add(this.stringarg2);
			this.infopanel.Controls.Add(this.stringarglbl1);
			this.infopanel.Controls.Add(this.stringarglbl2);
			this.infopanel.Location = new System.Drawing.Point(0, 0);
			this.infopanel.Name = "infopanel";
			this.infopanel.Size = new System.Drawing.Size(650, 100);
			this.infopanel.TabIndex = 4;
			this.infopanel.TabStop = false;
			this.infopanel.Text = " Thing ";
			// 
			// anglecontrol
			// 
			this.anglecontrol.Angle = 0;
			this.anglecontrol.AngleOffset = 0;
			this.anglecontrol.Location = new System.Drawing.Point(102, 49);
			this.anglecontrol.Name = "anglecontrol";
			this.anglecontrol.Size = new System.Drawing.Size(48, 48);
			this.anglecontrol.TabIndex = 38;
			// 
			// classname
			// 
			this.classname.AutoEllipsis = true;
			this.classname.Location = new System.Drawing.Point(61, 34);
			this.classname.Name = "classname";
			this.classname.Size = new System.Drawing.Size(210, 14);
			this.classname.TabIndex = 40;
			this.classname.Text = "CrazyFlyingShotgunSpawner";
			this.classname.Visible = false;
			// 
			// labelclass
			// 
			this.labelclass.AutoSize = true;
			this.labelclass.Location = new System.Drawing.Point(23, 34);
			this.labelclass.Name = "labelclass";
			this.labelclass.Size = new System.Drawing.Size(35, 13);
			this.labelclass.TabIndex = 39;
			this.labelclass.Text = "Class:";
			this.labelclass.Visible = false;
			// 
			// arg5
			// 
			this.arg5.AutoEllipsis = true;
			this.arg5.Location = new System.Drawing.Point(352, 69);
			this.arg5.Name = "arg5";
			this.arg5.Size = new System.Drawing.Size(73, 14);
			this.arg5.TabIndex = 37;
			this.arg5.Text = "Arg 1:";
			// 
			// arglbl5
			// 
			this.arglbl5.AutoEllipsis = true;
			this.arglbl5.BackColor = System.Drawing.Color.Transparent;
			this.arglbl5.Location = new System.Drawing.Point(225, 69);
			this.arglbl5.Name = "arglbl5";
			this.arglbl5.Size = new System.Drawing.Size(121, 14);
			this.arglbl5.TabIndex = 32;
			this.arglbl5.Text = "Arg 1:";
			this.arglbl5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl4
			// 
			this.arglbl4.AutoEllipsis = true;
			this.arglbl4.BackColor = System.Drawing.Color.Transparent;
			this.arglbl4.Location = new System.Drawing.Point(225, 54);
			this.arglbl4.Name = "arglbl4";
			this.arglbl4.Size = new System.Drawing.Size(121, 14);
			this.arglbl4.TabIndex = 31;
			this.arglbl4.Text = "Arg 1:";
			this.arglbl4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arg4
			// 
			this.arg4.AutoEllipsis = true;
			this.arg4.Location = new System.Drawing.Point(352, 54);
			this.arg4.Name = "arg4";
			this.arg4.Size = new System.Drawing.Size(73, 14);
			this.arg4.TabIndex = 36;
			this.arg4.Text = "Arg 1:";
			// 
			// arglbl3
			// 
			this.arglbl3.AutoEllipsis = true;
			this.arglbl3.BackColor = System.Drawing.Color.Transparent;
			this.arglbl3.Location = new System.Drawing.Point(225, 39);
			this.arglbl3.Name = "arglbl3";
			this.arglbl3.Size = new System.Drawing.Size(121, 14);
			this.arglbl3.TabIndex = 30;
			this.arglbl3.Text = "Arg 1:";
			this.arglbl3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl2
			// 
			this.arglbl2.AutoEllipsis = true;
			this.arglbl2.BackColor = System.Drawing.Color.Transparent;
			this.arglbl2.Location = new System.Drawing.Point(225, 24);
			this.arglbl2.Name = "arglbl2";
			this.arglbl2.Size = new System.Drawing.Size(121, 14);
			this.arglbl2.TabIndex = 29;
			this.arglbl2.Text = "Arg 1:";
			this.arglbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arg3
			// 
			this.arg3.AutoEllipsis = true;
			this.arg3.Location = new System.Drawing.Point(352, 39);
			this.arg3.Name = "arg3";
			this.arg3.Size = new System.Drawing.Size(73, 14);
			this.arg3.TabIndex = 35;
			this.arg3.Text = "Arg 1:";
			// 
			// arglbl1
			// 
			this.arglbl1.AutoEllipsis = true;
			this.arglbl1.BackColor = System.Drawing.Color.Transparent;
			this.arglbl1.Location = new System.Drawing.Point(225, 9);
			this.arglbl1.Name = "arglbl1";
			this.arglbl1.Size = new System.Drawing.Size(121, 14);
			this.arglbl1.TabIndex = 28;
			this.arglbl1.Text = "Arg 1:";
			this.arglbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arg2
			// 
			this.arg2.AutoEllipsis = true;
			this.arg2.Location = new System.Drawing.Point(352, 24);
			this.arg2.Name = "arg2";
			this.arg2.Size = new System.Drawing.Size(73, 14);
			this.arg2.TabIndex = 34;
			this.arg2.Text = "Arg 1:";
			// 
			// arg1
			// 
			this.arg1.AutoEllipsis = true;
			this.arg1.Location = new System.Drawing.Point(352, 9);
			this.arg1.Name = "arg1";
			this.arg1.Size = new System.Drawing.Size(73, 14);
			this.arg1.TabIndex = 33;
			this.arg1.Text = "Arg 1:";
			// 
			// angle
			// 
			this.angle.AutoSize = true;
			this.angle.Location = new System.Drawing.Point(62, 49);
			this.angle.Name = "angle";
			this.angle.Size = new System.Drawing.Size(25, 13);
			this.angle.TabIndex = 11;
			this.angle.Text = "270";
			// 
			// pitch
			// 
			this.pitch.AutoSize = true;
			this.pitch.Location = new System.Drawing.Point(62, 64);
			this.pitch.Name = "pitch";
			this.pitch.Size = new System.Drawing.Size(25, 13);
			this.pitch.TabIndex = 11;
			this.pitch.Text = "0";
			// 
			// roll
			// 
			this.roll.AutoSize = true;
			this.roll.Location = new System.Drawing.Point(62, 79);
			this.roll.Name = "roll";
			this.roll.Size = new System.Drawing.Size(25, 13);
			this.roll.TabIndex = 11;
			this.roll.Text = "0";
			// 
			// tag
			// 
			this.tag.AutoSize = true;
			this.tag.Location = new System.Drawing.Point(190, 49);
			this.tag.Name = "tag";
			this.tag.Size = new System.Drawing.Size(13, 13);
			this.tag.TabIndex = 7;
			this.tag.Text = "0";
			// 
			// position
			// 
			this.position.AutoSize = true;
			this.position.Location = new System.Drawing.Point(61, 34);
			this.position.Name = "position";
			this.position.Size = new System.Drawing.Size(91, 13);
			this.position.TabIndex = 6;
			this.position.Text = "1024, 1024, 1024";
			// 
			// action
			// 
			this.action.AutoEllipsis = true;
			this.action.Location = new System.Drawing.Point(61, 49);
			this.action.Name = "action";
			this.action.Size = new System.Drawing.Size(210, 14);
			this.action.TabIndex = 5;
			this.action.Text = "0 - Spawn a Blue Poopie and Ammo";
			this.action.Visible = false;
			// 
			// type
			// 
			this.type.AutoSize = true;
			this.type.Location = new System.Drawing.Point(61, 19);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(96, 13);
			this.type.TabIndex = 1;
			this.type.Text = "0 - Big Brown Pimp";
			// 
			// spritepanel
			// 
			this.spritepanel.Controls.Add(this.spritename);
			this.spritepanel.Controls.Add(this.panel1);
			this.spritepanel.Location = new System.Drawing.Point(479, 0);
			this.spritepanel.Name = "spritepanel";
			this.spritepanel.Size = new System.Drawing.Size(86, 100);
			this.spritepanel.TabIndex = 5;
			this.spritepanel.TabStop = false;
			this.spritepanel.Text = " Sprite ";
			// 
			// spritename
			// 
			this.spritename.Location = new System.Drawing.Point(7, 79);
			this.spritename.Name = "spritename";
			this.spritename.Size = new System.Drawing.Size(72, 13);
			this.spritename.TabIndex = 1;
			this.spritename.Text = "BROWNHUG";
			this.spritename.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.spritetex);
			this.panel1.Location = new System.Drawing.Point(12, 14);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(64, 64);
			this.panel1.TabIndex = 0;
			// 
			// spritetex
			// 
			this.spritetex.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
			this.spritetex.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spritetex.Highlighted = false;
			this.spritetex.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			this.spritetex.Location = new System.Drawing.Point(0, 0);
			this.spritetex.Name = "spritetex";
			this.spritetex.PageUnit = System.Drawing.GraphicsUnit.Pixel;
			this.spritetex.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
			this.spritetex.Size = new System.Drawing.Size(60, 60);
			this.spritetex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.spritetex.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
			this.spritetex.TabIndex = 0;
			this.spritetex.TabStop = false;
			// 
			// flagsPanel
			// 
			this.flagsPanel.Controls.Add(this.flags);
			this.flagsPanel.Location = new System.Drawing.Point(571, 0);
			this.flagsPanel.Name = "flagsPanel";
			this.flagsPanel.Size = new System.Drawing.Size(568, 100);
			this.flagsPanel.TabIndex = 6;
			this.flagsPanel.TabStop = false;
			this.flagsPanel.Text = " Flags";
			// 
			// flags
			// 
			this.flags.BackColor = System.Drawing.SystemColors.Control;
			this.flags.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.flags.CheckBoxes = true;
			this.flags.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.flags.Location = new System.Drawing.Point(6, 18);
			this.flags.Name = "flags";
			this.flags.Scrollable = false;
			this.flags.ShowGroups = false;
			this.flags.Size = new System.Drawing.Size(556, 88);
			this.flags.TabIndex = 0;
			this.flags.UseCompatibleStateImageBehavior = false;
			this.flags.View = System.Windows.Forms.View.List;
			// 
			// arglbl6
			// 
			this.arglbl6.AutoEllipsis = true;
			this.arglbl6.BackColor = System.Drawing.Color.Transparent;
			this.arglbl6.Location = new System.Drawing.Point(415, 9);
			this.arglbl6.Name = "arglbl6";
			this.arglbl6.Size = new System.Drawing.Size(121, 14);
			this.arglbl6.TabIndex = 32;
			this.arglbl6.Text = "Arg 1:";
			this.arglbl6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl7
			// 
			this.arglbl7.AutoEllipsis = true;
			this.arglbl7.BackColor = System.Drawing.Color.Transparent;
			this.arglbl7.Location = new System.Drawing.Point(415, 24);
			this.arglbl7.Name = "arglbl7";
			this.arglbl7.Size = new System.Drawing.Size(121, 14);
			this.arglbl7.TabIndex = 32;
			this.arglbl7.Text = "Arg 1:";
			this.arglbl7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl8
			// 
			this.arglbl8.AutoEllipsis = true;
			this.arglbl8.BackColor = System.Drawing.Color.Transparent;
			this.arglbl8.Location = new System.Drawing.Point(415, 39);
			this.arglbl8.Name = "arglbl8";
			this.arglbl8.Size = new System.Drawing.Size(121, 14);
			this.arglbl8.TabIndex = 32;
			this.arglbl8.Text = "Arg 1:";
			this.arglbl8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl9
			// 
			this.arglbl9.AutoEllipsis = true;
			this.arglbl9.BackColor = System.Drawing.Color.Transparent;
			this.arglbl9.Location = new System.Drawing.Point(415, 54);
			this.arglbl9.Name = "arglbl9";
			this.arglbl9.Size = new System.Drawing.Size(121, 14);
			this.arglbl9.TabIndex = 32;
			this.arglbl9.Text = "Arg 1:";
			this.arglbl9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arglbl10
			// 
			this.arglbl10.AutoEllipsis = true;
			this.arglbl10.BackColor = System.Drawing.Color.Transparent;
			this.arglbl10.Location = new System.Drawing.Point(415, 69);
			this.arglbl10.Name = "arglbl10";
			this.arglbl10.Size = new System.Drawing.Size(121, 14);
			this.arglbl10.TabIndex = 32;
			this.arglbl10.Text = "Arg 1:";
			this.arglbl10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// arg6
			// 
			this.arg6.AutoEllipsis = true;
			this.arg6.Location = new System.Drawing.Point(540, 9);
			this.arg6.Name = "arg6";
			this.arg6.Size = new System.Drawing.Size(73, 14);
			this.arg6.TabIndex = 37;
			this.arg6.Text = "Arg 1:";
			// 
			// arg7
			// 
			this.arg7.AutoEllipsis = true;
			this.arg7.Location = new System.Drawing.Point(540, 24);
			this.arg7.Name = "arg7";
			this.arg7.Size = new System.Drawing.Size(73, 14);
			this.arg7.TabIndex = 37;
			this.arg7.Text = "Arg 1:";
			// 
			// arg8
			// 
			this.arg8.AutoEllipsis = true;
			this.arg8.Location = new System.Drawing.Point(540, 39);
			this.arg8.Name = "arg8";
			this.arg8.Size = new System.Drawing.Size(73, 14);
			this.arg8.TabIndex = 37;
			this.arg8.Text = "Arg 1:";
			// 
			// arg9
			// 
			this.arg9.AutoEllipsis = true;
			this.arg9.Location = new System.Drawing.Point(540, 54);
			this.arg9.Name = "arg9";
			this.arg9.Size = new System.Drawing.Size(73, 14);
			this.arg9.TabIndex = 37;
			this.arg9.Text = "Arg 1:";
			// 
			// arg10
			// 
			this.arg10.AutoEllipsis = true;
			this.arg10.Location = new System.Drawing.Point(540, 69);
			this.arg10.Name = "arg10";
			this.arg10.Size = new System.Drawing.Size(73, 14);
			this.arg10.TabIndex = 37;
			this.arg10.Text = "Arg 1:";
			// 
			// stringarg1
			// 
			this.stringarg1.AutoEllipsis = true;
			this.stringarg1.Location = new System.Drawing.Point(352, 84);
			this.stringarg1.Name = "stringarg1";
			this.stringarg1.Size = new System.Drawing.Size(105, 14);
			this.stringarg1.TabIndex = 37;
			this.stringarg1.Text = "String arg. 1:";
			// 
			// stringarg2
			// 
			this.stringarg2.AutoEllipsis = true;
			this.stringarg2.Location = new System.Drawing.Point(540, 84);
			this.stringarg2.Name = "stringarg2";
			this.stringarg2.Size = new System.Drawing.Size(105, 14);
			this.stringarg2.TabIndex = 37;
			this.stringarg2.Text = "String arg. 2:";
			// 
			// stringarglbl1
			// 
			this.stringarglbl1.AutoEllipsis = true;
			this.stringarglbl1.BackColor = System.Drawing.Color.Transparent;
			this.stringarglbl1.Location = new System.Drawing.Point(225, 84);
			this.stringarglbl1.Name = "stringarglbl1";
			this.stringarglbl1.Size = new System.Drawing.Size(121, 14);
			this.stringarglbl1.TabIndex = 37;
			this.stringarglbl1.Text = "String arg. 1:";
			this.stringarglbl1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// stringarglbl2
			// 
			this.stringarglbl2.AutoEllipsis = true;
			this.stringarglbl2.BackColor = System.Drawing.Color.Transparent;
			this.stringarglbl2.Location = new System.Drawing.Point(415, 84);
			this.stringarglbl2.Name = "stringarglbl2";
			this.stringarglbl2.Size = new System.Drawing.Size(121, 14);
			this.stringarglbl2.TabIndex = 37;
			this.stringarglbl2.Text = "String arg. 2:";
			this.stringarglbl2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// ThingInfoPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.flagsPanel);
			this.Controls.Add(this.spritepanel);
			this.Controls.Add(this.infopanel);
			this.MaximumSize = new System.Drawing.Size(10000, 100);
			this.MinimumSize = new System.Drawing.Size(100, 100);
			this.Name = "ThingInfoPanel";
			this.Size = new System.Drawing.Size(1145, 100);
			this.infopanel.ResumeLayout(false);
			this.infopanel.PerformLayout();
			this.spritepanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spritetex)).EndInit();
			this.flagsPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox spritepanel;
		private System.Windows.Forms.Label spritename;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label angle;
		private System.Windows.Forms.Label pitch;
		private System.Windows.Forms.Label roll;
		private System.Windows.Forms.Label taglabel;
		private System.Windows.Forms.Label rolllabel;
		private System.Windows.Forms.Label pitchlabel;
		private System.Windows.Forms.Label tag;
		private System.Windows.Forms.Label position;
		private System.Windows.Forms.Label action;
		private System.Windows.Forms.Label type;
		private System.Windows.Forms.Label arg5;
		private System.Windows.Forms.Label arglbl5;
		private System.Windows.Forms.Label arglbl4;
		private System.Windows.Forms.Label arg4;
		private System.Windows.Forms.Label arglbl3;
		private System.Windows.Forms.Label arglbl2;
		private System.Windows.Forms.Label arg3;
		private System.Windows.Forms.Label arglbl1;
		private System.Windows.Forms.Label arg2;
		private System.Windows.Forms.Label arg1;
		private System.Windows.Forms.Label arglbl6;
		private System.Windows.Forms.Label arglbl7;
		private System.Windows.Forms.Label arglbl8;
		private System.Windows.Forms.Label arglbl9;
		private System.Windows.Forms.Label arglbl10;
		private System.Windows.Forms.Label arg6;
		private System.Windows.Forms.Label arg7;
		private System.Windows.Forms.Label arg8;
		private System.Windows.Forms.Label arg9;
		private System.Windows.Forms.Label arg10;
		private System.Windows.Forms.Label stringarg1;
		private System.Windows.Forms.Label stringarg2;
		private System.Windows.Forms.Label stringarglbl1;
		private System.Windows.Forms.Label stringarglbl2;
		private System.Windows.Forms.GroupBox infopanel;
		private System.Windows.Forms.GroupBox flagsPanel;
		private CodeImp.DoomBuilder.Controls.TransparentListView flags;
		private System.Windows.Forms.Label labelaction;
		private CodeImp.DoomBuilder.Controls.AngleControlEx anglecontrol;
		private ConfigurablePictureBox spritetex;
		private System.Windows.Forms.Label classname;
		private System.Windows.Forms.Label labelclass;

	}
}
