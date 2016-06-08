using System;
using System.IO;
using System.Windows.Forms;

namespace Crazy_Software.Downloaders.Queue_Downloader
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public string DefaultDirectory
        {
            get { return settingsControl.DefaultDirectory; }
        }

        public long MaxSpeed
        {
            get { return settingsControl.MaxSpeed; }
        }

        public byte[] BufferSize
        {
            get { return settingsControl.BufferSize; }
        }

        public NotificationLevel NotificationLevel
        {
            get { return settingsControl.NotificationLevel; }
        }

        public DeleteLevel DeleteLevel
        {
            get { return settingsControl.DeleteLevel; }
        }

        private bool HasWriteAccessToFolder(string folderPath)
        {
            try
            {
                using (var fileStream = File.Create(Path.Combine(folderPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose)) { }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settingsControl.DefaultDirectory))
                MessageBox.Show("The directory you have entered or selected is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!HasWriteAccessToFolder(settingsControl.DefaultDirectory))
                MessageBox.Show("You don't have access to the directory you have enetered or selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (settingsControl.MaxSpeed != Settings.MaxSpeed || settingsControl.BufferSize.Length != Settings.BufferSize.Length)
                    MessageBox.Show("Some of the settings will apply next time you start Queue Downloader.", "Apply on restart", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
