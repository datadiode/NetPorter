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
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.textBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.DualServerManualLinklabel = new System.Windows.Forms.LinkLabel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.HomepageLinklabel = new System.Windows.Forms.LinkLabel();
			this.Reverse = new System.Windows.Forms.CheckBox();
			this.IPv4 = new System.Windows.Forms.CheckBox();
			this.IPv6 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ListenPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DestinationPort)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
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
			this.label4.TabIndex = 6;
			this.label4.Text = "Destination &host:";
			// 
			// DestinationHost
			// 
			this.DestinationHost.Enabled = false;
			this.DestinationHost.Location = new System.Drawing.Point(101, 71);
			this.DestinationHost.Name = "DestinationHost";
			this.DestinationHost.Size = new System.Drawing.Size(190, 20);
			this.DestinationHost.TabIndex = 7;
			this.DestinationHost.TextChanged += new System.EventHandler(this.DestinationHost_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 100);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 8;
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
			this.DestinationPort.TabIndex = 9;
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
			this.MappingPresets.Location = new System.Drawing.Point(12, 27);
			this.MappingPresets.Name = "MappingPresets";
			this.MappingPresets.Size = new System.Drawing.Size(201, 109);
			this.MappingPresets.TabIndex = 1;
			this.MappingPresets.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MappingPresets_ItemCheck);
			this.MappingPresets.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MappingPresets_MouseMove);
			this.MappingPresets.MouseLeave += new System.EventHandler(this.MappingPresets_MouseLeave);
			this.MappingPresets.SelectedIndexChanged += new System.EventHandler(this.MappingPresets_SelectedIndexChanged);
			// 
			// AddPreset
			// 
			this.AddPreset.Location = new System.Drawing.Point(12, 142);
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
			this.RemovePreset.Location = new System.Drawing.Point(93, 142);
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
			this.label7.TabIndex = 11;
			this.label7.Text = "Check the preset in the list to activate the port mapping.";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(522, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(170, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "© 2005-2021 Yves Goergen et al.";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.IPv6);
			this.groupBox1.Controls.Add(this.IPv4);
			this.groupBox1.Controls.Add(this.Reverse);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ListenPort);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.PresetName);
			this.groupBox1.Controls.Add(this.DestinationHost);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.DestinationPort);
			this.groupBox1.Location = new System.Drawing.Point(219, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(297, 156);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mapping details:";
			// 
			// NotifyIcon
			// 
			this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.NotifyIcon.BalloonTipText = "NetPorter is running in the background.\r\nClick on the icon to reactivate it.";
			this.NotifyIcon.BalloonTipTitle = "NetPorter";
			this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
			this.NotifyIcon.Text = "NetPorter";
			this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(1, 171);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(700, 352);
			this.webBrowser1.TabIndex = 7;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Enabled = false;
			this.radioButton1.Location = new System.Drawing.Point(6, 25);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(56, 17);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Status";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Enabled = false;
			this.radioButton2.Location = new System.Drawing.Point(6, 53);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(92, 17);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "DualServer.ini";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.AutoCompleteBracketsList = new char[] {
		'(',
		')',
		'{',
		'}',
		'[',
		']',
		'\"',
		'\"',
		'\'',
		'\''};
			this.textBox1.AutoScrollMinSize = new System.Drawing.Size(25, 15);
			this.textBox1.BackBrush = null;
			this.textBox1.CharHeight = 15;
			this.textBox1.CharWidth = 7;
			this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.textBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
			this.textBox1.Enabled = false;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F);
			this.textBox1.IsReplaceMode = false;
			this.textBox1.Location = new System.Drawing.Point(1, 171);
			this.textBox1.Name = "textBox1";
			this.textBox1.Paddings = new System.Windows.Forms.Padding(0);
			this.textBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.textBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBox1.ServiceColors")));
			this.textBox1.Size = new System.Drawing.Size(700, 352);
			this.textBox1.TabIndex = 9;
			this.textBox1.TabStop = false;
			this.textBox1.Visible = false;
			this.textBox1.Zoom = 100;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(98, 21);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(69, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.Location = new System.Drawing.Point(98, 50);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Save";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.DualServerManualLinklabel);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Location = new System.Drawing.Point(522, 56);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(173, 109);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// DualServerManualLinklabel
			// 
			this.DualServerManualLinklabel.AutoSize = true;
			this.DualServerManualLinklabel.Location = new System.Drawing.Point(123, 0);
			this.DualServerManualLinklabel.Name = "DualServerManualLinklabel";
			this.DualServerManualLinklabel.Size = new System.Drawing.Size(41, 13);
			this.DualServerManualLinklabel.TabIndex = 7;
			this.DualServerManualLinklabel.TabStop = true;
			this.DualServerManualLinklabel.Text = "Manual";
			this.DualServerManualLinklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DualServerManualLinklabel_LinkClicked);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 0);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(82, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Dual Server";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button4
			// 
			this.button4.Enabled = false;
			this.button4.Location = new System.Drawing.Point(68, 79);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(99, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "Save && Restart";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(6, 79);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(56, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Restart";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// HomepageLinklabel
			// 
			this.HomepageLinklabel.AutoSize = true;
			this.HomepageLinklabel.Location = new System.Drawing.Point(522, 9);
			this.HomepageLinklabel.Name = "HomepageLinklabel";
			this.HomepageLinklabel.Size = new System.Drawing.Size(13, 13);
			this.HomepageLinklabel.TabIndex = 5;
			this.HomepageLinklabel.TabStop = true;
			this.HomepageLinklabel.Text = "v";
			this.HomepageLinklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomepageLinklabel_LinkClicked);
			// 
			// Reverse
			// 
			this.Reverse.AutoSize = true;
			this.Reverse.Location = new System.Drawing.Point(185, 100);
			this.Reverse.Name = "Reverse";
			this.Reverse.Size = new System.Drawing.Size(66, 17);
			this.Reverse.TabIndex = 10;
			this.Reverse.Text = "Re&verse";
			this.Reverse.UseVisualStyleBackColor = true;
			this.Reverse.CheckedChanged += new System.EventHandler(this.Reverse_CheckedChanged);
			// 
			// IPv4
			// 
			this.IPv4.AutoSize = true;
			this.IPv4.Location = new System.Drawing.Point(185, 47);
			this.IPv4.Name = "IPv4";
			this.IPv4.Size = new System.Drawing.Size(48, 17);
			this.IPv4.TabIndex = 4;
			this.IPv4.Text = "IPv&4";
			this.IPv4.UseVisualStyleBackColor = true;
			this.IPv4.CheckedChanged += new System.EventHandler(this.IPv4_CheckedChanged);
			// 
			// IPv6
			// 
			this.IPv6.AutoSize = true;
			this.IPv6.Location = new System.Drawing.Point(239, 47);
			this.IPv6.Name = "IPv6";
			this.IPv6.Size = new System.Drawing.Size(48, 17);
			this.IPv6.TabIndex = 5;
			this.IPv6.Text = "IPv&6";
			this.IPv6.UseVisualStyleBackColor = true;
			this.IPv6.CheckedChanged += new System.EventHandler(this.IPv6_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(701, 522);
			this.Controls.Add(this.HomepageLinklabel);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.RemovePreset);
			this.Controls.Add(this.AddPreset);
			this.Controls.Add(this.MappingPresets);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "NetPorter";
			this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
			this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
			((System.ComponentModel.ISupportInitialize)(this.ListenPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DestinationPort)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private FastColoredTextBoxNS.FastColoredTextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.LinkLabel DualServerManualLinklabel;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox Reverse;
		private System.Windows.Forms.CheckBox IPv4;
		private System.Windows.Forms.CheckBox IPv6;
	}
}

