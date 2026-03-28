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
using YnabApp.UI.OpenBudget;
using YnabApp.UI.ListAccounts;
using YnabApp.BL.ListBudgets;

namespace YnabApp.Forms
{
    public partial class OpenBudgetForm : FormBase, IOpenBudgetView
    {
        private readonly OpenBudgetPresenter _presenter = null;


        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        public OpenBudgetForm()
        {
            InitializeComponent();

            _presenter = new OpenBudgetPresenter(this);
        }

        public async void InitializeView()
        {
            try
            {
                var data = await _presenter.GetAllBudgetsAsync();

                PrepareGridView();
                c_budgetGrid.DataSource = data;
                c_budgetGrid.Refresh();
                c_budgetGrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                if (data != null && data.Length > 0)
                {
                    c_budgetGrid.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_openBudget_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_budgetGrid.SelectedRows.Count > 0)
                {
                    BudgetData data = c_budgetGrid.SelectedRows[0].DataBoundItem as BudgetData;
                    if (data != null)
                        MainView.ShowAccountsView(data);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        private void PrepareGridView()
        {
            c_budgetGrid.Columns.Clear();
            c_budgetGrid.AutoGenerateColumns = false;
            c_budgetGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Name",
                DataPropertyName = "Name",
                ValueType = Type.GetType("System.String")
            });
            c_budgetGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "LastModifiedOn",
                DataPropertyName = "LastModifiedOn",
                ValueType = Type.GetType("System.String")
            });
            c_budgetGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "FirstMonth",
                DataPropertyName = "FirstMonth",
                ValueType = Type.GetType("System.String")
            });
            c_budgetGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "LastMonth",
                DataPropertyName = "LastMonth",
                ValueType = Type.GetType("System.String")
            });
        }

        private void c_reflectButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_budgetGrid.SelectedRows.Count > 0)
                {
                    BudgetData data = c_budgetGrid.SelectedRows[0].DataBoundItem as BudgetData;
                    if (data != null)
                        MainView.ShowReflectView(data);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_chartsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_budgetGrid.SelectedRows.Count > 0)
                {
                    BudgetData data = c_budgetGrid.SelectedRows[0].DataBoundItem as BudgetData;
                    if (data != null)
                        MainView.ShowChartsView(data);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
    }
}
