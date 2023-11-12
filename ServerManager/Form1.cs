using System.Configuration;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;

namespace ServerManager
{
    public partial class Form1 : Form
    {

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        Process serverProcess;
        List<Process> clientProcesses = new List<Process>();

        public Form1()
        {
            InitializeComponent();
            serverPath.Text = Properties.Settings.Default.serverPath;
            clientPath.Text = Properties.Settings.Default.clientPath;
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

        private void openServerButton_Click(object sender, EventArgs e)
        {
            if (serverProcess != null)
            {
                serverProcess.CloseMainWindow();
                serverProcess.Close();
            }

            serverProcess = new Process();
            serverProcess.StartInfo.Arguments = serverArgs.Text;
            serverProcess.StartInfo.FileName = serverPath.Text + "\\srcds.exe";
            serverProcess.EnableRaisingEvents = true;
            serverProcess.Exited += ServerProcess_Exited;

            serverProcess.Start();


            openServerButton.BackColor = Color.Chartreuse;
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
        private void openClientButton_Click(object sender, EventArgs e)
        {

            string screenWidth = resolutionBox.Text.Substring(0, 4).ToString();
            string screenHeight = resolutionBox.Text.Substring(5).ToString();
            float margin = 96f;

            string size = "-w " + screenWidth + " -h " + screenHeight;
            size += " -x " + (clientProcesses.Count * margin * 1.25f).ToString() + " -y " + (clientProcesses.Count * margin).ToString();

            Process newClient = new Process();
            newClient.StartInfo.Arguments = clientArgs.Text + " +connect " + GetLocalIPAddress() + " " + size;
            newClient.StartInfo.FileName = clientPath.Text;
            newClient.EnableRaisingEvents = true;
            newClient.Exited += NewClient_Exited;

            newClient.Start();

            clientProcesses.Add(newClient);
            openClientButton.BackColor = Color.Teal;
        }

        private void NewClient_Exited(object? sender, EventArgs e)
        {
            List<Process> processes = new List<Process>();
            foreach (Process process in clientProcesses)
            {
                if (process != null)
                    processes.Add(process);
            }

            clientProcesses = processes;
            if (clientProcesses.Count == 0)
            {
                openClientButton.BackColor = SystemColors.ButtonFace;
            }
        }

        private void restartClients_Click(object sender, EventArgs e)
        {
            if (clientProcesses.Count == 0) return;

            foreach (Process process in clientProcesses)
            {
                process.Kill();
                process.CloseMainWindow();
                process.Close();
            }

            clientProcesses.Clear();
        }
    }
}