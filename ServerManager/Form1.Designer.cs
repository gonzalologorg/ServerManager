namespace ServerManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            label4 = new Label();
            clientArgs = new TextBox();
            label3 = new Label();
            serverArgs = new TextBox();
            openClientPath = new LinkLabel();
            openServerPath = new LinkLabel();
            label2 = new Label();
            clientPath = new TextBox();
            serverPath = new TextBox();
            label1 = new Label();
            openServerButton = new Button();
            openClientButton = new Button();
            restartServer = new Button();
            restartClients = new Button();
            folderChooser = new OpenFileDialog();
            folderBrowser = new FolderBrowserDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(clientArgs);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(serverArgs);
            groupBox1.Controls.Add(openClientPath);
            groupBox1.Controls.Add(openServerPath);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(clientPath);
            groupBox1.Controls.Add(serverPath);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(560, 200);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Paths";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 153);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Arguments";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientArgs
            // 
            clientArgs.Location = new Point(6, 171);
            clientArgs.Name = "clientArgs";
            clientArgs.Size = new Size(548, 23);
            clientArgs.TabIndex = 8;
            clientArgs.Text = "-multirun -insecure -fullwindowsdump -nodns -nopreload";
            clientArgs.TextChanged += clientArgs_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 63);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 7;
            label3.Text = "Arguments";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // serverArgs
            // 
            serverArgs.Location = new Point(6, 81);
            serverArgs.Name = "serverArgs";
            serverArgs.Size = new Size(548, 23);
            serverArgs.TabIndex = 6;
            serverArgs.Text = resources.GetString("serverArgs.Text");
            serverArgs.TextChanged += serverArgs_TextChanged;
            // 
            // openClientPath
            // 
            openClientPath.AutoSize = true;
            openClientPath.Location = new Point(524, 107);
            openClientPath.Name = "openClientPath";
            openClientPath.Size = new Size(30, 15);
            openClientPath.TabIndex = 5;
            openClientPath.TabStop = true;
            openClientPath.Text = "Find";
            openClientPath.LinkClicked += openClientPath_LinkClicked;
            // 
            // openServerPath
            // 
            openServerPath.AutoSize = true;
            openServerPath.Location = new Point(524, 19);
            openServerPath.Name = "openServerPath";
            openServerPath.Size = new Size(30, 15);
            openServerPath.TabIndex = 4;
            openServerPath.TabStop = true;
            openServerPath.Text = "Find";
            openServerPath.LinkClicked += openServerPath_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 107);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 3;
            label2.Text = "Game Client (Executable)";
            // 
            // clientPath
            // 
            clientPath.Location = new Point(6, 125);
            clientPath.Name = "clientPath";
            clientPath.Size = new Size(548, 23);
            clientPath.TabIndex = 2;
            // 
            // serverPath
            // 
            serverPath.Location = new Point(6, 37);
            serverPath.Name = "serverPath";
            serverPath.Size = new Size(548, 23);
            serverPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Dedicated Server (Folder)";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // openServerButton
            // 
            openServerButton.Location = new Point(12, 218);
            openServerButton.Name = "openServerButton";
            openServerButton.Size = new Size(275, 23);
            openServerButton.TabIndex = 1;
            openServerButton.Text = "Open Server";
            openServerButton.UseVisualStyleBackColor = false;
            openServerButton.Click += openServerButton_Click;
            // 
            // openClientButton
            // 
            openClientButton.BackColor = SystemColors.ButtonFace;
            openClientButton.Location = new Point(297, 218);
            openClientButton.Name = "openClientButton";
            openClientButton.Size = new Size(275, 23);
            openClientButton.TabIndex = 2;
            openClientButton.Text = "Open Client";
            openClientButton.UseVisualStyleBackColor = false;
            openClientButton.Click += openClientButton_Click;
            // 
            // restartServer
            // 
            restartServer.Location = new Point(12, 247);
            restartServer.Name = "restartServer";
            restartServer.Size = new Size(275, 23);
            restartServer.TabIndex = 3;
            restartServer.Text = "Close Server";
            restartServer.UseVisualStyleBackColor = true;
            restartServer.Click += restartServer_Click;
            // 
            // restartClients
            // 
            restartClients.Location = new Point(297, 247);
            restartClients.Name = "restartClients";
            restartClients.Size = new Size(275, 23);
            restartClients.TabIndex = 4;
            restartClients.Text = "Close Clients";
            restartClients.UseVisualStyleBackColor = true;
            restartClients.Click += restartClients_Click;
            // 
            // folderChooser
            // 
            folderChooser.DefaultExt = "exe";
            folderChooser.FileName = "folderChooser";
            folderChooser.RestoreDirectory = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(584, 281);
            Controls.Add(restartClients);
            Controls.Add(restartServer);
            Controls.Add(openClientButton);
            Controls.Add(openServerButton);
            Controls.Add(groupBox1);
            Cursor = Cursors.Default;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(600, 320);
            MinimumSize = new Size(600, 320);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Dashboard";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private LinkLabel openClientPath;
        private LinkLabel openServerPath;
        private Label label2;
        private TextBox clientPath;
        private TextBox serverPath;
        private Label label1;
        private Button openServerButton;
        private Button openClientButton;
        private Button restartServer;
        private Button restartClients;
        private OpenFileDialog folderChooser;
        private Label label3;
        private TextBox serverArgs;
        private Label label4;
        private TextBox clientArgs;
        private FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Timer timer1;
    }
}