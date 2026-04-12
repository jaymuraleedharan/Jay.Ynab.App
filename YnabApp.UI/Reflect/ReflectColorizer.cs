using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using YnabApp.BL.BudgetSettings;

namespace YnabApp.UI.Reflect
{

    public static class ReflectColorizer
    {
        private static readonly Color LIGHTYELLOW = Color.FromArgb(255, 255, 204);
        private static readonly Color LIGHTGREEN = Color.FromArgb(204, 255, 204);
        private static readonly Color LIGHTRED = Color.FromArgb(255, 204, 204);
        private static readonly Color LIGHTBLUE = Color.FromArgb(204, 236, 255);


        public static Color GetSummaryBackColor(string summaryName, BudgetSettings currentBudgetsettings)
        {
            switch (summaryName)
            {
                case "All Incomes": return currentBudgetsettings.GeneralColors.IncomeColor.GetColor();
                case "All Expenses": return currentBudgetsettings.GeneralColors.ExpenseColor.GetColor();
                case "Savings": return currentBudgetsettings.GeneralColors.IncomeColor.GetColor();
                case "Unspent": return currentBudgetsettings.GeneralColors.IncomeColor.GetColor();
                default: return currentBudgetsettings.GeneralColors.IncomeColor.GetColor();
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

        public static Color GetNetChangeBackColor(decimal amount, BudgetSettings currentBudgetsettings)
        {
            if (amount == 0)
                return Color.FromKnownColor(KnownColor.Control);
            else if (amount < 0)
                return currentBudgetsettings.GeneralColors.ExpenseColor.GetColor();
            else
                return currentBudgetsettings.GeneralColors.IncomeColor.GetColor();
        }

        public static Color GetNetChangeFontColor(decimal amount)
        {
            return Color.Black;
        }
    }
}
