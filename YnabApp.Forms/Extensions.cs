using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YnabApp.Forms
{
    public static class Extensions
    {
        public static string Format(this decimal decValue)
        {
            return decValue.ToString("$#,###,##0.00");
        }

        public static void Reload(this ComboBox comboBox, List<string> items )
        {

        }
    }
}
