
namespace CryptosystemWithFSW
{
    partial class MainForm
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
            this.labelChooseAlgorithm = new System.Windows.Forms.Label();
            this.comboBoxChooseAlgorithm = new System.Windows.Forms.ComboBox();
            this.groupBoxFSWOptions = new System.Windows.Forms.GroupBox();
            this.labelDestinationFolder = new System.Windows.Forms.Label();
            this.buttonChooseDestinationFolder = new System.Windows.Forms.Button();
            this.labelChooseDestinationFolder = new System.Windows.Forms.Label();
            this.labelTargetFolder = new System.Windows.Forms.Label();
            this.buttonChooseTargetFolder = new System.Windows.Forms.Button();
            this.labelChooseTargetFolder = new System.Windows.Forms.Label();
            this.checkBoxTurnOnOff = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageEncryption = new System.Windows.Forms.TabPage();
            this.buttonEncryptFile = new System.Windows.Forms.Button();
            this.labelFileToEncrypt = new System.Windows.Forms.Label();
            this.buttonChooseFileToEncrypt = new System.Windows.Forms.Button();
            this.labelChooseFileToEncrypt = new System.Windows.Forms.Label();
            this.tabPageDecryption = new System.Windows.Forms.TabPage();
            this.buttonDecryptFile = new System.Windows.Forms.Button();
            this.labelDecryptedFileDestination = new System.Windows.Forms.Label();
            this.buttonChooseDecryptedFileDestination = new System.Windows.Forms.Button();
            this.labelChooseDecryptedFileDestination = new System.Windows.Forms.Label();
            this.labelFileToDecrypt = new System.Windows.Forms.Label();
            this.buttonChooseFileToDecrypt = new System.Windows.Forms.Button();
            this.labelChooseFileToDecrypt = new System.Windows.Forms.Label();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.groupBoxFSWOptions.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageEncryption.SuspendLayout();
            this.tabPageDecryption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChooseAlgorithm
            // 
            this.labelChooseAlgorithm.AutoSize = true;
            this.labelChooseAlgorithm.Location = new System.Drawing.Point(12, 15);
            this.labelChooseAlgorithm.Name = "labelChooseAlgorithm";
            this.labelChooseAlgorithm.Size = new System.Drawing.Size(107, 15);
            this.labelChooseAlgorithm.TabIndex = 0;
            this.labelChooseAlgorithm.Text = "Choose Algorithm:";
            // 
            // comboBoxChooseAlgorithm
            // 
            this.comboBoxChooseAlgorithm.DropDownHeight = 100;
            this.comboBoxChooseAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseAlgorithm.DropDownWidth = 135;
            this.comboBoxChooseAlgorithm.FormattingEnabled = true;
            this.comboBoxChooseAlgorithm.IntegralHeight = false;
            this.comboBoxChooseAlgorithm.Items.AddRange(new object[] {
            "Four-Square Cipher",
            "DES"});
            this.comboBoxChooseAlgorithm.Location = new System.Drawing.Point(125, 12);
            this.comboBoxChooseAlgorithm.MaxDropDownItems = 2;
            this.comboBoxChooseAlgorithm.Name = "comboBoxChooseAlgorithm";
            this.comboBoxChooseAlgorithm.Size = new System.Drawing.Size(135, 23);
            this.comboBoxChooseAlgorithm.TabIndex = 1;
            this.comboBoxChooseAlgorithm.SelectedIndexChanged += new System.EventHandler(this.ChooseAlgorithmComboBox_SelectedIndexChanged);
            // 
            // groupBoxFSWOptions
            // 
            this.groupBoxFSWOptions.Controls.Add(this.labelDestinationFolder);
            this.groupBoxFSWOptions.Controls.Add(this.buttonChooseDestinationFolder);
            this.groupBoxFSWOptions.Controls.Add(this.labelChooseDestinationFolder);
            this.groupBoxFSWOptions.Controls.Add(this.labelTargetFolder);
            this.groupBoxFSWOptions.Controls.Add(this.buttonChooseTargetFolder);
            this.groupBoxFSWOptions.Controls.Add(this.labelChooseTargetFolder);
            this.groupBoxFSWOptions.Controls.Add(this.checkBoxTurnOnOff);
            this.groupBoxFSWOptions.Location = new System.Drawing.Point(12, 45);
            this.groupBoxFSWOptions.Name = "groupBoxFSWOptions";
            this.groupBoxFSWOptions.Size = new System.Drawing.Size(550, 160);
            this.groupBoxFSWOptions.TabIndex = 2;
            this.groupBoxFSWOptions.TabStop = false;
            this.groupBoxFSWOptions.Text = "Options related to File System Watcher";
            // 
            // labelDestinationFolder
            // 
            this.labelDestinationFolder.AutoSize = true;
            this.labelDestinationFolder.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelDestinationFolder.Location = new System.Drawing.Point(30, 130);
            this.labelDestinationFolder.Name = "labelDestinationFolder";
            this.labelDestinationFolder.Size = new System.Drawing.Size(125, 15);
            this.labelDestinationFolder.TabIndex = 6;
            this.labelDestinationFolder.Text = "labelDestinationFolder";
            // 
            // buttonChooseDestinationFolder
            // 
            this.buttonChooseDestinationFolder.Location = new System.Drawing.Point(165, 100);
            this.buttonChooseDestinationFolder.Name = "buttonChooseDestinationFolder";
            this.buttonChooseDestinationFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseDestinationFolder.TabIndex = 5;
            this.buttonChooseDestinationFolder.Text = "Choose";
            this.buttonChooseDestinationFolder.UseVisualStyleBackColor = true;
            this.buttonChooseDestinationFolder.Click += new System.EventHandler(this.ChooseDestinationFolderButton_Click);
            // 
            // labelChooseDestinationFolder
            // 
            this.labelChooseDestinationFolder.AutoSize = true;
            this.labelChooseDestinationFolder.Location = new System.Drawing.Point(10, 104);
            this.labelChooseDestinationFolder.Name = "labelChooseDestinationFolder";
            this.labelChooseDestinationFolder.Size = new System.Drawing.Size(149, 15);
            this.labelChooseDestinationFolder.TabIndex = 4;
            this.labelChooseDestinationFolder.Text = "Choose Destination Folder:";
            // 
            // labelTargetFolder
            // 
            this.labelTargetFolder.AutoSize = true;
            this.labelTargetFolder.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelTargetFolder.Location = new System.Drawing.Point(30, 80);
            this.labelTargetFolder.Name = "labelTargetFolder";
            this.labelTargetFolder.Size = new System.Drawing.Size(97, 15);
            this.labelTargetFolder.TabIndex = 3;
            this.labelTargetFolder.Text = "labelTargetFolder";
            // 
            // buttonChooseTargetFolder
            // 
            this.buttonChooseTargetFolder.Location = new System.Drawing.Point(137, 50);
            this.buttonChooseTargetFolder.Name = "buttonChooseTargetFolder";
            this.buttonChooseTargetFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseTargetFolder.TabIndex = 2;
            this.buttonChooseTargetFolder.Text = "Choose";
            this.buttonChooseTargetFolder.UseVisualStyleBackColor = true;
            this.buttonChooseTargetFolder.Click += new System.EventHandler(this.ChooseTargetFolderButton_Click);
            // 
            // labelChooseTargetFolder
            // 
            this.labelChooseTargetFolder.AutoSize = true;
            this.labelChooseTargetFolder.Location = new System.Drawing.Point(10, 54);
            this.labelChooseTargetFolder.Name = "labelChooseTargetFolder";
            this.labelChooseTargetFolder.Size = new System.Drawing.Size(121, 15);
            this.labelChooseTargetFolder.TabIndex = 1;
            this.labelChooseTargetFolder.Text = "Choose Target Folder:";
            // 
            // checkBoxTurnOnOff
            // 
            this.checkBoxTurnOnOff.AutoSize = true;
            this.checkBoxTurnOnOff.Location = new System.Drawing.Point(10, 25);
            this.checkBoxTurnOnOff.Name = "checkBoxTurnOnOff";
            this.checkBoxTurnOnOff.Size = new System.Drawing.Size(95, 19);
            this.checkBoxTurnOnOff.TabIndex = 0;
            this.checkBoxTurnOnOff.Text = "Turn On FSW";
            this.checkBoxTurnOnOff.UseVisualStyleBackColor = true;
            this.checkBoxTurnOnOff.Click += new System.EventHandler(this.TurnOnOffCheckBox_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageEncryption);
            this.tabControl.Controls.Add(this.tabPageDecryption);
            this.tabControl.Location = new System.Drawing.Point(12, 215);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(550, 185);
            this.tabControl.TabIndex = 3;
            // 
            // tabPageEncryption
            // 
            this.tabPageEncryption.Controls.Add(this.buttonEncryptFile);
            this.tabPageEncryption.Controls.Add(this.labelFileToEncrypt);
            this.tabPageEncryption.Controls.Add(this.buttonChooseFileToEncrypt);
            this.tabPageEncryption.Controls.Add(this.labelChooseFileToEncrypt);
            this.tabPageEncryption.Location = new System.Drawing.Point(4, 24);
            this.tabPageEncryption.Name = "tabPageEncryption";
            this.tabPageEncryption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEncryption.Size = new System.Drawing.Size(542, 157);
            this.tabPageEncryption.TabIndex = 0;
            this.tabPageEncryption.Text = "Encryption";
            this.tabPageEncryption.UseVisualStyleBackColor = true;
            // 
            // buttonEncryptFile
            // 
            this.buttonEncryptFile.Location = new System.Drawing.Point(50, 70);
            this.buttonEncryptFile.Name = "buttonEncryptFile";
            this.buttonEncryptFile.Size = new System.Drawing.Size(100, 30);
            this.buttonEncryptFile.TabIndex = 3;
            this.buttonEncryptFile.Text = "Encrypt File";
            this.buttonEncryptFile.UseVisualStyleBackColor = true;
            this.buttonEncryptFile.Click += new System.EventHandler(this.EncryptFileButton_Click);
            // 
            // labelFileToEncrypt
            // 
            this.labelFileToEncrypt.AutoSize = true;
            this.labelFileToEncrypt.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelFileToEncrypt.Location = new System.Drawing.Point(30, 40);
            this.labelFileToEncrypt.Name = "labelFileToEncrypt";
            this.labelFileToEncrypt.Size = new System.Drawing.Size(102, 15);
            this.labelFileToEncrypt.TabIndex = 2;
            this.labelFileToEncrypt.Text = "labelFileToEncrypt";
            // 
            // buttonChooseFileToEncrypt
            // 
            this.buttonChooseFileToEncrypt.Location = new System.Drawing.Point(144, 10);
            this.buttonChooseFileToEncrypt.Name = "buttonChooseFileToEncrypt";
            this.buttonChooseFileToEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseFileToEncrypt.TabIndex = 1;
            this.buttonChooseFileToEncrypt.Text = "Choose";
            this.buttonChooseFileToEncrypt.UseVisualStyleBackColor = true;
            this.buttonChooseFileToEncrypt.Click += new System.EventHandler(this.ChooseFileToEncryptButton_Click);
            // 
            // labelChooseFileToEncrypt
            // 
            this.labelChooseFileToEncrypt.AutoSize = true;
            this.labelChooseFileToEncrypt.Location = new System.Drawing.Point(10, 14);
            this.labelChooseFileToEncrypt.Name = "labelChooseFileToEncrypt";
            this.labelChooseFileToEncrypt.Size = new System.Drawing.Size(128, 15);
            this.labelChooseFileToEncrypt.TabIndex = 0;
            this.labelChooseFileToEncrypt.Text = "Choose File to Encrypt:";
            // 
            // tabPageDecryption
            // 
            this.tabPageDecryption.Controls.Add(this.buttonDecryptFile);
            this.tabPageDecryption.Controls.Add(this.labelDecryptedFileDestination);
            this.tabPageDecryption.Controls.Add(this.buttonChooseDecryptedFileDestination);
            this.tabPageDecryption.Controls.Add(this.labelChooseDecryptedFileDestination);
            this.tabPageDecryption.Controls.Add(this.labelFileToDecrypt);
            this.tabPageDecryption.Controls.Add(this.buttonChooseFileToDecrypt);
            this.tabPageDecryption.Controls.Add(this.labelChooseFileToDecrypt);
            this.tabPageDecryption.Location = new System.Drawing.Point(4, 24);
            this.tabPageDecryption.Name = "tabPageDecryption";
            this.tabPageDecryption.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDecryption.Size = new System.Drawing.Size(542, 157);
            this.tabPageDecryption.TabIndex = 1;
            this.tabPageDecryption.Text = "Decryption";
            this.tabPageDecryption.UseVisualStyleBackColor = true;
            // 
            // buttonDecryptFile
            // 
            this.buttonDecryptFile.Location = new System.Drawing.Point(50, 115);
            this.buttonDecryptFile.Name = "buttonDecryptFile";
            this.buttonDecryptFile.Size = new System.Drawing.Size(100, 30);
            this.buttonDecryptFile.TabIndex = 6;
            this.buttonDecryptFile.Text = "Decrypt File";
            this.buttonDecryptFile.UseVisualStyleBackColor = true;
            this.buttonDecryptFile.Click += new System.EventHandler(this.DecryptFileButton_Click);
            // 
            // labelDecryptedFileDestination
            // 
            this.labelDecryptedFileDestination.AutoSize = true;
            this.labelDecryptedFileDestination.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelDecryptedFileDestination.Location = new System.Drawing.Point(30, 90);
            this.labelDecryptedFileDestination.Name = "labelDecryptedFileDestination";
            this.labelDecryptedFileDestination.Size = new System.Drawing.Size(164, 15);
            this.labelDecryptedFileDestination.TabIndex = 5;
            this.labelDecryptedFileDestination.Text = "labelDecryptedFileDestination";
            // 
            // buttonChooseDecryptedFileDestination
            // 
            this.buttonChooseDecryptedFileDestination.Location = new System.Drawing.Point(207, 60);
            this.buttonChooseDecryptedFileDestination.Name = "buttonChooseDecryptedFileDestination";
            this.buttonChooseDecryptedFileDestination.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseDecryptedFileDestination.TabIndex = 4;
            this.buttonChooseDecryptedFileDestination.Text = "Choose";
            this.buttonChooseDecryptedFileDestination.UseVisualStyleBackColor = true;
            this.buttonChooseDecryptedFileDestination.Click += new System.EventHandler(this.ChooseDecryptedFileDestinationButton_Click);
            // 
            // labelChooseDecryptedFileDestination
            // 
            this.labelChooseDecryptedFileDestination.AutoSize = true;
            this.labelChooseDecryptedFileDestination.Location = new System.Drawing.Point(10, 64);
            this.labelChooseDecryptedFileDestination.Name = "labelChooseDecryptedFileDestination";
            this.labelChooseDecryptedFileDestination.Size = new System.Drawing.Size(191, 15);
            this.labelChooseDecryptedFileDestination.TabIndex = 3;
            this.labelChooseDecryptedFileDestination.Text = "Choose Decrypted File Destination:";
            // 
            // labelFileToDecrypt
            // 
            this.labelFileToDecrypt.AutoSize = true;
            this.labelFileToDecrypt.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelFileToDecrypt.Location = new System.Drawing.Point(30, 40);
            this.labelFileToDecrypt.Name = "labelFileToDecrypt";
            this.labelFileToDecrypt.Size = new System.Drawing.Size(103, 15);
            this.labelFileToDecrypt.TabIndex = 2;
            this.labelFileToDecrypt.Text = "labelFileToDecrypt";
            // 
            // buttonChooseFileToDecrypt
            // 
            this.buttonChooseFileToDecrypt.Location = new System.Drawing.Point(145, 10);
            this.buttonChooseFileToDecrypt.Name = "buttonChooseFileToDecrypt";
            this.buttonChooseFileToDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseFileToDecrypt.TabIndex = 1;
            this.buttonChooseFileToDecrypt.Text = "Choose";
            this.buttonChooseFileToDecrypt.UseVisualStyleBackColor = true;
            this.buttonChooseFileToDecrypt.Click += new System.EventHandler(this.ChooseFileToDecryptButton_Click);
            // 
            // labelChooseFileToDecrypt
            // 
            this.labelChooseFileToDecrypt.AutoSize = true;
            this.labelChooseFileToDecrypt.Location = new System.Drawing.Point(10, 14);
            this.labelChooseFileToDecrypt.Name = "labelChooseFileToDecrypt";
            this.labelChooseFileToDecrypt.Size = new System.Drawing.Size(129, 15);
            this.labelChooseFileToDecrypt.TabIndex = 0;
            this.labelChooseFileToDecrypt.Text = "Choose File to Decrypt:";
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.Filter = "*.txt";
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Changed);
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.FileSystemWatcher_Created);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 411);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBoxFSWOptions);
            this.Controls.Add(this.comboBoxChooseAlgorithm);
            this.Controls.Add(this.labelChooseAlgorithm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cryptosystem with File System Watcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBoxFSWOptions.ResumeLayout(false);
            this.groupBoxFSWOptions.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageEncryption.ResumeLayout(false);
            this.tabPageEncryption.PerformLayout();
            this.tabPageDecryption.ResumeLayout(false);
            this.tabPageDecryption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxChooseAlgorithm;
        private System.Windows.Forms.GroupBox groupBoxFSWOptions;
        private System.Windows.Forms.Label labelDestinationFolder;
        private System.Windows.Forms.Button buttonChooseDestinationFolder;
        private System.Windows.Forms.Label labelChooseDestinationFolder;
        private System.Windows.Forms.Label labelTargetFolder;
        private System.Windows.Forms.Button buttonChooseTargetFolder;
        private System.Windows.Forms.Label labelChooseTargetFolder;
        private System.Windows.Forms.CheckBox checkBoxTurnOnOff;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageEncryption;
        private System.Windows.Forms.Button buttonEncryptFile;
        private System.Windows.Forms.Label labelFileToEncrypt;
        private System.Windows.Forms.Button buttonChooseFileToEncrypt;
        private System.Windows.Forms.Label labelChooseFileToEncrypt;
        private System.Windows.Forms.TabPage tabPageDecryption;
        private System.Windows.Forms.Button buttonDecryptFile;
        private System.Windows.Forms.Label labelDecryptedFileDestination;
        private System.Windows.Forms.Button buttonChooseDecryptedFileDestination;
        private System.Windows.Forms.Label labelChooseDecryptedFileDestination;
        private System.Windows.Forms.Label labelFileToDecrypt;
        private System.Windows.Forms.Button buttonChooseFileToDecrypt;
        private System.Windows.Forms.Label labelChooseFileToDecrypt;
        private System.IO.FileSystemWatcher fileSystemWatcher;
    }
}

