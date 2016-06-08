namespace Crazy_Software.Downloaders.Queue_Downloader
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuClickFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickHide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClickExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckShutdown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClickSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClickAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.statusControl = new Crazy_Software.Downloaders.Queue_Downloader.UI.StatusControl();
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lstDownload = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.rchTextLog = new System.Windows.Forms.RichTextBox();
            this.conMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conMenuLogClickSave = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuLogClickClear = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripHint = new System.Windows.Forms.ToolStripStatusLabel();
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conMenuClickShow = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.conMenuClickStart = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuClickPauseResume = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuClickSkip = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuClickStop = new System.Windows.Forms.ToolStripMenuItem();
            this.conMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conMenuClickExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ntfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.conMenuLog.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClickFile,
            this.menuClickOptions,
            this.menuClickHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(484, 24);
            this.menuStrip.TabIndex = 11;
            // 
            // menuClickFile
            // 
            this.menuClickFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClickHide,
            this.menuSeparator1,
            this.menuClickExit});
            this.menuClickFile.Name = "menuClickFile";
            this.menuClickFile.Size = new System.Drawing.Size(37, 20);
            this.menuClickFile.Text = "&File";
            // 
            // menuClickHide
            // 
            this.menuClickHide.Name = "menuClickHide";
            this.menuClickHide.Size = new System.Drawing.Size(187, 22);
            this.menuClickHide.Text = "Minimize to taskbar...";
            this.menuClickHide.Click += new System.EventHandler(this.menuClickHide_Click);
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // menuClickExit
            // 
            this.menuClickExit.Name = "menuClickExit";
            this.menuClickExit.Size = new System.Drawing.Size(187, 22);
            this.menuClickExit.Text = "Exit";
            this.menuClickExit.Click += new System.EventHandler(this.menuClickExit_Click);
            // 
            // menuClickOptions
            // 
            this.menuClickOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCheckShutdown,
            this.menuCheckExit,
            this.menuSeparator2,
            this.menuClickSettings});
            this.menuClickOptions.Name = "menuClickOptions";
            this.menuClickOptions.Size = new System.Drawing.Size(61, 20);
            this.menuClickOptions.Text = "&Options";
            // 
            // menuCheckShutdown
            // 
            this.menuCheckShutdown.CheckOnClick = true;
            this.menuCheckShutdown.Name = "menuCheckShutdown";
            this.menuCheckShutdown.Size = new System.Drawing.Size(212, 22);
            this.menuCheckShutdown.Text = "Shut down on completion";
            // 
            // menuCheckExit
            // 
            this.menuCheckExit.CheckOnClick = true;
            this.menuCheckExit.Name = "menuCheckExit";
            this.menuCheckExit.Size = new System.Drawing.Size(212, 22);
            this.menuCheckExit.Text = "Exit on completion";
            // 
            // menuSeparator2
            // 
            this.menuSeparator2.Name = "menuSeparator2";
            this.menuSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // menuClickSettings
            // 
            this.menuClickSettings.Name = "menuClickSettings";
            this.menuClickSettings.Size = new System.Drawing.Size(212, 22);
            this.menuClickSettings.Text = "Settings...";
            this.menuClickSettings.Click += new System.EventHandler(this.menuClickSettings_Click);
            // 
            // menuClickHelp
            // 
            this.menuClickHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClickAbout});
            this.menuClickHelp.Name = "menuClickHelp";
            this.menuClickHelp.Size = new System.Drawing.Size(44, 20);
            this.menuClickHelp.Text = "&Help";
            // 
            // menuClickAbout
            // 
            this.menuClickAbout.Name = "menuClickAbout";
            this.menuClickAbout.Size = new System.Drawing.Size(116, 22);
            this.menuClickAbout.Text = "About...";
            this.menuClickAbout.Click += new System.EventHandler(this.menuClickAbout_Click);
            // 
            // grpStatus
            // 
            this.grpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatus.Controls.Add(this.statusControl);
            this.grpStatus.Location = new System.Drawing.Point(12, 27);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(460, 190);
            this.grpStatus.TabIndex = 13;
            this.grpStatus.TabStop = false;
            // 
            // statusControl
            // 
            this.statusControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusControl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusControl.Location = new System.Drawing.Point(6, 13);
            this.statusControl.Name = "statusControl";
            this.statusControl.Size = new System.Drawing.Size(448, 171);
            this.statusControl.TabIndex = 0;
            // 
            // prgDownload
            // 
            this.prgDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgDownload.Location = new System.Drawing.Point(12, 223);
            this.prgDownload.Maximum = 1000000;
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(460, 22);
            this.prgDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgDownload.TabIndex = 15;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 251);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Enabled = false;
            this.btnPauseResume.Location = new System.Drawing.Point(113, 251);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(95, 28);
            this.btnPauseResume.TabIndex = 1;
            this.btnPauseResume.Text = "&Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            this.btnPauseResume.MouseEnter += new System.EventHandler(this.btnPauseResume_MouseEnter);
            this.btnPauseResume.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkip.Enabled = false;
            this.btnSkip.Location = new System.Drawing.Point(276, 251);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(95, 28);
            this.btnSkip.TabIndex = 2;
            this.btnSkip.Text = "S&kip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            this.btnSkip.MouseEnter += new System.EventHandler(this.btnSkip_MouseEnter);
            this.btnSkip.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(377, 251);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "S&top";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.MouseEnter += new System.EventHandler(this.btnStop_MouseEnter);
            this.btnStop.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // lstDownload
            // 
            this.lstDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDownload.FormattingEnabled = true;
            this.lstDownload.IntegralHeight = false;
            this.lstDownload.Location = new System.Drawing.Point(12, 285);
            this.lstDownload.Name = "lstDownload";
            this.lstDownload.Size = new System.Drawing.Size(460, 160);
            this.lstDownload.TabIndex = 10;
            this.lstDownload.SelectedIndexChanged += new System.EventHandler(this.lstDownload_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 451);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseEnter += new System.EventHandler(this.btnAdd_MouseEnter);
            this.btnAdd.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(407, 451);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(65, 23);
            this.btnDown.TabIndex = 9;
            this.btnDown.Text = "Do&wn";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            this.btnDown.MouseEnter += new System.EventHandler(this.btnDown_MouseEnter);
            this.btnDown.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(336, 451);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(65, 23);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "&Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            this.btnUp.MouseEnter += new System.EventHandler(this.btnUp_MouseEnter);
            this.btnUp.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(265, 451);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(154, 451);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "E&dit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.MouseEnter += new System.EventHandler(this.btnEdit_MouseEnter);
            this.btnEdit.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(83, 451);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(65, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "R&emove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.MouseEnter += new System.EventHandler(this.btnRemove_MouseEnter);
            this.btnRemove.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // rchTextLog
            // 
            this.rchTextLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rchTextLog.ContextMenuStrip = this.conMenuLog;
            this.rchTextLog.Location = new System.Drawing.Point(12, 480);
            this.rchTextLog.Name = "rchTextLog";
            this.rchTextLog.ReadOnly = true;
            this.rchTextLog.Size = new System.Drawing.Size(460, 160);
            this.rchTextLog.TabIndex = 12;
            this.rchTextLog.Text = "";
            this.rchTextLog.WordWrap = false;
            // 
            // conMenuLog
            // 
            this.conMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMenuLogClickSave,
            this.conMenuLogClickClear});
            this.conMenuLog.Name = "conMenuLog";
            this.conMenuLog.Size = new System.Drawing.Size(108, 48);
            // 
            // conMenuLogClickSave
            // 
            this.conMenuLogClickSave.Name = "conMenuLogClickSave";
            this.conMenuLogClickSave.Size = new System.Drawing.Size(107, 22);
            this.conMenuLogClickSave.Text = "Save...";
            this.conMenuLogClickSave.Click += new System.EventHandler(this.conMenuLogClickSave_Click);
            // 
            // conMenuLogClickClear
            // 
            this.conMenuLogClickClear.Name = "conMenuLogClickClear";
            this.conMenuLogClickClear.Size = new System.Drawing.Size(107, 22);
            this.conMenuLogClickClear.Text = "Clear";
            this.conMenuLogClickClear.Click += new System.EventHandler(this.conMenuLogClickClear_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripHint});
            this.statusStrip.Location = new System.Drawing.Point(0, 648);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripHint
            // 
            this.statusStripHint.Name = "statusStripHint";
            this.statusStripHint.Size = new System.Drawing.Size(26, 17);
            this.statusStripHint.Text = "Idle";
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conMenuClickShow,
            this.conMenuSeparator1,
            this.conMenuClickStart,
            this.conMenuClickPauseResume,
            this.conMenuClickSkip,
            this.conMenuClickStop,
            this.conMenuSeparator2,
            this.conMenuClickExit});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(106, 148);
            // 
            // conMenuClickShow
            // 
            this.conMenuClickShow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conMenuClickShow.Name = "conMenuClickShow";
            this.conMenuClickShow.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickShow.Text = "Show";
            this.conMenuClickShow.Click += new System.EventHandler(this.conMenuClickShow_Click);
            // 
            // conMenuSeparator1
            // 
            this.conMenuSeparator1.Name = "conMenuSeparator1";
            this.conMenuSeparator1.Size = new System.Drawing.Size(102, 6);
            // 
            // conMenuClickStart
            // 
            this.conMenuClickStart.Name = "conMenuClickStart";
            this.conMenuClickStart.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickStart.Text = "Start";
            this.conMenuClickStart.Click += new System.EventHandler(this.conMenuClickStart_Click);
            // 
            // conMenuClickPauseResume
            // 
            this.conMenuClickPauseResume.Enabled = false;
            this.conMenuClickPauseResume.Name = "conMenuClickPauseResume";
            this.conMenuClickPauseResume.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickPauseResume.Text = "Pause";
            this.conMenuClickPauseResume.Click += new System.EventHandler(this.conMenuClickPauseResume_Click);
            // 
            // conMenuClickSkip
            // 
            this.conMenuClickSkip.Enabled = false;
            this.conMenuClickSkip.Name = "conMenuClickSkip";
            this.conMenuClickSkip.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickSkip.Text = "Skip";
            this.conMenuClickSkip.Click += new System.EventHandler(this.conMenuClickSkip_Click);
            // 
            // conMenuClickStop
            // 
            this.conMenuClickStop.Enabled = false;
            this.conMenuClickStop.Name = "conMenuClickStop";
            this.conMenuClickStop.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickStop.Text = "Stop";
            this.conMenuClickStop.Click += new System.EventHandler(this.conMenuClickStop_Click);
            // 
            // conMenuSeparator2
            // 
            this.conMenuSeparator2.Name = "conMenuSeparator2";
            this.conMenuSeparator2.Size = new System.Drawing.Size(102, 6);
            // 
            // conMenuClickExit
            // 
            this.conMenuClickExit.Name = "conMenuClickExit";
            this.conMenuClickExit.Size = new System.Drawing.Size(105, 22);
            this.conMenuClickExit.Text = "Exit";
            this.conMenuClickExit.Click += new System.EventHandler(this.conMenuClickExit_Click);
            // 
            // ntfIcon
            // 
            this.ntfIcon.ContextMenuStrip = this.conMenu;
            this.ntfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIcon.Icon")));
            this.ntfIcon.Text = "Queue Downloader\r\nIdle";
            this.ntfIcon.Visible = true;
            this.ntfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntfIcon_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 670);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.rchTextLog);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstDownload);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.prgDownload);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(460, 650);
            this.Name = "MainForm";
            this.Text = "Queue Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.conMenuLog.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.conMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuClickFile;
        private System.Windows.Forms.ToolStripMenuItem menuClickOptions;
        private System.Windows.Forms.ToolStripMenuItem menuClickHelp;
        private System.Windows.Forms.GroupBox grpStatus;
        private UI.StatusControl statusControl;
        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lstDownload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.RichTextBox rchTextLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripHint;
        private System.Windows.Forms.ToolStripMenuItem menuClickHide;
        private System.Windows.Forms.ToolStripSeparator menuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuClickExit;
        private System.Windows.Forms.ToolStripMenuItem menuCheckShutdown;
        private System.Windows.Forms.ToolStripMenuItem menuCheckExit;
        private System.Windows.Forms.ToolStripMenuItem menuClickAbout;
        private System.Windows.Forms.ContextMenuStrip conMenuLog;
        private System.Windows.Forms.ToolStripMenuItem conMenuLogClickSave;
        private System.Windows.Forms.ToolStripMenuItem conMenuLogClickClear;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickShow;
        private System.Windows.Forms.ToolStripSeparator conMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickStart;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickPauseResume;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickSkip;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickStop;
        private System.Windows.Forms.ToolStripSeparator conMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conMenuClickExit;
        private System.Windows.Forms.NotifyIcon ntfIcon;
        private System.Windows.Forms.ToolStripSeparator menuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuClickSettings;
    }
}

