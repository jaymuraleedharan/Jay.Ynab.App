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
using YnabApp.UI.Reflect;

namespace YnabApp.Forms
{
    public partial class ReflectForm : FormBase, IReflectView
    {
        private readonly ReflectPresenter _presenter = null;
        BudgetData _budgetData = null;

        public ReflectForm()
        {
            InitializeComponent();

            _presenter = new ReflectPresenter(this);
        }

        private void ReflectForm_Load(object sender, EventArgs e)
        {
            c_splitContainer1.SplitterDistance = c_splitContainer1.Width / 3;
            c_splitContainer2.SplitterDistance = c_splitContainer2.Width / 2;


        }

        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        public void InitializeView(BudgetData budgetData)
        {
            _budgetData = budgetData;

            ResetUI();
        }

        //------------------------------------------------//

        private void ResetUI()
        {
            c_radioDurationYearly.Checked = true;

            c_chkColumn1.Checked = true;
            c_datePicker1.Value = DateTime.Today;
            c_chkColumn2.Checked = true;
            c_datePicker2.Value = DateTime.Today.AddYears(-1);
            c_chkColumn3.Checked = true;
            c_datePicker3.Value = DateTime.Today.AddYears(-2);

            ((IReflectColumnView)c_reflectColumn1).InitializeView();
            ((IReflectColumnView)c_reflectColumn2).InitializeView();
            ((IReflectColumnView)c_reflectColumn3).InitializeView();
        }

        private async void c_btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateControls();

                ((IReflectColumnView)c_reflectColumn1).InitializeView();
                ((IReflectColumnView)c_reflectColumn2).InitializeView();
                ((IReflectColumnView)c_reflectColumn3).InitializeView();

                var categoriesData = await _presenter.GetCategoriesAsync(_budgetData.Id);

                DateTime earliestDate = GetEarliestDate();

                var transactionsData = await _presenter.GetTransactionsAsync(_budgetData.Id, earliestDate);

                if (c_chkColumn1.Checked == true)
                    ((IReflectColumnView)c_reflectColumn1).ShowReport(c_datePicker1.Value, c_radioDurationYearly.Checked, categoriesData, transactionsData);
                
                if(c_chkColumn2.Checked == true)
                    ((IReflectColumnView)c_reflectColumn2).ShowReport(c_datePicker2.Value, c_radioDurationYearly.Checked, categoriesData, transactionsData);
                
                if (c_chkColumn3.Checked == true)
                    ((IReflectColumnView)c_reflectColumn3).ShowReport(c_datePicker3.Value, c_radioDurationYearly.Checked, categoriesData, transactionsData);

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            
        }

        private void ValidateControls()
        {
            if(!c_chkColumn1.Checked && !c_chkColumn2.Checked && !c_chkColumn3.Checked)
            {
                throw new Exception("At least one Date must be selected.");
            }
        }

        private DateTime GetEarliestDate()
        {
            DateTime earliestDate = DateTime.MaxValue;
            if (c_radioDurationYearly.Checked)
            {
                if (c_chkColumn1.Checked && c_datePicker1.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker1.Value.Year, 1, 1);

                if (c_chkColumn2.Checked && c_datePicker2.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker2.Value.Year, 1, 1);

                if (c_chkColumn3.Checked && c_datePicker3.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker3.Value.Year, 1, 1);
            }
            else
            {
                if (c_chkColumn1.Checked && c_datePicker1.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker1.Value.Year, c_datePicker1.Value.Month, 1);

                if (c_chkColumn2.Checked && c_datePicker2.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker2.Value.Year, c_datePicker2.Value.Month, 1);

                if (c_chkColumn3.Checked && c_datePicker3.Value < earliestDate)
                    earliestDate = new DateTime(c_datePicker3.Value.Year, c_datePicker3.Value.Month, 1);
            }
            
            return earliestDate;
        }
    }
}
