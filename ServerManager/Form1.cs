using System.Configuration;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Drawing;
using System.ComponentModel;

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

        public Form1(PresetManager presets, ScriptsManager scripts)
        {
            InitializeComponent();
            serverPath.Text = Properties.Settings.Default.serverPath;
            clientPath.Text = Properties.Settings.Default.clientPath;
            commandBox.Text = Properties.Settings.Default.commandBox;
            uniqueBox.Checked = Properties.Settings.Default.uniqueBox;
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
            foreach (Preset preset in presets.presetList)
            {
                presetsBox.Items.Add(preset.Name);
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
            instances++;

            string screenWidth = resolutionBox.Text.Substring(0, 4).ToString();
            string screenHeight = resolutionBox.Text.Substring(5).ToString();
            float margin = 96f;

            string size = "-w " + screenWidth + " -h " + screenHeight;
            size += " -x " + ((instances % 2) * margin * 1.25f).ToString() + " -y " + ((instances % 2) * margin).ToString();

            Process newClient = new Process();
            newClient.StartInfo.Arguments = clientArgs.Text + " +connect " + GetLocalIPAddress() + ":" + portsOpen.Text + " " + size;
            newClient.StartInfo.FileName = clientPath.Text;

            newClient.Start();
            openClientButton.BackColor = Color.Teal;
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
            if (Properties.Settings.Default.uniqueBox && serverProcess != null)
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
                if (process.ProcessName == "hl2")
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox? cmb = sender as ComboBox;
            try
            {
                Preset preset = presetManager.presetList[cmb.SelectedIndex];
                if (preset != null)
                {
                    serverPath.Text = preset.Path;
                    serverArgs.Text = preset.Arguments;
                }
            }
            catch { }
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
    }
}