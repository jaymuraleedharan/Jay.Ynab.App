using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.UI;
using YnabApp.UI.ListAccounts;
using YnabApp.UI.OpenBudget;
using YnabApp.BL.ListBudgets;
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class MainForm : FormBase, IMainView
    {
        private readonly MainPresenter _presenter = null;
        private OpenBudgetForm _openBudgetForm = null;
        private ShowAccountsTransactionsForm _showAccountsForm = null;
        private ReflectForm _reflectForm = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void c_OpenBudgetMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_openBudgetForm == null || _openBudgetForm.Disposing || _openBudgetForm.IsDisposed)
                    _openBudgetForm = new OpenBudgetForm();

                ConfigureAndShowChildForm(_openBudgetForm);

                ((IOpenBudgetView)_openBudgetForm).InitializeView();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_AboutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(text: "This app was developed to keep myself up to date on .NET 5", 
                    caption: $"About Jay's YNAB App");
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_QuitMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        public void ShowAccountsView(BudgetData budgetData)
        {
            try
            {
                if (_showAccountsForm == null || _showAccountsForm.Disposing || _showAccountsForm.IsDisposed)
                    _showAccountsForm = new ShowAccountsTransactionsForm();

                ConfigureAndShowChildForm(_showAccountsForm);

                ((IListAccountsView)_showAccountsForm).InitializeView(budgetData);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void ShowReflectView(BudgetData budgetData)
        {
            try
            {
                if (_reflectForm == null || _reflectForm.Disposing || _reflectForm.IsDisposed)
                    _reflectForm = new ReflectForm();

                ConfigureAndShowChildForm(_reflectForm);

                ((IReflectView)_reflectForm).InitializeView(budgetData);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ConfigureAndShowChildForm(Form form)
        {
            form.ShowInTaskbar = false;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.ControlBox = false;
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;

            form.Show();
            form.Activate();
        }
    }
}
