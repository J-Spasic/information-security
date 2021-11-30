using System;
using System.Windows.Forms;

namespace FourSquareCipherCryptosystem
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
            this.SetTextOfFolderAndFileLabelsToEmptyString();
            this.DisableCryptoButtons();
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
        /// </summary>
        private void ChangeEnabledStateOfControls()
        {
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
        /// Disables the file encryption and decryption buttons.
        /// </summary>
        private void DisableCryptoButtons()
        {
            this.buttonEncryptFile.Enabled = false;
            this.buttonDecryptFile.Enabled = false;
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
        #endregion Method(s)
    }
}
