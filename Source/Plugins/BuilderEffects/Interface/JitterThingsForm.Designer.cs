namespace CodeImp.DoomBuilder.BuilderEffects
{
	partial class JitterThingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.bApply = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.bUpdateTranslation = new System.Windows.Forms.Button();
			this.positionJitterAmount = new IntControl();
			this.bUpdateAngle = new System.Windows.Forms.Button();
			this.rotationJitterAmount = new IntControl();
			this.heightJitterAmount = new IntControl();
			this.bUpdateHeight = new System.Windows.Forms.Button();
			this.pitchAmount = new IntControl();
			this.rollAmount = new IntControl();
			this.bUpdatePitch = new System.Windows.Forms.Button();
			this.bUpdateRoll = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbNegativeRoll = new System.Windows.Forms.CheckBox();
			this.cbNegativePitch = new System.Windows.Forms.CheckBox();
			this.cbRelativeRoll = new System.Windows.Forms.CheckBox();
			this.cbRelativePitch = new System.Windows.Forms.CheckBox();
			this.scalegroup = new System.Windows.Forms.GroupBox();
			this.cbRelativeScale = new System.Windows.Forms.CheckBox();
			this.bUpdateScale = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.maxScale = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.minScale = new System.Windows.Forms.NumericUpDown();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.scalegroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minScale)).BeginInit();
			this.SuspendLayout();
			// 
			// bApply
			// 
			this.bApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bApply.Location = new System.Drawing.Point(115, 346);
			this.bApply.Name = "bApply";
			this.bApply.Size = new System.Drawing.Size(95, 23);
			this.bApply.TabIndex = 0;
			this.bApply.Text = "Apply";
			this.bApply.UseVisualStyleBackColor = true;
			this.bApply.Click += new System.EventHandler(this.bApply_Click);
			// 
			// bCancel
			// 
			this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bCancel.Location = new System.Drawing.Point(216, 346);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// bUpdateTranslation
			// 
			this.bUpdateTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdateTranslation.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdateTranslation.Location = new System.Drawing.Point(246, 18);
			this.bUpdateTranslation.Name = "bUpdateTranslation";
			this.bUpdateTranslation.Size = new System.Drawing.Size(23, 23);
			this.bUpdateTranslation.TabIndex = 5;
			this.bUpdateTranslation.UseVisualStyleBackColor = true;
			this.bUpdateTranslation.Click += new System.EventHandler(this.bUpdateTranslation_Click);
			// 
			// positionJitterAmount
			// 
			this.positionJitterAmount.AllowNegative = false;
			this.positionJitterAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.positionJitterAmount.ExtendedLimits = true;
			this.positionJitterAmount.Label = "Position:";
			this.positionJitterAmount.Location = new System.Drawing.Point(-26, 19);
			this.positionJitterAmount.Maximum = 100;
			this.positionJitterAmount.Minimum = 0;
			this.positionJitterAmount.Name = "positionJitterAmount";
			this.positionJitterAmount.Size = new System.Drawing.Size(266, 22);
			this.positionJitterAmount.TabIndex = 6;
			this.positionJitterAmount.Value = 0;
			this.positionJitterAmount.OnValueChanging += new System.EventHandler(this.positionJitterAmount_OnValueChanged);
			// 
			// bUpdateAngle
			// 
			this.bUpdateAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdateAngle.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdateAngle.Location = new System.Drawing.Point(246, 18);
			this.bUpdateAngle.Name = "bUpdateAngle";
			this.bUpdateAngle.Size = new System.Drawing.Size(23, 23);
			this.bUpdateAngle.TabIndex = 5;
			this.bUpdateAngle.UseVisualStyleBackColor = true;
			this.bUpdateAngle.Click += new System.EventHandler(this.bUpdateAngle_Click);
			// 
			// rotationJitterAmount
			// 
			this.rotationJitterAmount.AllowNegative = false;
			this.rotationJitterAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rotationJitterAmount.ExtendedLimits = false;
			this.rotationJitterAmount.Label = "Angle:";
			this.rotationJitterAmount.Location = new System.Drawing.Point(-26, 19);
			this.rotationJitterAmount.Maximum = 359;
			this.rotationJitterAmount.Minimum = 0;
			this.rotationJitterAmount.Name = "rotationJitterAmount";
			this.rotationJitterAmount.Size = new System.Drawing.Size(266, 22);
			this.rotationJitterAmount.TabIndex = 8;
			this.rotationJitterAmount.Value = 0;
			this.rotationJitterAmount.OnValueChanging += new System.EventHandler(this.rotationJitterAmount_OnValueChanged);
			// 
			// heightJitterAmount
			// 
			this.heightJitterAmount.AllowNegative = false;
			this.heightJitterAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.heightJitterAmount.ExtendedLimits = false;
			this.heightJitterAmount.Label = "Height:";
			this.heightJitterAmount.Location = new System.Drawing.Point(-26, 47);
			this.heightJitterAmount.Maximum = 100;
			this.heightJitterAmount.Minimum = 0;
			this.heightJitterAmount.Name = "heightJitterAmount";
			this.heightJitterAmount.Size = new System.Drawing.Size(266, 22);
			this.heightJitterAmount.TabIndex = 6;
			this.heightJitterAmount.Value = 0;
			this.heightJitterAmount.OnValueChanging += new System.EventHandler(this.heightJitterAmount_OnValueChanging);
			// 
			// bUpdateHeight
			// 
			this.bUpdateHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdateHeight.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdateHeight.Location = new System.Drawing.Point(246, 46);
			this.bUpdateHeight.Name = "bUpdateHeight";
			this.bUpdateHeight.Size = new System.Drawing.Size(23, 23);
			this.bUpdateHeight.TabIndex = 5;
			this.bUpdateHeight.UseVisualStyleBackColor = true;
			this.bUpdateHeight.Click += new System.EventHandler(this.bUpdateHeight_Click);
			// 
			// pitchAmount
			// 
			this.pitchAmount.AllowNegative = false;
			this.pitchAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pitchAmount.ExtendedLimits = false;
			this.pitchAmount.Label = "Pitch:";
			this.pitchAmount.Location = new System.Drawing.Point(-26, 47);
			this.pitchAmount.Maximum = 359;
			this.pitchAmount.Minimum = 0;
			this.pitchAmount.Name = "pitchAmount";
			this.pitchAmount.Size = new System.Drawing.Size(266, 24);
			this.pitchAmount.TabIndex = 13;
			this.pitchAmount.Value = 0;
			this.pitchAmount.OnValueChanging += new System.EventHandler(this.pitchAmount_OnValueChanging);
			// 
			// rollAmount
			// 
			this.rollAmount.AllowNegative = false;
			this.rollAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.rollAmount.ExtendedLimits = false;
			this.rollAmount.Label = "Roll:";
			this.rollAmount.Location = new System.Drawing.Point(-26, 77);
			this.rollAmount.Maximum = 359;
			this.rollAmount.Minimum = 0;
			this.rollAmount.Name = "rollAmount";
			this.rollAmount.Size = new System.Drawing.Size(266, 24);
			this.rollAmount.TabIndex = 14;
			this.rollAmount.Value = 0;
			this.rollAmount.OnValueChanging += new System.EventHandler(this.rollAmount_OnValueChanging);
			// 
			// bUpdatePitch
			// 
			this.bUpdatePitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdatePitch.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdatePitch.Location = new System.Drawing.Point(246, 47);
			this.bUpdatePitch.Name = "bUpdatePitch";
			this.bUpdatePitch.Size = new System.Drawing.Size(23, 23);
			this.bUpdatePitch.TabIndex = 15;
			this.bUpdatePitch.UseVisualStyleBackColor = true;
			this.bUpdatePitch.Click += new System.EventHandler(this.bUpdatePitch_Click);
			// 
			// bUpdateRoll
			// 
			this.bUpdateRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdateRoll.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdateRoll.Location = new System.Drawing.Point(246, 76);
			this.bUpdateRoll.Name = "bUpdateRoll";
			this.bUpdateRoll.Size = new System.Drawing.Size(23, 23);
			this.bUpdateRoll.TabIndex = 16;
			this.bUpdateRoll.UseVisualStyleBackColor = true;
			this.bUpdateRoll.Click += new System.EventHandler(this.bUpdateRoll_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.positionJitterAmount);
			this.groupBox1.Controls.Add(this.bUpdateTranslation);
			this.groupBox1.Controls.Add(this.bUpdateHeight);
			this.groupBox1.Controls.Add(this.heightJitterAmount);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(279, 82);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Position: ";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cbNegativeRoll);
			this.groupBox2.Controls.Add(this.cbNegativePitch);
			this.groupBox2.Controls.Add(this.cbRelativeRoll);
			this.groupBox2.Controls.Add(this.cbRelativePitch);
			this.groupBox2.Controls.Add(this.rotationJitterAmount);
			this.groupBox2.Controls.Add(this.bUpdateAngle);
			this.groupBox2.Controls.Add(this.bUpdateRoll);
			this.groupBox2.Controls.Add(this.pitchAmount);
			this.groupBox2.Controls.Add(this.rollAmount);
			this.groupBox2.Controls.Add(this.bUpdatePitch);
			this.groupBox2.Location = new System.Drawing.Point(12, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(279, 159);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = " Rotation: ";
			// 
			// cbNegativeRoll
			// 
			this.cbNegativeRoll.AutoSize = true;
			this.cbNegativeRoll.Location = new System.Drawing.Point(150, 134);
			this.cbNegativeRoll.Name = "cbNegativeRoll";
			this.cbNegativeRoll.Size = new System.Drawing.Size(105, 17);
			this.cbNegativeRoll.TabIndex = 20;
			this.cbNegativeRoll.Text = "Use negative roll";
			this.toolTip.SetToolTip(this.cbNegativeRoll, "When checked, 50% of the time \r\nnegative roll will be used");
			this.cbNegativeRoll.UseVisualStyleBackColor = true;
			// 
			// cbNegativePitch
			// 
			this.cbNegativePitch.AutoSize = true;
			this.cbNegativePitch.Location = new System.Drawing.Point(150, 110);
			this.cbNegativePitch.Name = "cbNegativePitch";
			this.cbNegativePitch.Size = new System.Drawing.Size(115, 17);
			this.cbNegativePitch.TabIndex = 19;
			this.cbNegativePitch.Text = "Use negative pitch";
			this.toolTip.SetToolTip(this.cbNegativePitch, "When checked, 50% of the time \r\nnegative pitch will be used.");
			this.cbNegativePitch.UseVisualStyleBackColor = true;
			// 
			// cbRelativeRoll
			// 
			this.cbRelativeRoll.AutoSize = true;
			this.cbRelativeRoll.Location = new System.Drawing.Point(9, 134);
			this.cbRelativeRoll.Name = "cbRelativeRoll";
			this.cbRelativeRoll.Size = new System.Drawing.Size(119, 17);
			this.cbRelativeRoll.TabIndex = 18;
			this.cbRelativeRoll.Text = "Relative to initial roll";
			this.cbRelativeRoll.UseVisualStyleBackColor = true;
			// 
			// cbRelativePitch
			// 
			this.cbRelativePitch.AutoSize = true;
			this.cbRelativePitch.Location = new System.Drawing.Point(9, 110);
			this.cbRelativePitch.Name = "cbRelativePitch";
			this.cbRelativePitch.Size = new System.Drawing.Size(129, 17);
			this.cbRelativePitch.TabIndex = 17;
			this.cbRelativePitch.Text = "Relative to initial pitch";
			this.cbRelativePitch.UseVisualStyleBackColor = true;
			// 
			// scalegroup
			// 
			this.scalegroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scalegroup.Controls.Add(this.cbRelativeScale);
			this.scalegroup.Controls.Add(this.bUpdateScale);
			this.scalegroup.Controls.Add(this.label3);
			this.scalegroup.Controls.Add(this.maxScale);
			this.scalegroup.Controls.Add(this.label2);
			this.scalegroup.Controls.Add(this.minScale);
			this.scalegroup.Location = new System.Drawing.Point(12, 265);
			this.scalegroup.Name = "scalegroup";
			this.scalegroup.Size = new System.Drawing.Size(279, 70);
			this.scalegroup.TabIndex = 19;
			this.scalegroup.TabStop = false;
			this.scalegroup.Text = " Scale: ";
			// 
			// cbRelativeScale
			// 
			this.cbRelativeScale.AutoSize = true;
			this.cbRelativeScale.Location = new System.Drawing.Point(9, 48);
			this.cbRelativeScale.Name = "cbRelativeScale";
			this.cbRelativeScale.Size = new System.Drawing.Size(131, 17);
			this.cbRelativeScale.TabIndex = 13;
			this.cbRelativeScale.Text = "Relative to initial scale";
			this.cbRelativeScale.UseVisualStyleBackColor = true;
			// 
			// bUpdateScale
			// 
			this.bUpdateScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUpdateScale.Image = global::CodeImp.DoomBuilder.BuilderEffects.Properties.Resources.Update;
			this.bUpdateScale.Location = new System.Drawing.Point(246, 19);
			this.bUpdateScale.Name = "bUpdateScale";
			this.bUpdateScale.Size = new System.Drawing.Size(23, 23);
			this.bUpdateScale.TabIndex = 17;
			this.bUpdateScale.UseVisualStyleBackColor = true;
			this.bUpdateScale.Click += new System.EventHandler(this.bUpdateScale_Click);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(146, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "max.:";
			// 
			// maxScale
			// 
			this.maxScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.maxScale.DecimalPlaces = 2;
			this.maxScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.maxScale.Location = new System.Drawing.Point(185, 22);
			this.maxScale.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.maxScale.Name = "maxScale";
			this.maxScale.Size = new System.Drawing.Size(55, 20);
			this.maxScale.TabIndex = 3;
			this.maxScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.maxScale.ValueChanged += new System.EventHandler(this.minScale_ValueChanged);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Width min.:";
			// 
			// minScale
			// 
			this.minScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.minScale.DecimalPlaces = 2;
			this.minScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.minScale.Location = new System.Drawing.Point(83, 22);
			this.minScale.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.minScale.Name = "minScale";
			this.minScale.Size = new System.Drawing.Size(55, 20);
			this.minScale.TabIndex = 1;
			this.minScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.minScale.ValueChanged += new System.EventHandler(this.minScale_ValueChanged);
			// 
			// JitterThingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(303, 378);
			this.Controls.Add(this.scalegroup);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bApply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "JitterThingsForm";
			this.Opacity = 0D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Randomize Things!";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JitterThingsForm_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.scalegroup.ResumeLayout(false);
			this.scalegroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minScale)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bApply;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bUpdateTranslation;
		private System.Windows.Forms.Button bUpdateAngle;
		private System.Windows.Forms.Button bUpdateHeight;
		private CodeImp.DoomBuilder.BuilderEffects.IntControl positionJitterAmount;
		private CodeImp.DoomBuilder.BuilderEffects.IntControl rotationJitterAmount;
		private CodeImp.DoomBuilder.BuilderEffects.IntControl heightJitterAmount;
		private CodeImp.DoomBuilder.BuilderEffects.IntControl pitchAmount;
		private CodeImp.DoomBuilder.BuilderEffects.IntControl rollAmount;
		private System.Windows.Forms.Button bUpdatePitch;
		private System.Windows.Forms.Button bUpdateRoll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox scalegroup;
		private System.Windows.Forms.NumericUpDown minScale;
		private System.Windows.Forms.CheckBox cbRelativeScale;
		private System.Windows.Forms.Button bUpdateScale;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown maxScale;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cbRelativeRoll;
		private System.Windows.Forms.CheckBox cbRelativePitch;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox cbNegativeRoll;
		private System.Windows.Forms.CheckBox cbNegativePitch;
	}
}