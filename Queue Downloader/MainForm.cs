using System;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Syroot.Windows.IO;
using Crazy_Software.Downloaders.File_Downloader;

namespace Crazy_Software.Downloaders.Queue_Downloader
{
    public partial class MainForm : Form
    {
        private static string _logFilePath = Path.Combine(new KnownFolder(KnownFolderType.RoamingAppData).Path, @"Crazy Software\Queue Downloader\Log.txt");
        private int _completedFiles;
        private long _bytesRead, _totalBytes;
        private bool _clickedStop;
        private object _pauseResumeSender;

        private List<string> _urlAddresses = new List<string>();
        private List<string> _fileNames = new List<string>();

        private StringBuilder _log = new StringBuilder();
        private Timer _timerStatus = new Timer();
        private Stopwatch _watchElapsed = new Stopwatch();
        private FileDownloader _fileDownloader = new FileDownloader();

        public MainForm()
        {
            InitializeComponent();

            _timerStatus.Interval = 1000;
            _timerStatus.Tick += new EventHandler(TimerTick);

            _fileDownloader.MaxSpeed = Settings.MaxSpeed;
            _fileDownloader.BufferSize = Settings.BufferSize;
            _fileDownloader.OnDownloadProgressChanged += new OnDownloadProgressChangedEventHandler(OnDownloadProgressChanged);
            _fileDownloader.OnDownloadStarted += new OnDownloadStartedEventHandler(OnDownloadStarted);
            _fileDownloader.OnDownloadPaused += new OnDownloadPausedEventHandler(OnDownloadPaused);
            _fileDownloader.OnDownloadResumed += new OnDownloadResumedEventHandler(OnDownloadResumed);
            _fileDownloader.OnDownloadCompleted += new OnDownloadCompletedEventHandler(OnDownloadCompleted);
            _fileDownloader.OnDownloadCancelled += new OnDownloadCancelledEventHandler(OnDownloadCancelled);

            AddLog("Program started.");
        }

        private int _amountFiles
        {
            get { return (_urlAddresses.Count + _fileNames.Count) / 2; }
        }

        private void OnDownloadProgressChanged(object sender, OnDownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                _bytesRead = e.BytesRead;
                _totalBytes = e.TotalBytes;

                statusControl.BytesRead = e.BytesRead;
                statusControl.TotalBytes = e.TotalBytes;
                statusControl.ProgressPercentage = e.ProgressPercentage;

                prgDownload.Value = (int)((e.BytesRead * 1000000) / e.TotalBytes);
                TaskbarProgress.SetValue(this.Handle, (e.BytesRead * 1000) / e.TotalBytes, 1000);
            }));
        }

        private void OnDownloadStarted(object sender, EventArgs e)
        {
            UpdateControls(true);
            UpdateListControls();
            statusControl.Status = "Downloading...";
            statusControl._Name = Path.GetFileName(_fileNames[_completedFiles]);
            ntfIcon.Text = "Queue Downloader" + Environment.NewLine + "Downloading";

            if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications && _completedFiles == 0)
                ntfIcon.ShowBalloonTip(5000, "Started download", string.Format("The download has been started.", _completedFiles), ToolTipIcon.Info);

            AddLog(string.Format("Reading data from: {0}", _urlAddresses[_completedFiles]));
            AddLog(string.Format("Saving as: {0}", _fileNames[_completedFiles]));
        }

        private void OnDownloadPaused(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                _watchElapsed.Stop();
                _timerStatus.Stop();
                btnPauseResume.Text = "&Resume";
                conMenuClickPauseResume.Text = "Resume";
                statusControl.Status = "Download paused";

                if (_pauseResumeSender is Button)
                    statusStripHint.Text = "Resume the download";

                ntfIcon.Text = "Queue Downloader" + Environment.NewLine + "Paused";

                if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                    ntfIcon.ShowBalloonTip(5000, "Paused download", string.Format("The download has been paused.", _completedFiles), ToolTipIcon.Info);

                AddLog("The download has been paused.");
                TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Paused);
            }));
        }

        private void OnDownloadResumed(object sender, EventArgs e)
        {
            _watchElapsed.Start();
            _timerStatus.Start();
            btnPauseResume.Text = "&Pause";
            conMenuClickPauseResume.Text = "Pause";
            statusControl.Status = "Downloading...";

            if (_pauseResumeSender is Button)
                statusStripHint.Text = "Pause the download";

            ntfIcon.Text = "Queue Downloader" + Environment.NewLine + "Downloading";

            if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                ntfIcon.ShowBalloonTip(5000, "Resumed download", string.Format("The download has been resumed.", _completedFiles), ToolTipIcon.Info);

            AddLog("The download has been resumed.");
            TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal);
        }

        private void OnDownloadCompleted(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                _completedFiles++;

                if (_completedFiles < _amountFiles)
                {
                    if (Settings.NotificationLevel != NotificationLevel.NoNotifications)
                        ntfIcon.ShowBalloonTip(5000, "Starting next download", string.Format("Download {0} has been completed, starting next download...", _completedFiles), ToolTipIcon.Info);

                    AddLog(string.Format("Download {0} has been completed.", _completedFiles));
                    StartNextDownload();
                }
                else
                {
                    UpdateControls(false);
                    UpdateListControls();
                    statusControl.Status = _amountFiles == 1 ? "Download completed!" : "Downloads completed!";
                    ntfIcon.Text = "Queue Downloader" + Environment.NewLine + "Completed";

                    if (Settings.NotificationLevel != NotificationLevel.NoNotifications)
                        ntfIcon.ShowBalloonTip(5000, _amountFiles == 1 ? "Download completed" : "Downloads completed", _amountFiles == 1 ? "The download has been completed!" : "The downloads have been completed!", ToolTipIcon.Info);

                    AddLog(_amountFiles == 1 ? "The download has been completed." : "All downloads have been completed.");

                    if (menuCheckShutdown.Checked)
                    {
                        AddLog("Shutting down computer...");
                        Process.Start("shutdown.exe", "/s /t 3");
                    }

                    if (menuCheckExit.Checked)
                        this.Close();
                }
            }));
        }

        private void OnDownloadCancelled(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (_completedFiles < _amountFiles)
                {
                    if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                        ntfIcon.ShowBalloonTip(5000, "Skipped download", string.Format("The download has been skipped, starting next download...", _completedFiles), ToolTipIcon.Info);

                    AddLog(string.Format("Skipping download: {0}", _urlAddresses[_completedFiles - 1]));

                    if (Settings.DeleteLevel == DeleteLevel.DeleteOnSkipAndStop || Settings.DeleteLevel == DeleteLevel.DeleteOnSkip)
                        File.Delete(_fileNames[_completedFiles - 1]);

                    StartNextDownload();
                }
                else
                {
                    UpdateControls(false);
                    UpdateListControls();
                    statusControl.Status = "Download stopped";
                    ntfIcon.Text = "Queue Downloader" + Environment.NewLine + "Stopped";

                    if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                        ntfIcon.ShowBalloonTip(5000, "Stopped download", string.Format("The download has been stopped.", _completedFiles), ToolTipIcon.Info);

                    AddLog("The download has been stopped.");

                    if (Settings.DeleteLevel == DeleteLevel.DeleteOnSkipAndStop || Settings.DeleteLevel == DeleteLevel.DeleteOnSkip && !_clickedStop || Settings.DeleteLevel == DeleteLevel.DeleteOnStop && _clickedStop)
                        File.Delete(_fileNames[_completedFiles - 1]);
                }
            }));
        }

        private void StartNextDownload()
        {
            statusControl.Status = "Starting next download...";
            AddLog("Starting next download...");
            _fileDownloader.DownloadFile(_urlAddresses[_completedFiles], _fileNames[_completedFiles]);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            long transferRate = (long)(_watchElapsed.Elapsed.TotalSeconds == 0 ? 0 : _bytesRead / (_watchElapsed.Elapsed.TotalSeconds));
            statusControl.TimeLeft = (int)(transferRate == 0 ? 0 : (_totalBytes - _bytesRead) / transferRate);
            statusControl.TimeElapsed = (int)_watchElapsed.Elapsed.TotalSeconds;
            statusControl.TransferRate = transferRate;
        }

        private void ResetStatusHint()
        {
            if (_fileDownloader.State == DownloadState.Downloading)
                statusStripHint.Text = "Downloading";
            else if (_fileDownloader.State == DownloadState.Paused)
                statusStripHint.Text = "Paused";
            else if (_fileDownloader.State == DownloadState.Completed)
                statusStripHint.Text = "Completed";
            else if (_fileDownloader.State == DownloadState.Cancelled)
                statusStripHint.Text = "Stopped";
            else
                statusStripHint.Text = "Idle";
        }

        private void UpdateControls(bool isDownloading)
        {
            btnStart.Enabled = !isDownloading;
            conMenuClickStart.Enabled = !isDownloading;
            btnPauseResume.Enabled = isDownloading;
            btnPauseResume.Text = "&Pause";
            conMenuClickPauseResume.Enabled = isDownloading;
            conMenuClickPauseResume.Text = "Pause";
            btnSkip.Enabled = isDownloading;
            conMenuClickSkip.Enabled = isDownloading;
            btnStop.Enabled = isDownloading;
            conMenuClickStop.Enabled = isDownloading;

            statusControl.SetFilesCompleted(_completedFiles, _amountFiles);

            if (isDownloading)
            {
                TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.Normal);
                _watchElapsed.Reset();
                _watchElapsed.Start();
                _timerStatus.Start();
            }
            else
            {
                TaskbarProgress.SetState(this.Handle, TaskbarProgress.TaskbarStates.NoProgress);
                _watchElapsed.Stop();
                _timerStatus.Stop();
                ResetStatusHint();
            }
        }

        private void UpdateListControls()
        {
            btnClear.Enabled = !_fileDownloader.IsDownloading && !_fileDownloader.IsPaused && lstDownload.Items.Count != 0;

            if (lstDownload.Items.Count != 0 && lstDownload.SelectedItems.Count != 0)
            {
                btnRemove.Enabled = _fileDownloader.IsDownloading || _fileDownloader.IsPaused ? (lstDownload.SelectedIndex != _completedFiles) : true;
                btnEdit.Enabled = _fileDownloader.IsDownloading || _fileDownloader.IsPaused ? (lstDownload.SelectedIndex != _completedFiles) : true;
                btnUp.Enabled = lstDownload.SelectedIndex != 0 && (_fileDownloader.IsDownloading || _fileDownloader.IsPaused ? (lstDownload.SelectedIndex != _completedFiles && lstDownload.SelectedIndex - 1 != _completedFiles) : true);
                btnDown.Enabled = lstDownload.SelectedIndex != lstDownload.Items.Count - 1 && (_fileDownloader.IsDownloading || _fileDownloader.IsPaused ? (lstDownload.SelectedIndex != _completedFiles && lstDownload.SelectedIndex + 1 != _completedFiles) : true);
            }
            else
            {
                btnRemove.Enabled = false;
                btnEdit.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
        }

        private void AddLog(string input)
        {
            string appendText = string.Format("{0} - {1}", DateTime.Now, input);
            _log.AppendLine(appendText);
            rchTextLog.Text = _log.ToString();
            rchTextLog.SelectionStart = rchTextLog.Text.Length;
            rchTextLog.ScrollToCaret();

            using (var fileStream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
            using (var logWriter = new StreamWriter(fileStream))
                logWriter.WriteLine(appendText);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_fileDownloader.IsDownloading || _fileDownloader.IsPaused)
            {
                if (MessageBox.Show("Are you sure you want to exit while a download is in progress?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
                else
                {
                    _fileDownloader.Stop();
                    AddLog("Program closed.");
                    ntfIcon.Visible = false;
                }
            }
            else
            {
                AddLog("Program closed.");
                ntfIcon.Visible = false;
            }
        }

        private void lstDownload_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListControls();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddEditForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _urlAddresses.Add(addForm.UrlAddress);
                _fileNames.Add(addForm.FileName);
                lstDownload.Items.Add(addForm.UrlAddress);
                UpdateListControls();

                if (_fileDownloader.IsDownloading || _fileDownloader.IsPaused)
                    statusControl.SetFilesCompleted(_completedFiles, _amountFiles);

                AddLog(string.Format("Added file to the queue: {0}", addForm.UrlAddress));
                AddLog(string.Format("The file will be saved as: {0}", addForm.FileName));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string urlAddress = _urlAddresses[lstDownload.SelectedIndex];
            int selected = lstDownload.SelectedIndex;
            _urlAddresses.RemoveAt(lstDownload.SelectedIndex);
            _fileNames.RemoveAt(lstDownload.SelectedIndex);
            lstDownload.Items.RemoveAt(lstDownload.SelectedIndex);
            lstDownload.SelectedIndex = selected - 1;
            UpdateListControls();

            if (selected < _completedFiles && (_fileDownloader.IsDownloading || _fileDownloader.IsPaused))
                _completedFiles--;

            if (_fileDownloader.IsDownloading || _fileDownloader.IsPaused)
                statusControl.SetFilesCompleted(_completedFiles, _amountFiles);

            AddLog(string.Format("Removed file from the queue: {0}", urlAddress));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editForm = new AddEditForm(_urlAddresses[lstDownload.SelectedIndex], _fileNames[lstDownload.SelectedIndex]);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _urlAddresses[lstDownload.SelectedIndex] = editForm.UrlAddress;
                _fileNames[lstDownload.SelectedIndex] = editForm.FileName;
                lstDownload.Items[lstDownload.SelectedIndex] = editForm.UrlAddress;
                UpdateListControls();
                AddLog(string.Format("Changed url address to: {0}", editForm.UrlAddress));
                AddLog(string.Format("The file will be saved as: {0}", editForm.FileName));
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _urlAddresses.Clear();
            _fileNames.Clear();
            lstDownload.Items.Clear();
            UpdateListControls();
            AddLog("Cleared the queue.");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var oldUrlAddress = _urlAddresses[lstDownload.SelectedIndex];
            var oldFileName = _fileNames[lstDownload.SelectedIndex];
            _urlAddresses[lstDownload.SelectedIndex] = _urlAddresses[lstDownload.SelectedIndex - 1];
            _urlAddresses[lstDownload.SelectedIndex - 1] = oldUrlAddress;
            _fileNames[lstDownload.SelectedIndex] = _fileNames[lstDownload.SelectedIndex - 1];
            _fileNames[lstDownload.SelectedIndex - 1] = oldFileName;
            lstDownload.Items[lstDownload.SelectedIndex] = lstDownload.Items[lstDownload.SelectedIndex - 1];
            lstDownload.Items[lstDownload.SelectedIndex - 1] = oldUrlAddress;
            lstDownload.SelectedIndex = lstDownload.SelectedIndex - 1;
            AddLog(string.Format("Moved file up in the queue: {0}", oldUrlAddress));
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var oldUrlAddress = _urlAddresses[lstDownload.SelectedIndex];
            var oldFileName = _fileNames[lstDownload.SelectedIndex];
            _urlAddresses[lstDownload.SelectedIndex] = _urlAddresses[lstDownload.SelectedIndex + 1];
            _urlAddresses[lstDownload.SelectedIndex + 1] = oldUrlAddress;
            _fileNames[lstDownload.SelectedIndex] = _fileNames[lstDownload.SelectedIndex + 1];
            _fileNames[lstDownload.SelectedIndex + 1] = oldFileName;
            lstDownload.Items[lstDownload.SelectedIndex] = lstDownload.Items[lstDownload.SelectedIndex + 1];
            lstDownload.Items[lstDownload.SelectedIndex + 1] = oldUrlAddress;
            lstDownload.SelectedIndex = lstDownload.SelectedIndex + 1;
            AddLog(string.Format("Moved file down in the queue: {0}", oldUrlAddress));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lstDownload.Items.Count == 0)
                MessageBox.Show("There are no downloads added to the queue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                statusControl.Status = "Starting download...";
                AddLog("Starting download...");
                _completedFiles = 0;
                _fileDownloader.DownloadFile(_urlAddresses[0], _fileNames[0]);
            }
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            _pauseResumeSender = sender;

            if (btnPauseResume.Text == "&Pause")
            {
                statusControl.Status = "Pausing download...";
                _fileDownloader.Pause();
            }
            else
            {
                try
                {
                    statusControl.Status = "Resuming download...";
                    AddLog("Resuming download...");
                    _fileDownloader.Resume();
                }
                catch (FileNotFoundException)
                {
                    var result = MessageBox.Show("The file you wanted to resume doesn't exist. Click on ignore to skip the download or click on abort to stop the download.", "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);

                    if (result == DialogResult.Abort)
                        btnStop_Click(null, new EventArgs());
                    else if (result == DialogResult.Retry)
                        btnPauseResume_Click(null, new EventArgs());
                    else
                        btnSkip_Click(null, new EventArgs());
                }
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _clickedStop = false;
            _completedFiles++;
            statusControl.Status = _completedFiles == _amountFiles ? "Stopping download..." : "Skipping download...";
            _fileDownloader.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _clickedStop = true;
            _completedFiles = _amountFiles;
            statusControl.Status = "Stopping download...";
            _fileDownloader.Stop();
        }

        private void menuClickHide_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (Settings.NotificationLevel == NotificationLevel.ShowAllNotifications)
                ntfIcon.ShowBalloonTip(5000, "Still running", "I am still running in the background. Double-click on this icon to show the program.", ToolTipIcon.Info);
        }

        private void menuClickExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuClickSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                Settings.Save(settingsForm.DefaultDirectory, settingsForm.MaxSpeed, settingsForm.BufferSize, settingsForm.NotificationLevel, settingsForm.DeleteLevel);
                AddLog("The settings have been saved.");
            }
        }

        private void menuClickAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void conMenuLogClickSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                FileName = "Log.txt",
                Filter = "Text Files|*.txt|All Files|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (var logStream = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] _logBytes = Encoding.UTF8.GetBytes(_log.ToString());
                    logStream.Write(_logBytes, 0, _logBytes.Length);
                }
            }
        }

        private void conMenuLogClickClear_Click(object sender, EventArgs e)
        {
            _log.Clear();
            rchTextLog.Clear();
        }

        private void conMenuClickShow_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void conMenuClickStart_Click(object sender, EventArgs e)
        {
            btnStart_Click(sender, new EventArgs());
        }

        private void conMenuClickPauseResume_Click(object sender, EventArgs e)
        {
            btnPauseResume_Click(sender, new EventArgs());
        }

        private void conMenuClickSkip_Click(object sender, EventArgs e)
        {
            btnSkip_Click(sender, new EventArgs());
        }

        private void conMenuClickStop_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, new EventArgs());
        }

        private void conMenuClickExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ntfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.Show();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ResetStatusHint();
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Start the download";
        }

        private void btnPauseResume_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = btnPauseResume.Text == "&Pause" ? "Pause the download" : "Resume the download";
        }

        private void btnSkip_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Skip the download";
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Stop the download";
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Add a download";
        }

        private void btnRemove_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Remove the download";
        }

        private void btnEdit_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Edit the download";
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Clear the queue";
        }

        private void btnUp_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Move the download up";
        }

        private void btnDown_MouseEnter(object sender, EventArgs e)
        {
            statusStripHint.Text = "Move the download down";
        }
    }
}
