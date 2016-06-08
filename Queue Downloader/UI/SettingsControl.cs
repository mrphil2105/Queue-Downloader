using System;
using System.Windows.Forms;

namespace Crazy_Software.Downloaders.Queue_Downloader.UI
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            numBufferSize.Maximum = int.MaxValue / 1024 / 16;

            txtDefaultDirectory.Text = Settings.DefaultDirectory;
            numMaxSpeed.Value = Settings.MaxSpeed / 1024;
            numBufferSize.Value = Settings.BufferSize.Length / 1024;

            if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                cmbNotification.SelectedIndex = 0;
            else if (Settings.NotificationLevel == NotificationLevel.ShowImportantOnly)
                cmbNotification.SelectedIndex = 1;
            else
                cmbNotification.SelectedIndex = 2;

            if (Settings.DeleteLevel == DeleteLevel.DeleteOnSkipAndStop)
                cmbDelete.SelectedIndex = 0;
            else if (Settings.DeleteLevel == DeleteLevel.DeleteOnSkip)
                cmbDelete.SelectedIndex = 1;
            else if (Settings.DeleteLevel == DeleteLevel.DeleteOnStop)
                cmbDelete.SelectedIndex = 2;
            else
                cmbDelete.SelectedIndex = 3;
        }

        public string DefaultDirectory
        {
            get { return txtDefaultDirectory.Text; }
        }

        public long MaxSpeed
        {
            get { return (long)(numMaxSpeed.Value * 1024); }
        }

        public byte[] BufferSize
        {
            get { return new byte[(int)(numBufferSize.Value * 1024)]; }
        }

        public NotificationLevel NotificationLevel
        {
            get
            {
                NotificationLevel notificationLevel;

                if (cmbNotification.SelectedIndex == 0)
                    notificationLevel = NotificationLevel.ShowAllNotifications;
                else if (cmbNotification.SelectedIndex == 1)
                    notificationLevel = NotificationLevel.ShowImportantOnly;
                else
                    notificationLevel = NotificationLevel.NoNotifications;

                return notificationLevel;
            }
        }

        public DeleteLevel DeleteLevel
        {
            get
            {
                DeleteLevel deleteLevel;

                if (cmbDelete.SelectedIndex == 0)
                    deleteLevel = DeleteLevel.DeleteOnSkipAndStop;
                else if (cmbDelete.SelectedIndex == 1)
                    deleteLevel = DeleteLevel.DeleteOnSkip;
                else if (cmbDelete.SelectedIndex == 2)
                    deleteLevel = DeleteLevel.DeleteOnStop;
                else
                    deleteLevel = DeleteLevel.NoDelete;

                return deleteLevel;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
                txtDefaultDirectory.Text = dialog.SelectedPath;
        }
    }
}
