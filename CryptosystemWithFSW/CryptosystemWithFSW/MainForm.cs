using System;
using System.Windows.Forms;

namespace CryptosystemWithFSW
{
    public partial class MainForm : Form
    {
        #region Constructor(s)
        public MainForm()
        {
            this.InitializeComponent();
        }
        #endregion Constructor(s)

        #region Event(s)
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.comboBoxChooseAlgorithm.SelectedIndex = 0;

            this.SetTextOfFolderAndFileLabelsToEmptyString();
            this.DisableCryptoButtons();

            this.fileSystemWatcher.EnableRaisingEvents = false;
        }
        #endregion Event(s)

        #region Method(s)
        /// <summary>
        /// Sets Text property of labels used to display the folder and file path to an empty string.
        /// </summary>
        private void SetTextOfFolderAndFileLabelsToEmptyString()
        {
            this.labelTargetFolder.Text = string.Empty;
            this.labelDestinationFolder.Text = string.Empty;
            this.labelFileToEncrypt.Text = string.Empty;
            this.labelFileToDecrypt.Text = string.Empty;
            this.labelDecryptedFileDestination.Text = string.Empty;
        }

        /// <summary>
        /// Disables the file encryption and decryption buttons.
        /// </summary>
        private void DisableCryptoButtons()
        {
            this.buttonEncryptFile.Enabled = false;
            this.buttonDecryptFile.Enabled = false;
        }
        #endregion Method(s)
    }
}
