using System.Configuration;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ServerManager
{
	public partial class Form1 : Form
	{

		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		Process serverProcess;

		PresetManager presetManager;
		ScriptsManager scriptsManager;

		TCPListener listener;
		List<string> exclude = new List<string>();
		struct ArgumentList
		{
			public Panel container;
			public TextBox BoxKey;
			public TextBox BoxValue;
		}

		Dictionary<Panel, ArgumentList> parameterList = new Dictionary<Panel, ArgumentList>();

		public Form1(PresetManager presets, ScriptsManager scripts)
		{
			InitializeComponent();
			serverPath.Text = Properties.Settings.Default.serverPath;
			clientPath.Text = Properties.Settings.Default.clientPath;
			commandBox.Text = Properties.Settings.Default.commandBox;
			screenModeCBox.Text = Properties.Settings.Default.screenMode;
			commandServer.Checked = Properties.Settings.Default.commandServer;

			presetManager = presets;
			scriptsManager = scripts;

			rebuildPresets(presets);
			rebuildScripts(scripts);

			listener = new TCPListener();
			StartCheckingPorts();
		}

		public void StartCheckingPorts()
		{
			var task = Task.Run(async () =>
			{
				//converts portsOpen.Text to number
				int portNumber = Int32.Parse(portsOpen.Text);
				bool isOpen = await TCPListener.StartWorker(portNumber);

				if (autoJoin.Checked && isOpen)
				{
					openClient();
					autoJoin.Checked = false;
				}

				Thread.Sleep(1000);
				StartCheckingPorts();
			});

		}

		private void rebuildPresets(PresetManager presets)
		{
			presetsBox.Items.Clear();

			string def = Properties.Settings.Default.lastSelected;
			int slot = 0;
			foreach (Preset preset in presets.presetList)
			{
				presetsBox.Items.Add(preset.Name);
				if (def == preset.Name)
				{
					presetsBox.Text = preset.Name;
					selectPreset(slot);
				}
				slot++;

			}
		}
		private void rebuildScripts(ScriptsManager scripts)
		{
			scriptsBox.Items.Clear();
			foreach (string script in scripts.scripts)
			{
				scriptsBox.Items.Add(script);
			}
		}

		private void openServerPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult result = folderBrowser.ShowDialog();
			if (result == DialogResult.OK)
			{
				serverPath.Text = folderBrowser.SelectedPath;
				Properties.Settings.Default.serverPath = serverPath.Text;
				Properties.Settings.Default.Save();
			}
		}

		private void openClientPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult result = folderChooser.ShowDialog();
			if (result == DialogResult.OK)
			{
				clientPath.Text = folderChooser.FileName;
				Properties.Settings.Default.clientPath = clientPath.Text;
				Properties.Settings.Default.Save();
			}
		}

		private void serverArgs_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.serverArgs = serverArgs.Text;
			Properties.Settings.Default.Save();
		}

		private void clientArgs_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.clientArgs = clientArgs.Text;
			Properties.Settings.Default.Save();
		}

		private void openClient()
		{
			string screenWidth = resolutionBox.Text.Substring(0, 4).ToString();
			string screenHeight = resolutionBox.Text.Substring(5).ToString();

			int screenW = Screen.PrimaryScreen.WorkingArea.Width - 16;
			int screenH = Screen.PrimaryScreen.WorkingArea.Height - 40;

			float marginX = screenW - int.Parse(screenWidth);
			float marginY = screenH - int.Parse(screenHeight);

			string size = "-" + screenModeCBox.Text + " -w " + screenWidth + " -h " + screenHeight;

			if (screenModeCBox.Text != "noborder" || int.Parse(screenHeight) != Screen.PrimaryScreen.WorkingArea.Height)
				size += " -x " + ((instances % 2) * marginX).ToString() + " -y " + ((instances % 2) * marginY).ToString();


			Process newClient = new Process();
			newClient.StartInfo.Arguments = clientArgs.Text + " +connect " + GetLocalIPAddress() + ":" + portsOpen.Text + " " + size;
			newClient.StartInfo.FileName = clientPath.Text;

			newClient.Start();
			instances++;
		}

		private void openServer()
		{
			serverProcess = new Process();
			serverProcess.StartInfo.Arguments = serverArgs.Text;
			serverProcess.StartInfo.FileName = serverPath.Text + "\\srcds.exe";
			serverProcess.EnableRaisingEvents = true;
			serverProcess.Exited += ServerProcess_Exited;

			serverProcess.Start();
		}

		private void openServerButton_Click(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.uniqueBox && serverProcess != null && serverProcess.Container != null)
			{
				serverProcess.CloseMainWindow();
				serverProcess.Close();
			}

			openServerButton.BackColor = Color.Chartreuse;
			openServer();
		}

		private void ServerProcess_Exited(object? sender, EventArgs e)
		{
			openServerButton.BackColor = SystemColors.ButtonFace;
		}

		private void restartServer_Click(object sender, EventArgs e)
		{
			if (serverProcess != null)
			{
				serverProcess.CloseMainWindow();
				serverProcess.Close();
			}
		}
		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip.ToString();
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		int instances = 0;
		private void openClientButton_Click(object sender, EventArgs e)
		{
			openClient();
		}

		private void restartClients_Click(object sender, EventArgs e)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				Console.WriteLine(process.Id);
				if (process.ProcessName == "hl2" || process.ProcessName == "gmod")
				{
					process.Kill(true);
					process.Close();
				}
			}
		}

		private void commandButton_Click(object sender, EventArgs e)
		{
			if (File.Exists("./command.bat"))
				File.Delete("./command.bat");

			File.WriteAllText("./command.bat", commandBox.Text + "\nexit;");
			Process? proc = null;

			commandButton.BackColor = Color.Orange;
			this.Cursor = Cursors.WaitCursor;

			proc = new Process();
			proc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
			proc.StartInfo.FileName = "./command.bat";
			proc.StartInfo.CreateNoWindow = true;
			proc.Start();
			proc.WaitForExit();
			proc.Close();

			this.Cursor = Cursors.Default;
			commandButton.BackColor = Color.WhiteSmoke;

			if (Properties.Settings.Default.commandServer)
			{
				openServer();
			}
		}

		private void commandBox_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.commandBox = commandBox.Text;
			Properties.Settings.Default.Save();
		}

		private void selectPreset(int slot)
		{
			try
			{
				Preset preset = presetManager.presetList[slot];
				if (preset != null)
				{
					Properties.Settings.Default.lastSelected = preset.Name;
					Properties.Settings.Default.Save();

					serverPath.Text = preset.Path;
					serverArgs.Text = preset.Arguments;

					foreach (var entry in parameterList)
					{
						entry.Key.Dispose();
					}

					parameterList.Clear();

					var parts = Regex.Matches(serverArgs.Text, @"[\""].+?[\""]|[^ ]+")
						.Cast<Match>()
						.Select(m => m.Value)
						.ToList();

					int cursor = 0;
					while (cursor < parts.Count + 1)
					{
						string currentKey = parts[cursor];
						string newKey = parts.Count >= cursor + 1 ? parts[cursor + 1] : "";

						if (currentKey.StartsWith("+") || currentKey.StartsWith("-"))
						{
							if (newKey.StartsWith("+") || newKey.StartsWith("-"))
								newKey = "";

							CreateNewOption(currentKey, newKey);
						}
						cursor += newKey != "" ? 2 : 1;
					}
				}
			}
			catch { }
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox? cmb = sender as ComboBox;
			selectPreset(cmb.SelectedIndex);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (presetsBox.Text == "")
			{
				MessageBox.Show("Missing Name!");
				return;
			}

			presetManager.addPreset(serverPath.Text, serverArgs.Text, presetsBox.Text);
			rebuildPresets(presetManager);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string selected = presetsBox.Text;
			if (selected == null || selected == "")
			{
				return;
			}
			presetManager.removePreset(selected);
			rebuildPresets(presetManager);
			presetsBox.Text = "";
		}

		private void scriptSave_Click(object sender, EventArgs e)
		{
			string result = scriptsBox.Text;
			if (result == "")
			{
				MessageBox.Show("Missing Name!");
				return;
			}

			File.WriteAllText("./scripts/" + result + ".bat", commandBox.Text);
			scriptsManager = new ScriptsManager();
			rebuildScripts(scriptsManager);
		}

		private void scriptsBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox? cmb = sender as ComboBox;
			try
			{
				string script = scriptsManager.scripts[cmb.SelectedIndex];
				if (script != null)
				{
					string fileData = File.ReadAllText("./scripts/" + script + ".bat");
					if (fileData != null)
					{
						commandBox.Text = fileData;
					}
				}
			}
			catch { }
		}

		private void commandServer_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox? cmb = sender as CheckBox;
			try
			{
				Properties.Settings.Default.commandServer = cmb.Checked;
				Properties.Settings.Default.Save();
			}
			catch { }
		}

		private void uniqueBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox? cmb = sender as CheckBox;
			try
			{
				Properties.Settings.Default.uniqueBox = cmb.Checked;
				Properties.Settings.Default.Save();
			}
			catch { }
		}

		void CreateNewOption(string? keyText = null, string? valueText = null)
		{
			Panel newEntry = new Panel();
			newEntry.Parent = this.panelParamList;
			newEntry.Size = new Size(280, 20);

			TextBox key = new TextBox();
			key.Parent = newEntry;
			key.Size = new Size(119, 20);
			if (keyText != null)
				key.Text = keyText;

			TextBox value = new TextBox();
			value.Parent = newEntry;
			value.Size = new Size(119, 20);
			value.Location = new Point(124, 0);
			if (valueText != null)
				value.Text = valueText;

			ArgumentList argument = new ArgumentList();
			argument.container = newEntry;
			argument.BoxKey = key;
			argument.BoxValue = value;

			parameterList.Add(newEntry, argument);

			Button delete = new Button();
			delete.Parent = newEntry;
			delete.Text = "-";
			delete.Size = new Size(32, 20);
			delete.Location = new Point(280 - 32, 0);
			delete.Click += (s, e) =>
			{
				newEntry.Dispose();
			};

			key.TextChanged += (s, e) =>
			{
				UpdateTextEntry();
			};

			value.TextChanged += (s, e) =>
			{
				UpdateTextEntry();
			};
		}

		void UpdateTextEntry()
		{
			string finalResult = "";
			foreach (var entry in parameterList)
			{
				finalResult += entry.Value.BoxKey.Text + " " + entry.Value.BoxValue.Text + " ";
			}

			serverArgs.Text = finalResult;
			Properties.Settings.Default.Save();
		}
		private void btnAddLine_Click(object sender, EventArgs e)
		{
			CreateNewOption();
		}

		private void screenModeCBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox? cmb = sender as ComboBox;
			try
			{
				Properties.Settings.Default.screenMode = cmb.Text;
				Properties.Settings.Default.Save();
			}
			catch { }
		}
	}
}