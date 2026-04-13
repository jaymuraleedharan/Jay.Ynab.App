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
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.ListCategories;
using YnabApp.UI;
using YnabApp.UI.ListAccounts;
using YnabApp.BL.BudgetSettings;

namespace YnabApp.Forms
{
    public partial class NetWorthForm : FormBase, IListAccountsView
    {
        private readonly ListAccountsPresenter _presenter = null;
        private BudgetData _budgetData = null;
        private BudgetSettings CurrentBudgetSettings { get; set; }
        private AccountData[] _accountsData = null;
        private TransactionData[] _transactionsData = null;
        private CategoryGroupData[] _categoriesData = null;

        public NetWorthForm()
        {
            InitializeComponent();

            _presenter = new ListAccountsPresenter(this);
        }

        public async void InitializeView(BudgetData budgetData)
        {
            try
            {
                _budgetData = budgetData;
                CurrentBudgetSettings = BudgetSettings.Load(_budgetData.Id);

                ResetUI();

                await GetAccountsDataAsync();

                await GetCategoriesDataAsync();

                PresentAllAssets();

                //c_startDatePicker.ValueChanged += C_startDatePicker_ValueChanged;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public IMainView MainView
        {
            get { return this.MdiParent as IMainView; }
        }

        private void ResetUI()
        {
            LoadPersonList();

            ResetAllAssetsListView();
        }

        private void LoadPersonList()
        {
            c_personList.Items.Clear();
            c_personList.Items.Add("ALL");
            CurrentBudgetSettings.People.ForEach(p => c_personList.Items.Add(p));
            c_personList.SelectedIndex = 0;
        }

        private void c_personList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var person = c_personList.SelectedItem as PersonSetting;
                var filteredAccs = PersonAccount.GetPersonAccounts(_accountsData, person);
                ResetAllAssetsListView();
                PresentAllAssets(filteredAccs);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private async Task GetAccountsDataAsync()
        {
            this.Text = _budgetData.Name;
            _accountsData = await _presenter.GetAllAccountsAsync(_budgetData.Id);
        }

        private async Task GetCategoriesDataAsync()
        {
            _categoriesData = await _presenter.GetCategoriesAsync(_budgetData.Id);
        }


        private decimal GetCategoryTotal(CategoryGroupData catGroupData)
        {
            var catIds = catGroupData.Categories.Select(c => c.Id).ToArray(); //Get Ids of all Categories under the Category Group
            return _transactionsData.Where(t => catIds.Contains(t.CategoryId)).Sum(t => t.Amount); //Get all transaction belonging to the list Category Ids

        }

        private TransactionData[] FilterTransactions(AccountData accData)
        {
            return _transactionsData.Where(t => t.AccountId == accData.Id).ToArray();
        }

        private TransactionData[] FilterTransactions(CategoryGroupData catGroupData)
        {
            var catIds = catGroupData.Categories.Select(c => c.Id).ToArray(); //Get Ids of all Categories under the Category Group
            return _transactionsData.Where(t => catIds.Contains(t.CategoryId)).ToArray(); //Get all transaction belonging to the list Category Ids
        }

        private TransactionData[] FilterTransactions(CategoryData catData)
        {
            return _transactionsData.Where(t => t.CategoryId == catData.Id).ToArray();
        }


        private void ResetAllAssetsListView()
        {
            c_allAssetsListView.Columns.Clear();
            c_allAssetsListView.Columns.Add("Name");
            c_allAssetsListView.Columns.Add("Type");
            c_allAssetsListView.Columns.Add("Balance", 300, HorizontalAlignment.Right);

            c_allAssetsListView.Groups.Clear();
            c_allAssetsListView.Items.Clear();
        }

        private void PresentAllAssets()
        {
            PresentAllAssets(_accountsData);
        }

        private void PresentAllAssets(AccountData[] accountDatas)
        {
            if (accountDatas == null)
                return;

            c_allAssetsListView.SuspendLayout();

            decimal nwBalance = 0;

            //Group Acounts by Account Type
            var groups = (from a in accountDatas select a.Group).Distinct();
            foreach (var group in groups)
            {
                //GROUP
                var typeGroup = new ListViewGroup(group.ToString(), HorizontalAlignment.Left);
                c_allAssetsListView.Groups.Add(typeGroup);

                //GROUP ITEMS
                var accountsInGroup = accountDatas.Where(a => a.Group == group);
                if (accountsInGroup.Count() == 0)
                    continue;

                decimal balanceTotal = 0, groupTotalCredit = 0, groupTotalDebit = 0, groupNetChange = 0;

                foreach (var accData in accountsInGroup)
                {
                    if (accData.IsClosed || accData.IsDeleted)
                        continue;

                    //Correcting Negative Balances for liabilities
                    //if(accData.Group)

                    if (accData.Type == "otherLiability" && accData.Balance > 0)
                        accData.Balance = -(accData.Balance);

                    var item = new ListViewItem(new string[]
                    {
                            accData.Name, accData.Type, _budgetData.FormatAmount(accData.Balance)
                    });

                    c_allAssetsListView.Items.Add(item);
                    ColorizeAsset(item, accData);
                    item.Group = typeGroup;

                    balanceTotal += accData.Balance;
                    groupTotalCredit += accData.CreditTotal;
                    groupTotalDebit += accData.DebitTotal;
                    groupNetChange += accData.NetChange;
                    nwBalance += accData.Balance;
                }

                //GROUP TOTAL
                var groupTotal = new ListViewItem(new string[]
                    {
                            "TOTAL", string.Empty, _budgetData.FormatAmount(balanceTotal)
                    });
                groupTotal.Font = new Font(groupTotal.Font, FontStyle.Bold);
                c_allAssetsListView.Items.Add(groupTotal);
                groupTotal.Group = typeGroup;
            }

            //Net Worth Group & Total
            var nwGroup = new ListViewGroup("NET WORTH", HorizontalAlignment.Left);
            c_allAssetsListView.Groups.Add(nwGroup);
            var nwTotal = new ListViewItem(new string[]
                {
                            "TOTAL", string.Empty, _budgetData.FormatAmount(nwBalance)
                });
            nwTotal.Font = new Font(nwTotal.Font, FontStyle.Bold);
            c_allAssetsListView.Items.Add(nwTotal);
            nwTotal.Group = nwGroup;


            c_allAssetsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            c_allAssetsListView.ResumeLayout();

        }

        //private bool IsLiability(AccountData accData)
        //{
        //    return accData.Group == AccountGroup.Liability;
        //}

        private void ColorizeAsset(ListViewItem item, AccountData accData)
        {
            switch (accData.Group)
            {
                case AccountGroup.Liability:
                    item.BackColor = CurrentBudgetSettings.GeneralColors.ExpenseColor.GetColor(); break;
                default:
                    item.BackColor = CurrentBudgetSettings.GeneralColors.IncomeColor.GetColor(); break;
            }
        }

    }
}
