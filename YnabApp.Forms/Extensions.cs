using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.Forms
{
    public static class Extensions
    {
        public static string Format(this decimal decValue)
        {
            return decValue.ToString("$#,###,##0.00");
        }
    }
}
