namespace NetPorter
{
	partial class MainForm
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ListenPort = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.DestinationHost = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.DestinationPort = new System.Windows.Forms.NumericUpDown();
			this.MappingPresets = new System.Windows.Forms.CheckedListBox();
			this.AddPreset = new System.Windows.Forms.Button();
			this.RemovePreset = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.PresetName = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.HomepageLinklabel = new System.Windows.Forms.LinkLabel();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize) (this.ListenPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize) (this.DestinationPort)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Mapping presets:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "&Listen port:";
			// 
			// ListenPort
			// 
			this.ListenPort.Enabled = false;
			this.ListenPort.Location = new System.Drawing.Point(101, 45);
			this.ListenPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.ListenPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ListenPort.Name = "ListenPort";
			this.ListenPort.Size = new System.Drawing.Size(71, 20);
			this.ListenPort.TabIndex = 3;
			this.ListenPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.ListenPort.ValueChanged += new System.EventHandler(this.ListenPort_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Destination &host:";
			// 
			// DestinationHost
			// 
			this.DestinationHost.Enabled = false;
			this.DestinationHost.Location = new System.Drawing.Point(101, 71);
			this.DestinationHost.Name = "DestinationHost";
			this.DestinationHost.Size = new System.Drawing.Size(190, 20);
			this.DestinationHost.TabIndex = 5;
			this.DestinationHost.TextChanged += new System.EventHandler(this.DestinationHost_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "&Destination port:";
			// 
			// DestinationPort
			// 
			this.DestinationPort.Enabled = false;
			this.DestinationPort.Location = new System.Drawing.Point(101, 98);
			this.DestinationPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.DestinationPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DestinationPort.Name = "DestinationPort";
			this.DestinationPort.Size = new System.Drawing.Size(71, 20);
			this.DestinationPort.TabIndex = 7;
			this.DestinationPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.DestinationPort.ValueChanged += new System.EventHandler(this.DestinationPort_ValueChanged);
			// 
			// MappingPresets
			// 
			this.MappingPresets.FormattingEnabled = true;
			this.MappingPresets.Location = new System.Drawing.Point(12, 29);
			this.MappingPresets.Name = "MappingPresets";
			this.MappingPresets.Size = new System.Drawing.Size(201, 139);
			this.MappingPresets.TabIndex = 1;
			this.MappingPresets.SelectedIndexChanged += new System.EventHandler(this.MappingPresets_SelectedIndexChanged);
			this.MappingPresets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MappingPresets_ItemCheck);
			// 
			// AddPreset
			// 
			this.AddPreset.Location = new System.Drawing.Point(12, 174);
			this.AddPreset.Name = "AddPreset";
			this.AddPreset.Size = new System.Drawing.Size(75, 23);
			this.AddPreset.TabIndex = 2;
			this.AddPreset.Text = "&Add preset";
			this.AddPreset.UseVisualStyleBackColor = true;
			this.AddPreset.Click += new System.EventHandler(this.AddPreset_Click);
			// 
			// RemovePreset
			// 
			this.RemovePreset.Enabled = false;
			this.RemovePreset.Location = new System.Drawing.Point(93, 174);
			this.RemovePreset.Name = "RemovePreset";
			this.RemovePreset.Size = new System.Drawing.Size(120, 23);
			this.RemovePreset.TabIndex = 3;
			this.RemovePreset.Text = "&Remove this preset";
			this.RemovePreset.UseVisualStyleBackColor = true;
			this.RemovePreset.Click += new System.EventHandler(this.RemovePreset_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "&Name:";
			// 
			// PresetName
			// 
			this.PresetName.Enabled = false;
			this.PresetName.Location = new System.Drawing.Point(101, 19);
			this.PresetName.Name = "PresetName";
			this.PresetName.Size = new System.Drawing.Size(190, 20);
			this.PresetName.TabIndex = 1;
			this.PresetName.TextChanged += new System.EventHandler(this.PresetName_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(6, 129);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(279, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Check the preset in the list to activate the port mapping.";
			// 
			// HomepageLinklabel
			// 
			this.HomepageLinklabel.AutoSize = true;
			this.HomepageLinklabel.Location = new System.Drawing.Point(424, 184);
			this.HomepageLinklabel.Name = "HomepageLinklabel";
			this.HomepageLinklabel.Size = new System.Drawing.Size(95, 13);
			this.HomepageLinklabel.TabIndex = 6;
			this.HomepageLinklabel.TabStop = true;
			this.HomepageLinklabel.Text = "Check for updates";
			this.HomepageLinklabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.HomepageLinklabel.VisitedLinkColor = System.Drawing.Color.Blue;
			this.HomepageLinklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomepageLinklabel_LinkClicked);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(294, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(124, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "© 2005-7 Yves Goergen";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ListenPort);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.PresetName);
			this.groupBox1.Controls.Add(this.DestinationHost);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.DestinationPort);
			this.groupBox1.Location = new System.Drawing.Point(222, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(297, 155);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mapping details:";
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.NotifyIcon.BalloonTipText = "NetPorter is running in the background.\r\nClick on the icon to reactivate it.";
			this.NotifyIcon.BalloonTipTitle = "NetPorter";
			this.NotifyIcon.Icon = ((System.Drawing.Icon) (resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Text = "NetPorter";
			this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 208);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.HomepageLinklabel);
			this.Controls.Add(this.RemovePreset);
			this.Controls.Add(this.AddPreset);
			this.Controls.Add(this.MappingPresets);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "NetPorter";
			this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
			((System.ComponentModel.ISupportInitialize) (this.ListenPort)).EndInit();
			((System.ComponentModel.ISupportInitialize) (this.DestinationPort)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown ListenPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox DestinationHost;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown DestinationPort;
		private System.Windows.Forms.CheckedListBox MappingPresets;
		private System.Windows.Forms.Button AddPreset;
		private System.Windows.Forms.Button RemovePreset;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox PresetName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel HomepageLinklabel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NotifyIcon NotifyIcon;
	}
}

