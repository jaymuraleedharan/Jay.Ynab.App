using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.BL.ListBudgets;
using YnabApp.UI;

namespace YnabApp.Forms
{
    public partial class BudgetSettingsForm : FormBase, IBudgetView
    {
        public BudgetSettingsForm()
        {
            InitializeComponent();
        }

        public IMainView MainView { get; private set; }

        public BudgetData CurrentBudget { get; private set; }


        public void InitializeView(BudgetData budget, IMainView mainView)
        {
            CurrentBudget = budget;
            MainView = mainView;
        }
    }
}
