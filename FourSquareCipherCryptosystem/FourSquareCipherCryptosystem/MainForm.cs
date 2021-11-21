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
                this.ChangeEnabledStateOfControls();

                this.fileSystemWatcher.EnableRaisingEvents = !this.fileSystemWatcher.EnableRaisingEvents;
            }
        }

        private void ChooseTargetFolderButton_Click(object sender, EventArgs e) =>
            this.labelTargetFolder.Text = MainForm.GetSelectedPathFromFolderBrowserDialog();

        private void ChooseDestinationFolderButton_Click(object sender, EventArgs e) =>
            this.labelDestinationFolder.Text = MainForm.GetSelectedPathFromFolderBrowserDialog();
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
        #endregion Method(s)
    }
}
