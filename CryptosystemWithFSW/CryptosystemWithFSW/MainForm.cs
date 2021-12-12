using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using CryptosystemBusinessLogic.Algorithms;
using CryptosystemBusinessLogic.Services;

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

        private void ChooseAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxChooseAlgorithm.SelectedIndex == 0)
            {
                CryptoService.SetCryptoAlgorithm(new FourSquareCipher());
            }
        }

        private void TurnOnOffCheckBox_Click(object sender, EventArgs e)
        {
            bool doChangeState = true;

            if (this.checkBoxTurnOnOff.Checked)
            {
                if (!this.AreFoldersChosen())
                {
                    this.checkBoxTurnOnOff.Checked = false;

                    doChangeState = false;
                }
                else
                {
                    if (!this.fileSystemWatcher.Path.Equals(this.labelTargetFolder.Text))
                    {
                        this.fileSystemWatcher.Path = this.labelTargetFolder.Text;
                    }
                }
            }

            if (doChangeState)
            {
                this.checkBoxTurnOnOff.Text = (this.checkBoxTurnOnOff.Checked) ? "Turn Off FSW" :
                    "Turn On FSW";

                this.ChangeEnabledStateOfControls();

                this.fileSystemWatcher.EnableRaisingEvents = !this.fileSystemWatcher.EnableRaisingEvents;
            }
        }

        private void ChooseTargetFolderButton_Click(object sender, EventArgs e) =>
            this.labelTargetFolder.Text = MainForm.GetSelectedPathFromFolderBrowserDialog();

        private void ChooseDestinationFolderButton_Click(object sender, EventArgs e) =>
            this.labelDestinationFolder.Text = MainForm.GetSelectedPathFromFolderBrowserDialog();

        private void ChooseFileToEncryptButton_Click(object sender, EventArgs e)
        {
            this.labelFileToEncrypt.Text = MainForm.GetFileNameFromOpenFileDialog();

            this.buttonEncryptFile.Enabled = !this.labelFileToEncrypt.Text.Equals(string.Empty);
        }

        private void EncryptFileButton_Click(object sender, EventArgs e)
        {
            string filePath = this.labelFileToEncrypt.Text;
            string destinationFolderPath = this.labelDestinationFolder.Text;

            CryptoService.EncryptFile(filePath, destinationFolderPath);
        }

        private void ChooseFileToDecryptButton_Click(object sender, EventArgs e)
        {
            this.labelFileToDecrypt.Text = MainForm.GetFileNameFromOpenFileDialog();

            this.ChangeEnabledStateOfDecryptButton();
        }

        private void ChooseDecryptedFileDestinationButton_Click(object sender, EventArgs e)
        {
            this.labelDecryptedFileDestination.Text = MainForm.GetSelectedPathFromFolderBrowserDialog();

            this.ChangeEnabledStateOfDecryptButton();
        }

        private void DecryptFileButton_Click(object sender, EventArgs e)
        {
            string filePath = this.labelFileToDecrypt.Text;
            string destinationFolderPath = this.labelDecryptedFileDestination.Text;

            CryptoService.DecryptFile(filePath, destinationFolderPath);
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            string destinationFolderPath = this.labelDestinationFolder.Text;

            CryptoService.EncryptFile(filePath, destinationFolderPath);
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            string destinationFolderPath = this.labelDestinationFolder.Text;

            MainForm.WaitForFileToBeVisible(filePath);

            CryptoService.EncryptFile(filePath, destinationFolderPath);
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

        /// <summary>
        /// Checks if appropriate target and destination folders are chosen.
        /// It also notifies the user if the target or destination folder is not selected.
        /// </summary>
        /// <returns></returns>
        private bool AreFoldersChosen()
        {
            bool areFoldersChosen = true;

            if (this.labelTargetFolder.Text.Equals(string.Empty))
            {
                areFoldersChosen = false;

                MessageBox.Show("Please choose Target Folder to proceed." + "\n\n" +
                    "FSW will remain off.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.labelDestinationFolder.Text.Equals(string.Empty))
            {
                areFoldersChosen = false;

                MessageBox.Show("Please choose Destination Folder to proceed." + "\n\n" +
                    "FSW will remain off.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return areFoldersChosen;
        }

        /// <summary>
        /// Enables or disables buttons for target and destination folder and whole tab control.
        /// It also disables combo box used for algorithm selection.
        /// </summary>
        private void ChangeEnabledStateOfControls()
        {
            this.comboBoxChooseAlgorithm.Enabled = !this.comboBoxChooseAlgorithm.Enabled;

            this.buttonChooseTargetFolder.Enabled = !this.buttonChooseTargetFolder.Enabled;
            this.buttonChooseDestinationFolder.Enabled = !this.buttonChooseDestinationFolder.Enabled;

            this.tabControl.Enabled = !this.tabControl.Enabled;
        }

        /// <summary>
        /// Gets selected path from the folder browser dialog.
        /// </summary>
        /// <returns>Selected path if dialog result is OK; otherwise an empty string.</returns>
        private static string GetSelectedPathFromFolderBrowserDialog()
        {
            using var folderBrowserDialog = new FolderBrowserDialog()
            {
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (folderBrowserDialog.ShowDialog().Equals(DialogResult.OK))
            {
                return folderBrowserDialog.SelectedPath;
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets selected file name from the open file dialog.
        /// </summary>
        /// <returns>Selected file name if dialog result is OK; otherwise an empty string.</returns>
        private static string GetFileNameFromOpenFileDialog()
        {
            using var openFileDialog = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Enables or disables button used for file decryption.
        /// </summary>
        private void ChangeEnabledStateOfDecryptButton()
        {
            if (!this.labelFileToDecrypt.Text.Equals(string.Empty) &&
                !this.labelDecryptedFileDestination.Text.Equals(string.Empty))
            {
                this.buttonDecryptFile.Enabled = true;
            }
            else
            {
                this.buttonDecryptFile.Enabled = false;
            }
        }

        /// <summary>
        /// Prevents exceptions when the file is not yet visible.
        /// </summary>
        /// <param name="filePath">Full file path.</param>
        private static void WaitForFileToBeVisible(string filePath)
        {
            while (true)
            {
                try
                {
                    using var streamReader = new StreamReader(filePath);

                    break;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }
        }
        #endregion Method(s)
    }
}
