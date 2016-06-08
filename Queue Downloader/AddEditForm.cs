using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Windows.Forms;

namespace Crazy_Software.Downloaders.Queue_Downloader
{
    public partial class AddEditForm : Form
    {
        public AddEditForm()
        {
            InitializeComponent();

            if (IsValidUrl(Clipboard.GetText()))
            {
                txtFileName.Text = Path.GetFileName(new Uri(Clipboard.GetText()).LocalPath);
                txtUrl.Text = Clipboard.GetText();
                grpAdd.TabIndex = 1;
                btnOK.TabIndex = 0;
            }

            txtSaveIn.Text = Settings.DefaultDirectory;
        }

        public AddEditForm(string urlAddress, string fileName)
        {
            InitializeComponent();

            txtFileName.Text = Path.GetFileName(fileName);
            txtUrl.Text = urlAddress;
            txtSaveIn.Text = Path.GetDirectoryName(fileName);
        }

        public string UrlAddress
        {
            get { return txtUrl.Text; }
        }

        public string FileName
        {
            get { return Path.Combine(txtSaveIn.Text, txtFileName.Text); }
        }

        private bool IsValidUrl(string urlAddress)
        {
            bool exists = false;
            HttpWebResponse response = null;

            try
            {
                var request = WebRequest.Create(urlAddress) as HttpWebRequest;
                request.Method = "HEAD";
                request.Timeout = 5000;
                response = request.GetResponse() as HttpWebResponse;
                exists = response.StatusCode == HttpStatusCode.OK && urlAddress.Substring(urlAddress.Length - 1, 1) != "/" && urlAddress != string.Empty;
            }
            catch
            {
                exists = false;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }

            return exists;
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

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text == string.Empty && IsValidUrl(txtUrl.Text))
                txtFileName.Text = Path.GetFileName(new Uri(txtUrl.Text).LocalPath);
        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                if (Path.GetInvalidFileNameChars().Contains(e.KeyChar) || Path.GetInvalidPathChars().Contains(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
                txtSaveIn.Text = dialog.SelectedPath;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == string.Empty)
                MessageBox.Show("Please enter an url address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtFileName.Text == string.Empty)
                MessageBox.Show("Please enter a file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSaveIn.Text == string.Empty)
                MessageBox.Show("Please enter or select a directory to save the file in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!IsValidUrl(txtUrl.Text))
                MessageBox.Show("The url address you have entered is invalid, or you don't have an active internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtFileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1 || txtFileName.Text.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                MessageBox.Show("The file name you have entered is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Directory.Exists(txtSaveIn.Text))
                MessageBox.Show("The directory you have entered or selected is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!HasWriteAccessToFolder(txtSaveIn.Text))
                MessageBox.Show("You don't have access to the directory you have enetered or selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (File.Exists(Path.Combine(txtSaveIn.Text, txtFileName.Text)))
                {
                    if (MessageBox.Show("The file already exists and will be overwritten if you continue. Are you sure you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        this.DialogResult = DialogResult.OK;
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
