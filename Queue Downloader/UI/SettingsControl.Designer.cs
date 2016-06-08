namespace Crazy_Software.Downloaders.Queue_Downloader.UI
{
    partial class SettingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDefaultDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNotification = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDelete = new System.Windows.Forms.ComboBox();
            this.numBufferSize = new Crazy_Software.Downloaders.Queue_Downloader.UI.StrictNumericUpDown();
            this.numMaxSpeed = new Crazy_Software.Downloaders.Queue_Downloader.UI.StrictNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(290, 51);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(55, 22);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDefaultDirectory
            // 
            this.txtDefaultDirectory.Location = new System.Drawing.Point(3, 51);
            this.txtDefaultDirectory.Name = "txtDefaultDirectory";
            this.txtDefaultDirectory.Size = new System.Drawing.Size(281, 22);
            this.txtDefaultDirectory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Default Directory :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.MaximumSize = new System.Drawing.Size(338, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "This is the default selected directory when you open the add dialog.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.MaximumSize = new System.Drawing.Size(338, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "This is the maximum download speed allowed in kilobytes per second. Set it to 0 f" +
    "or no limit.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max Speed :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "KB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 145);
            this.label6.MaximumSize = new System.Drawing.Size(338, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(331, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "This is the buffer size in kilobytes. Don\'t touch this, unless you know what you " +
    "are doing.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Buffer Size :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "KB";
            // 
            // cmbNotification
            // 
            this.cmbNotification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotification.FormattingEnabled = true;
            this.cmbNotification.Items.AddRange(new object[] {
            "Always show notifications",
            "Only show when completed",
            "Never show notifications"});
            this.cmbNotification.Location = new System.Drawing.Point(88, 243);
            this.cmbNotification.Name = "cmbNotification";
            this.cmbNotification.Size = new System.Drawing.Size(200, 21);
            this.cmbNotification.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 209);
            this.label9.MaximumSize = new System.Drawing.Size(338, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(337, 26);
            this.label9.TabIndex = 14;
            this.label9.Text = "This is when you want the program to show notifications in the taskbar.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Notifications :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 272);
            this.label11.MaximumSize = new System.Drawing.Size(338, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(338, 26);
            this.label11.TabIndex = 16;
            this.label11.Text = "This is if you want to delete the current downloading file, when the download has" +
    " been skipped or stopped.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 309);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Delete Files :";
            // 
            // cmbDelete
            // 
            this.cmbDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDelete.FormattingEnabled = true;
            this.cmbDelete.Items.AddRange(new object[] {
            "On skip or stop",
            "Only on skip",
            "Only on stop",
            "Never delete files"});
            this.cmbDelete.Location = new System.Drawing.Point(81, 306);
            this.cmbDelete.Name = "cmbDelete";
            this.cmbDelete.Size = new System.Drawing.Size(200, 21);
            this.cmbDelete.TabIndex = 5;
            // 
            // numBufferSize
            // 
            this.numBufferSize.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numBufferSize.Location = new System.Drawing.Point(77, 179);
            this.numBufferSize.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBufferSize.Name = "numBufferSize";
            this.numBufferSize.Size = new System.Drawing.Size(100, 22);
            this.numBufferSize.TabIndex = 3;
            this.numBufferSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numMaxSpeed
            // 
            this.numMaxSpeed.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numMaxSpeed.Location = new System.Drawing.Point(78, 115);
            this.numMaxSpeed.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numMaxSpeed.Name = "numMaxSpeed";
            this.numMaxSpeed.Size = new System.Drawing.Size(100, 22);
            this.numMaxSpeed.TabIndex = 2;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDelete);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbNotification);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numBufferSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numMaxSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDefaultDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(348, 330);
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDefaultDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private StrictNumericUpDown numMaxSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private StrictNumericUpDown numBufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbNotification;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDelete;
    }
}
