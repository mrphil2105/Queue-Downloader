using System;
using System.Windows.Forms;

namespace Crazy_Software.Downloaders.Queue_Downloader.UI
{
    public class StrictNumericUpDown : NumericUpDown
    {
        protected override void OnTextBoxTextChanged(object sender, EventArgs e)
        {
            base.OnTextBoxTextChanged(sender, e);

            if (this.Value > this.Maximum)
            {
                this.Value = this.Maximum;
            }
        }
    }
}
