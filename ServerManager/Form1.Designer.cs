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
            autoJoin = new CheckBox();
            portsOpen = new ComboBox();
            openClientPath = new LinkLabel();
            label2 = new Label();
            clientPath = new TextBox();
            openClientButton = new Button();
            restartClients = new Button();
            label4 = new Label();
            clientArgs = new TextBox();
            resolutionBox = new ComboBox();
            label5 = new Label();
            presetRemove = new Button();
            presetSave = new Button();
            presetsBox = new ComboBox();
            label3 = new Label();
            serverArgs = new TextBox();
            openServerPath = new LinkLabel();
            label1 = new Label();
            serverPath = new TextBox();
            openServerButton = new Button();
            restartServer = new Button();
            folderChooser = new OpenFileDialog();
            folderBrowser = new FolderBrowserDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            commandBox = new TextBox();
            commandButton = new Button();
            groupBox2 = new GroupBox();
            uniqueBox = new CheckBox();
            label6 = new Label();
            scriptRemove = new Button();
            scriptSave = new Button();
            scriptsBox = new ComboBox();
            commandServer = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(autoJoin);
            groupBox1.Controls.Add(portsOpen);
            groupBox1.Controls.Add(openClientPath);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(clientPath);
            groupBox1.Controls.Add(openClientButton);
            groupBox1.Controls.Add(restartClients);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(clientArgs);
            groupBox1.Controls.Add(resolutionBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(619, 146);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Client";
            // 
            // autoJoin
            // 
            autoJoin.AutoSize = true;
            autoJoin.Location = new Point(337, 119);
            autoJoin.Name = "autoJoin";
            autoJoin.Size = new Size(73, 19);
            autoJoin.TabIndex = 12;
            autoJoin.Text = "AutoJoin";
            autoJoin.UseVisualStyleBackColor = true;
            // 
            // portsOpen
            // 
            portsOpen.FormattingEnabled = true;
            portsOpen.Items.AddRange(new object[] { "27015", "27016", "27017", "27018", "27019", "27020" });
            portsOpen.Location = new Point(230, 117);
            portsOpen.Name = "portsOpen";
            portsOpen.Size = new Size(101, 23);
            portsOpen.TabIndex = 11;
            portsOpen.Text = "27015";
            // 
            // openClientPath
            // 
            openClientPath.AutoSize = true;
            openClientPath.Dock = DockStyle.Right;
            openClientPath.Location = new Point(586, 19);
            openClientPath.Name = "openClientPath";
            openClientPath.Size = new Size(30, 15);
            openClientPath.TabIndex = 5;
            openClientPath.TabStop = true;
            openClientPath.Text = "Find";
            openClientPath.TextAlign = ContentAlignment.TopRight;
            openClientPath.LinkClicked += openClientPath_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 19);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 3;
            label2.Text = "Game Client (Executable)";
            // 
            // clientPath
            // 
            clientPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            clientPath.Location = new Point(6, 37);
            clientPath.Name = "clientPath";
            clientPath.Size = new Size(607, 23);
            clientPath.TabIndex = 2;
            // 
            // openClientButton
            // 
            openClientButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openClientButton.BackColor = SystemColors.ButtonFace;
            openClientButton.Location = new Point(6, 117);
            openClientButton.Name = "openClientButton";
            openClientButton.Size = new Size(218, 23);
            openClientButton.TabIndex = 2;
            openClientButton.Text = "Open Client";
            openClientButton.UseVisualStyleBackColor = false;
            openClientButton.Click += openClientButton_Click;
            // 
            // restartClients
            // 
            restartClients.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            restartClients.Location = new Point(422, 117);
            restartClients.Name = "restartClients";
            restartClients.Size = new Size(191, 23);
            restartClients.TabIndex = 4;
            restartClients.Text = "Close Clients";
            restartClients.UseVisualStyleBackColor = true;
            restartClients.Click += restartClients_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 70);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 9;
            label4.Text = "Arguments";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientArgs
            // 
            clientArgs.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            clientArgs.Location = new Point(6, 88);
            clientArgs.Name = "clientArgs";
            clientArgs.Size = new Size(496, 23);
            clientArgs.TabIndex = 8;
            clientArgs.Text = "-multirun -insecure -fullwindowsdump -nodns -nopreload";
            clientArgs.TextChanged += clientArgs_TextChanged;
            // 
            // resolutionBox
            // 
            resolutionBox.Anchor = AnchorStyles.Right;
            resolutionBox.DisplayMember = "1600x900";
            resolutionBox.FormattingEnabled = true;
            resolutionBox.Items.AddRange(new object[] { "1280x720", "1600x900", "1920x1080" });
            resolutionBox.Location = new Point(508, 88);
            resolutionBox.Name = "resolutionBox";
            resolutionBox.Size = new Size(105, 23);
            resolutionBox.TabIndex = 10;
            resolutionBox.Text = "1600x900";
            resolutionBox.ValueMember = "1600x900";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 167);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 14;
            label5.Text = "Presets";
            // 
            // presetRemove
            // 
            presetRemove.Location = new Point(83, 214);
            presetRemove.Name = "presetRemove";
            presetRemove.Size = new Size(75, 23);
            presetRemove.TabIndex = 13;
            presetRemove.Text = "Remove";
            presetRemove.UseVisualStyleBackColor = true;
            presetRemove.Click += button2_Click;
            // 
            // presetSave
            // 
            presetSave.Location = new Point(12, 214);
            presetSave.Name = "presetSave";
            presetSave.Size = new Size(65, 23);
            presetSave.TabIndex = 12;
            presetSave.Text = "Save";
            presetSave.UseVisualStyleBackColor = true;
            presetSave.Click += button1_Click;
            // 
            // presetsBox
            // 
            presetsBox.FormattingEnabled = true;
            presetsBox.Location = new Point(12, 185);
            presetsBox.Name = "presetsBox";
            presetsBox.Size = new Size(146, 23);
            presetsBox.TabIndex = 11;
            presetsBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 62);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 7;
            label3.Text = "Arguments";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // serverArgs
            // 
            serverArgs.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            serverArgs.Location = new Point(6, 80);
            serverArgs.Name = "serverArgs";
            serverArgs.Size = new Size(458, 23);
            serverArgs.TabIndex = 6;
            serverArgs.Text = resources.GetString("serverArgs.Text");
            serverArgs.TextChanged += serverArgs_TextChanged;
            // 
            // openServerPath
            // 
            openServerPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openServerPath.AutoSize = true;
            openServerPath.Location = new Point(437, 18);
            openServerPath.Name = "openServerPath";
            openServerPath.Size = new Size(30, 15);
            openServerPath.TabIndex = 4;
            openServerPath.TabStop = true;
            openServerPath.Text = "Find";
            openServerPath.LinkClicked += openServerPath_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Dedicated Server (Folder)";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // serverPath
            // 
            serverPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            serverPath.Location = new Point(6, 36);
            serverPath.Name = "serverPath";
            serverPath.Size = new Size(460, 23);
            serverPath.TabIndex = 1;
            // 
            // openServerButton
            // 
            openServerButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openServerButton.Location = new Point(6, 109);
            openServerButton.Name = "openServerButton";
            openServerButton.Size = new Size(172, 23);
            openServerButton.TabIndex = 1;
            openServerButton.Text = "Open Server";
            openServerButton.UseVisualStyleBackColor = false;
            openServerButton.Click += openServerButton_Click;
            // 
            // restartServer
            // 
            restartServer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            restartServer.Location = new Point(270, 109);
            restartServer.Name = "restartServer";
            restartServer.Size = new Size(196, 23);
            restartServer.TabIndex = 3;
            restartServer.Text = "Close Server";
            restartServer.UseVisualStyleBackColor = true;
            restartServer.Click += restartServer_Click;
            // 
            // folderChooser
            // 
            folderChooser.DefaultExt = "exe";
            folderChooser.FileName = "folderChooser";
            folderChooser.RestoreDirectory = true;
            // 
            // commandBox
            // 
            commandBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            commandBox.Location = new Point(12, 319);
            commandBox.Multiline = true;
            commandBox.Name = "commandBox";
            commandBox.Size = new Size(624, 88);
            commandBox.TabIndex = 5;
            commandBox.TextChanged += commandBox_TextChanged;
            // 
            // commandButton
            // 
            commandButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            commandButton.Location = new Point(12, 413);
            commandButton.Name = "commandButton";
            commandButton.Size = new Size(514, 22);
            commandButton.TabIndex = 6;
            commandButton.Text = "Custom Command";
            commandButton.UseVisualStyleBackColor = true;
            commandButton.Click += commandButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(uniqueBox);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(openServerPath);
            groupBox2.Controls.Add(serverPath);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(serverArgs);
            groupBox2.Controls.Add(openServerButton);
            groupBox2.Controls.Add(restartServer);
            groupBox2.Location = new Point(164, 167);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(472, 146);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Server";
            // 
            // uniqueBox
            // 
            uniqueBox.AutoSize = true;
            uniqueBox.Checked = true;
            uniqueBox.CheckState = CheckState.Checked;
            uniqueBox.Location = new Point(181, 112);
            uniqueBox.Name = "uniqueBox";
            uniqueBox.Size = new Size(64, 19);
            uniqueBox.TabIndex = 8;
            uniqueBox.Text = "Unique";
            uniqueBox.UseVisualStyleBackColor = true;
            uniqueBox.CheckedChanged += uniqueBox_CheckedChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 245);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 19;
            label6.Text = "Scripts";
            // 
            // scriptRemove
            // 
            scriptRemove.Location = new Point(83, 290);
            scriptRemove.Name = "scriptRemove";
            scriptRemove.Size = new Size(75, 23);
            scriptRemove.TabIndex = 18;
            scriptRemove.Text = "Remove";
            scriptRemove.UseVisualStyleBackColor = true;
            // 
            // scriptSave
            // 
            scriptSave.Location = new Point(12, 290);
            scriptSave.Name = "scriptSave";
            scriptSave.Size = new Size(65, 23);
            scriptSave.TabIndex = 17;
            scriptSave.Text = "Save";
            scriptSave.UseVisualStyleBackColor = true;
            scriptSave.Click += scriptSave_Click;
            // 
            // scriptsBox
            // 
            scriptsBox.FormattingEnabled = true;
            scriptsBox.Location = new Point(12, 263);
            scriptsBox.Name = "scriptsBox";
            scriptsBox.Size = new Size(146, 23);
            scriptsBox.TabIndex = 16;
            scriptsBox.SelectedIndexChanged += scriptsBox_SelectedIndexChanged;
            // 
            // commandServer
            // 
            commandServer.AutoSize = true;
            commandServer.Checked = true;
            commandServer.CheckState = CheckState.Checked;
            commandServer.Location = new Point(532, 413);
            commandServer.Name = "commandServer";
            commandServer.Size = new Size(90, 19);
            commandServer.TabIndex = 20;
            commandServer.Text = "Open Server";
            commandServer.UseVisualStyleBackColor = true;
            commandServer.CheckedChanged += commandServer_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(642, 441);
            Controls.Add(commandServer);
            Controls.Add(label6);
            Controls.Add(scriptRemove);
            Controls.Add(scriptSave);
            Controls.Add(scriptsBox);
            Controls.Add(groupBox2);
            Controls.Add(label5);
            Controls.Add(commandButton);
            Controls.Add(presetRemove);
            Controls.Add(presetSave);
            Controls.Add(commandBox);
            Controls.Add(presetsBox);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Dashboard";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ComboBox resolutionBox;
        private TextBox commandBox;
        private Button commandButton;
        private Label label5;
        private Button presetRemove;
        private Button presetSave;
        private ComboBox presetsBox;
        private GroupBox groupBox2;
        private Label label6;
        private Button scriptRemove;
        private Button scriptSave;
        private ComboBox scriptsBox;
        private CheckBox uniqueBox;
        private CheckBox commandServer;
        private ComboBox portsOpen;
        private CheckBox autoJoin;
    }
}