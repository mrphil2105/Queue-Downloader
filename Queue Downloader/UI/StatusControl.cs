using System;
using System.Windows.Forms;

namespace Crazy_Software.Downloaders.Queue_Downloader.UI
{
    public partial class StatusControl : UserControl
    {
        public StatusControl()
        {
            InitializeComponent();

            BytesRead = 0;
            TotalBytes = 0;
        }

        private string GetTimeFormat(int totalSeconds)
        {
            var _timeSpan = TimeSpan.FromSeconds(totalSeconds);

            if (totalSeconds < 60)
            {
                return _timeSpan.Seconds == 1 ? "1 Second" : string.Format("{0} Seconds", _timeSpan.Seconds);
            }
            else if (totalSeconds < 3600)
            {
                return (_timeSpan.Minutes == 1 ? "1 Minute and " : string.Format("{0} Minutes and ", _timeSpan.Minutes)) +
                    (_timeSpan.Seconds == 1 ? "1 Second" : string.Format("{0} Seconds", _timeSpan.Seconds));
            }
            else if (totalSeconds < 86400)
            {
                return (_timeSpan.Hours == 1 ? "1 Hour, " : string.Format("{0} Hours, ", _timeSpan.Hours)) +
                    (_timeSpan.Minutes == 1 ? "1 Minute and " : string.Format("{0} Minutes and ", _timeSpan.Minutes)) +
                    (_timeSpan.Seconds == 1 ? "1 Second" : string.Format("{0} Seconds", _timeSpan.Seconds));
            }
            else
            {
                return (_timeSpan.Days == 1 ? "1 Day, " : string.Format("{0} Days, ", _timeSpan.Days)) +
                    (_timeSpan.Hours == 1 ? "1 Hour, " : string.Format("{0} Hours, ", _timeSpan.Hours)) +
                    (_timeSpan.Minutes == 1 ? "1 Minute and " : string.Format("{0} Minutes and ", _timeSpan.Minutes)) +
                    (_timeSpan.Seconds == 1 ? "1 Second" : string.Format("{0} Seconds", _timeSpan.Seconds));
            }
        }

        public string Status
        {
            set { lblStatus.Text = value; }
        }

        public long BytesRead
        {
            set { lblDownloaded.Text = string.Format("{0:0.000} MB", (decimal)value / 1024m / 1024m); }
        }

        public long TotalBytes
        {
            set { lblTotalSize.Text = string.Format("{0:0.000} MB", (decimal)value / 1024m / 1024m); }
        }

        public int ProgressPercentage
        {
            set { lblProgress.Text = string.Format("{0} %", value); }
        }

        public int TimeLeft
        {
            set { lblTimeLeft.Text = GetTimeFormat(value); }
        }

        public int TimeElapsed
        {
            set { lblTimeElapsed.Text = GetTimeFormat(value); }
        }

        public long TransferRate
        {
            set { lblTransferRate.Text = string.Format("{0} KB / s", value / 1024); }
        }

        public string _Name
        {
            set { lblFileName.Text = value; }
        }

        public void SetFilesCompleted(int completedFiles, int amountFiles)
        {
            lblFilesCompleted.Text = string.Format("{0} out of {1} {2}", completedFiles, amountFiles, amountFiles == 1 ? "file" : "files");
        }
    }
}
