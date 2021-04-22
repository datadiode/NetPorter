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
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Unclassified;

namespace NetPorter
{
	public partial class MainForm : Form
	{
		bool displayedTrayNote = false;

		public MainForm()
		{
			InitializeComponent();

			WinApi.SHFILEINFO fi;
			WinApi.SHGetFileInfo(Application.ExecutablePath, 0, out fi, (uint) Marshal.SizeOf(typeof(WinApi.SHFILEINFO)), WinApi.SHGFI.Icon);
			Icon = Icon.FromHandle(fi.hIcon);

			LoadConfig();
		}

		private void MainForm_LocationChanged(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				NotifyIcon.Visible = true;
				Visible = false;
				if (!displayedTrayNote)
					NotifyIcon.ShowBalloonTip(5000);
				displayedTrayNote = true;
			}
			else
			{
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
			preset.Listener = new PortMapListener(IPAddress.Any,
				preset.ListenPort,
				new IPEndPoint(Dns.GetHostEntry(preset.DestinationHost).AddressList[0], preset.DestinationPort));
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
			UpdateCheck.Check("http://beta.unclassified.de/projekte/netporter/update.xml");
		}
	}
}