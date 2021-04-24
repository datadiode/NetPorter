using Org.Mentalis.Proxy.PortMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Unclassified;
using System.Diagnostics;
using System.Reflection;
using FastColoredTextBoxNS;

namespace NetPorter
{
	public partial class MainForm : Form
	{
		bool displayedTrayNote = false;
		Process dualserver = null;

		readonly Regex CommentRegex = new Regex("\\#.*$", RegexOptions.Multiline);
		readonly Regex DisabledRegex = new Regex("\\;.*$", RegexOptions.Multiline);
		readonly Regex SectionRegex = new Regex("^\\[.*\\]", RegexOptions.Multiline);

		public MainForm()
		{
			InitializeComponent();

			labelVersion.Text += ProductVersion;

			textBox1.AutoIndent = false;
			textBox1.TextChanged += text1_OnTextChanged;

			textBox1.ContextMenu = new ContextMenu(new MenuItem[] {
				new MenuItem("SERVICES", textBox1_ContextMenuCommand),
				new MenuItem("LISTEN_ON", textBox1_ContextMenuCommand),
				new MenuItem("LOGGING", textBox1_ContextMenuCommand),
				new MenuItem("DNS_ALLOWED_HOSTS", textBox1_ContextMenuCommand),
				new MenuItem("DOMAIN_NAME", textBox1_ContextMenuCommand),
				new MenuItem("DNS_HOSTS", textBox1_ContextMenuCommand),
				new MenuItem("ALIASES", textBox1_ContextMenuCommand),
				new MenuItem("WILD_HOSTS", textBox1_ContextMenuCommand),
				new MenuItem("MAIL_SERVERS", textBox1_ContextMenuCommand),
				new MenuItem("CONDITIONAL_FORWARDERS", textBox1_ContextMenuCommand),
				new MenuItem("FORWARDING_SERVERS", textBox1_ContextMenuCommand),
				new MenuItem("ZONE_REPLICATION", textBox1_ContextMenuCommand),
				new MenuItem("TIMINGS", textBox1_ContextMenuCommand),
				new MenuItem("HTTP_INTERFACE", textBox1_ContextMenuCommand),
				new MenuItem("RANGE_SET", textBox1_ContextMenuCommand),
				new MenuItem("GLOBAL_OPTIONS", textBox1_ContextMenuCommand),
				});

			WinApi.SHFILEINFO fi;
			WinApi.SHGetFileInfo(Application.ExecutablePath, 0, out fi, (uint) Marshal.SizeOf(typeof(WinApi.SHFILEINFO)), WinApi.SHGFI.Icon);
			Icon = Icon.FromHandle(fi.hIcon);

			LoadConfig();

			StartDualServer();
		}

		void StartDualServer()
		{
			try
			{
				string filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DualServer.exe");
				ProcessStartInfo startInfo = new ProcessStartInfo(filename);
				startInfo.WindowStyle = ProcessWindowStyle.Minimized;
				dualserver = Process.Start(startInfo);
				while (!WinApi.AttachConsole(dualserver.Id))
				{
					Thread.Sleep(100);
				}
				WinApi.SetConsoleTitle("Dual Server");
			}
			catch
			{
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			WinApi.GenerateConsoleCtrlEvent(1, 0);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			webBrowser1.Navigate("http://127.0.0.1:6789");
		}

		private void MainForm_LocationChanged(object sender, EventArgs e)
		{
			var hwndConsole = WinApi.GetConsoleWindow();
			if (WindowState == FormWindowState.Minimized)
			{
				NotifyIcon.Visible = true;
				Visible = false;
				WinApi.ShowWindow(hwndConsole, 0);
				if (!displayedTrayNote)
					NotifyIcon.ShowBalloonTip(5000);
				displayedTrayNote = true;
			}
			else
			{
				WinApi.ShowWindow(hwndConsole, 7);
				Visible = true;
				NotifyIcon.Visible = false;
			}
		}

		private void NotifyIcon_Click(object sender, EventArgs e)
		{
			Visible = true;
			WindowState = FormWindowState.Normal;
		}

		private void MappingPresets_SelectedIndexChanged(object sender, EventArgs e)
		{
			MappingPreset preset = MappingPresets.SelectedItem as MappingPreset;
			if (preset != null)
			{
				PresetName.Text = preset.Name;
				try
				{
					ListenPort.Value = preset.ListenPort;
				}
				catch
				{
					ListenPort.Value = 1;
				}
				DestinationHost.Text = preset.DestinationHost;
				try
				{
					DestinationPort.Value = preset.DestinationPort;
				}
				catch
				{
					DestinationPort.Value = 1;
				}

				PresetName.Enabled = true;
				ListenPort.Enabled = true;
				DestinationHost.Enabled = true;
				DestinationPort.Enabled = true;

				RemovePreset.Enabled = true;
			}
			else
			{
				PresetName.Text = "";
				ListenPort.Value = 1;
				DestinationHost.Text = "";
				DestinationPort.Value = 1;

				PresetName.Enabled = false;
				ListenPort.Enabled = false;
				DestinationHost.Enabled = false;
				DestinationPort.Enabled = false;

				RemovePreset.Enabled = false;
			}
		}

		private void MappingPresets_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			MappingPreset preset = MappingPresets.Items[e.Index] as MappingPreset;
			if (preset == null) return;

			if (e.NewValue == CheckState.Checked)
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					StartPortmap(preset);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message,
						"Error starting the port mapping",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					e.NewValue = e.CurrentValue;
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
			else if (e.NewValue == CheckState.Unchecked)
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					EndPortmap(preset);
				}
				catch
				{
					e.NewValue = e.CurrentValue;
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
			SaveConfig();
		}

		private void PresetName_TextChanged(object sender, EventArgs e)
		{
			MappingPreset preset = MappingPresets.SelectedItem as MappingPreset;
			if (preset == null) return;
			preset.Name = PresetName.Text;
			MappingPresets.Invalidate();
			SaveConfig();
		}

		private void ListenPort_ValueChanged(object sender, EventArgs e)
		{
			MappingPreset preset = MappingPresets.SelectedItem as MappingPreset;
			if (preset == null) return;
			preset.ListenPort = (int) ListenPort.Value;
			SaveConfig();
		}

		private void DestinationHost_TextChanged(object sender, EventArgs e)
		{
			MappingPreset preset = MappingPresets.SelectedItem as MappingPreset;
			if (preset == null) return;
			preset.DestinationHost = DestinationHost.Text;
			SaveConfig();
		}

		private void DestinationPort_ValueChanged(object sender, EventArgs e)
		{
			MappingPreset preset = MappingPresets.SelectedItem as MappingPreset;
			if (preset == null) return;
			preset.DestinationPort = (int) DestinationPort.Value;
			SaveConfig();
		}

		private void AddPreset_Click(object sender, EventArgs e)
		{
			MappingPreset preset = new MappingPreset();
			preset.Name = "New preset";
			int index = MappingPresets.Items.Add(preset, false);
			MappingPresets.SelectedIndex = index;
			PresetName.Focus();
		}

		private void RemovePreset_Click(object sender, EventArgs e)
		{
			int index = MappingPresets.SelectedIndex;
			if (MappingPresets.GetItemChecked(index))
				MappingPresets.SetItemChecked(index, false);
			MappingPresets.Items.Remove(MappingPresets.SelectedItem);
			if (index > MappingPresets.Items.Count - 1)
				index = MappingPresets.Items.Count - 1;
			if (index >= 0)
				MappingPresets.SelectedIndex = index;
			SaveConfig();
		}

		private void StartPortmap(MappingPreset preset)
		{
			IPAddress address = null;
			if (!IPAddress.TryParse(preset.DestinationHost, out address))
			{
				var hostent = Dns.GetHostEntry(preset.DestinationHost);
				address = hostent.AddressList[0];
			}
			preset.Listener = new PortMapListener(IPAddress.Any,
				preset.ListenPort,
				new IPEndPoint(address, preset.DestinationPort));
			preset.Listener.Start();
			preset.Enabled = true;
		}

		private void EndPortmap(MappingPreset preset)
		{
			preset.Listener.Dispose();
			preset.Listener = null;
			preset.Enabled = false;
		}

		private void SaveConfig()
		{
			List<MappingPreset> presets = new List<MappingPreset>();
			foreach (MappingPreset preset in MappingPresets.Items)
			{
				presets.Add(preset);
			}

			string filename = Path.GetDirectoryName(Application.ExecutablePath) +
				Path.DirectorySeparatorChar +
				Path.GetFileNameWithoutExtension(Application.ExecutablePath) +
				".config";
			Stream stream = File.Open(filename, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, presets);
			stream.Close();
		}

		private void LoadConfig()
		{
			List<MappingPreset> presets;

			try
			{
				string filename = Path.GetDirectoryName(Application.ExecutablePath) +
					Path.DirectorySeparatorChar +
					Path.GetFileNameWithoutExtension(Application.ExecutablePath) +
					".config";
				Stream stream = File.Open(filename, FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter();
				presets = (List<MappingPreset>) formatter.Deserialize(stream);
				stream.Close();

				MappingPresets.Items.Clear();
				foreach (MappingPreset preset in presets)
				{
					int index = MappingPresets.Items.Add(preset);
					MappingPresets.SetItemChecked(index, preset.Enabled);
				}
				if (MappingPresets.Items.Count > 0)
					MappingPresets.SelectedIndex = 0;
			}
			catch
			{
			}
		}

		private void HomepageLinklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://github.com/datadiode/NetPorter/releases");
		}

		private void text1_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var cr = e.ChangedRange;
			var sh = cr.tb.SyntaxHighlighter;
			cr.ClearStyle(sh.GreenStyle, sh.GrayStyle, sh.BlueBoldStyle);
			cr.SetStyle(sh.GreenStyle, CommentRegex);
			cr.SetStyle(sh.GrayStyle, DisabledRegex);
			cr.SetStyle(sh.BlueBoldStyle, SectionRegex);
			cr.ClearFoldingMarkers();
			foreach (var sr in e.ChangedRange.GetRangesByLines(SectionRegex))
			{
				if (sr.Start.iLine > 0)
					sr.tb[sr.Start.iLine - 1].FoldingEndMarker = "section";
				sr.tb[sr.Start.iLine].FoldingStartMarker = "section";
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			webBrowser1.Visible = radioButton1.Checked;
			button1.Enabled = radioButton1.Checked;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			textBox1.Visible = radioButton2.Checked;
			button2.Enabled = radioButton2.Checked;
			button4.Enabled = radioButton2.Checked;
			if (textBox1.Visible)
			{
				try
				{
					string filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DualServer.ini");
					textBox1.Text = File.ReadAllText(filename);
					textBox1.ClearUndo();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message,
						"Error reading DualServer.ini",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			webBrowser1.Refresh();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				string filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DualServer.ini");
				File.WriteAllText(filename, textBox1.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message,
					"Error writing DualServer.ini",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (dualserver != null)
			{
				WinApi.FreeConsole();
				dualserver.CloseMainWindow();
				dualserver.WaitForExit();
				dualserver.Dispose();
				dualserver = null;
				StartDualServer();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			button2_Click(sender, e);
			button3_Click(sender, e);
		}

		private void textBox1_ContextMenuCommand(object sender, EventArgs e)
		{
			var item = sender as MenuItem;
			var pattern = "^\\[" + item.Text + "\\]";
			foreach (var line in textBox1.FindLines(pattern, RegexOptions.Singleline))
			{
				textBox1.Navigate(line);
				break;
			}
		}
	}
}
