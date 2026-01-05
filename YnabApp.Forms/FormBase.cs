using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YnabApp.Forms
{
    public class FormBase : Form
    {
        public FormBase() : base()
        {
        }

        public void ShowError(Exception ex)
        {
            MessageBox.Show($"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
