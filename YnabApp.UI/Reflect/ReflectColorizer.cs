using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using YnabApp.BL.BudgetSettings;

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
        private static readonly Color LIGHTYELLOW = Color.FromArgb(255, 255, 204);
        private static readonly Color LIGHTGREEN = Color.FromArgb(204, 255, 204);
        private static readonly Color LIGHTRED = Color.FromArgb(255, 204, 204);
        private static readonly Color LIGHTBLUE = Color.FromArgb(204, 236, 255);

        public static Color GetBackColor(string categoryGroupName)
        {
            switch(categoryGroupName)
            {
                case "NECESSITIES": return LIGHTYELLOW;
                case "NECESSITIES-TAX": return LIGHTYELLOW;
                case "DISCRETIONARY": return LIGHTRED;
                case "HELP": return LIGHTBLUE;
                case "SAVINGS": return LIGHTGREEN;
                case "INVESTMENTS": return LIGHTGREEN;
                default: return LIGHTRED;
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
                default: return Color.Black;
            }
        }

        public static Color GetSummaryBackColor(string summaryName)
        {
            switch (summaryName)
            {
                case "All Incomes": return LIGHTGREEN;
                case "All Expenses": return LIGHTRED;
                case "Savings": return LIGHTGREEN;
                case "Unspent": return LIGHTGREEN;
                default: return LIGHTRED;
            }
        }

        public static Color GetSummaryFontColor(string summaryName)
        {
            switch (summaryName)
            {
                case "All Incomes": return Color.Black;
                case "All Expenses": return Color.Black;
                case "Savings": return Color.Black;
                case "Unspent": return Color.Black;
                default: return Color.Black;
            }
        }

        public static Color GetNetChangeBackColor(decimal amount)
        {
            if (amount == 0)
                return Color.FromKnownColor(KnownColor.Control);
            else if (amount < 0)
                return LIGHTRED;
            else
                return LIGHTGREEN;
        }

        public static Color GetNetChangeFontColor(decimal amount)
        {
            return Color.Black;
        }
    }
}
