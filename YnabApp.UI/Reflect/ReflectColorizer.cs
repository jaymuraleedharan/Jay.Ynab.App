using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YnabApp.UI.Reflect
{
    public enum CategoryGroupNames
    {
        NECESSITIES,
        NECESSITIES_TAX,
        DISCRETIONARY,
        HELP,
        SAVINGS,
        INVESTMENTS
    }

    public static class ReflectColorizer
    {
        public static Color GetBackColor(string categoryGroupName)
        {
            switch(categoryGroupName)
            {
                case "NECESSITIES": return Color.LightGoldenrodYellow;
                case "NECESSITIES-TAX": return Color.LightGoldenrodYellow;
                case "DISCRETIONARY": return Color.LightPink;
                case "HELP": return Color.LightGreen;
                case "SAVINGS": return Color.LightGreen;
                case "INVESTMENTS": return Color.LightGreen;
                default: return Color.DarkRed;
            }
        }

        public static Color GetFontColor(string categoryGroupName)
        {
            switch (categoryGroupName)
            {
                case "NECESSITIES": return Color.Black;
                case "NECESSITIES-TAX": return Color.Black;
                case "DISCRETIONARY": return Color.Black;
                case "HELP": return Color.Black;
                case "SAVINGS": return Color.Black;
                case "INVESTMENTS": return Color.Black;
                default: return Color.White;
            }
        }

    }
}
