using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YnabApp.BL.BudgetSettings;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListCategories;
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

        private BudgetSettings CurrentBudgetSettings { get; set; }

        private List<AccountSetting> AllAccounts { get; set; } = new List<AccountSetting>();

        private List<CategoryGroupColorSetting> CategoryGroupSettings { get; set; } = new List<CategoryGroupColorSetting>();


        public void InitializeView(BudgetData budget, IMainView mainView)
        {
            CurrentBudget = budget;
            MainView = mainView;

            ShowBasicInfo();
            GetAccountsList();
            RefreshSettingsUI();
        }

        private void LoadCurrentBudgetSettings()
        {
            CurrentBudgetSettings = BudgetSettings.Load(CurrentBudget.Id);
        }

        private void ShowBasicInfo()
        {
            c_infoBudgetID.Text = CurrentBudget.Id;
            c_infoBudgetName.Text = CurrentBudget.Name;
            c_infoBudgetLastModifed.Text = CurrentBudget.LastModifiedOn;
            c_infoBudgetStartDate.Text = CurrentBudget.StartDate.ToShortDateString();
            c_infoBudgetEndDate.Text = CurrentBudget.EndDate.ToShortDateString();
        }

        private void RefreshSettingsUI()
        {
            LoadCurrentBudgetSettings();
            ShowPersonLists();
            ShowCategoryGroupList();
        }

        private void ShowPersonLists()
        {
            PersonSetting currentSelectedPerson = (c_personList.SelectedIndex >= 0) ? (PersonSetting)c_personList.SelectedItem : null;

            c_personList.Items.Clear();
            CurrentBudgetSettings.People.ForEach(p => c_personList.Items.Add(p));

            foreach (var item in c_personList.Items)
            {
                if (((PersonSetting)item) == currentSelectedPerson)
                    c_personList.SelectedIndex = c_personList.Items.IndexOf(item);
            }
        }

        private async void GetAccountsList()
        {
            ListAccountsExecute exe = new();
            var accountsData = await exe.ListAccountsAsync(CurrentBudget.Id);

            foreach (var acc in accountsData)
                if (!acc.IsDeleted && !acc.IsClosed)
                    AllAccounts.Add(new AccountSetting() { Id = acc.Id, Name = acc.Name });
        }

        private async void ShowCategoryGroupList()
        {
            ListCategoriesExecute listCategoriesExecute = new();
            var catGroupData = await listCategoriesExecute.ListCAtegoriesAsync(CurrentBudget.Id);

            c_catGroupListview.Columns.Clear();
            c_catGroupListview.Groups.Clear();
            c_catGroupListview.Items.Clear();
            c_catGroupListview.Columns.Add("Category Group Name");

            foreach (var catGroup in catGroupData)
            {
                var catGrpSetting = CurrentBudgetSettings.CategoryGroupColors.Find(cg => cg.Id == catGroup.Id);
                if (catGrpSetting != null)
                {
                    var item = c_catGroupListview.Items.Add(catGrpSetting.Name);
                    item.BackColor = catGrpSetting.BackColor.GetColor();
                    item.ForeColor = catGrpSetting.ForeColor.GetColor();
                    item.Tag = catGrpSetting;
                }
                else
                {
                    catGrpSetting = new CategoryGroupColorSetting() { 
                        Id = catGroup.Id, 
                        Name = catGroup.Name, 
                        BackColor = ColorSetting.CreateFromColor(Color.Transparent), 
                        ForeColor = ColorSetting.CreateFromColor(Color.Black) };

                    CurrentBudgetSettings.CategoryGroupColors.Add(catGrpSetting);
                    CurrentBudgetSettings.Save();
                }
            }            
            c_catGroupListview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            c_catGroupListview.Columns[0].Width = c_catGroupListview.Width - 10;
        }

        #region PEOPLE

        private void c_personList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                c_personAccountsAvailableList.Items.Clear();
                c_personAccountsAddedList.Items.Clear();

                if (c_personList.SelectedIndex >= 0)
                {
                    PersonSetting selectedPerson = (PersonSetting)c_personList.SelectedItem;

                    foreach (var acc in AllAccounts)
                    {
                        if (selectedPerson.Accounts.Any(a => a.Id == acc.Id))
                            c_personAccountsAddedList.Items.Add(acc);
                        else
                            c_personAccountsAvailableList.Items.Add(acc);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_addPersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                string newPersonName = SimplePrompt.ShowDialog("Enter Person Name", "New Person");
                if (!string.IsNullOrEmpty(newPersonName))
                {
                    if (IsPersonAlreadyExists(newPersonName))
                    {
                        MessageBox.Show("A person with this name already exists. Please choose a different name.", "Duplicate Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    CurrentBudgetSettings.People.Add(PersonSetting.CreateNew(newPersonName));
                    CurrentBudgetSettings.Save();
                    RefreshSettingsUI();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_renamePersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_personList.SelectedIndex >= 0)
                {
                    string currentName = c_personList.SelectedItem.ToString();
                    string newPersonName = SimplePrompt.ShowDialog("Enter New Person Name", "Rename Person");
                    if (!string.IsNullOrEmpty(newPersonName))
                    {
                        if (IsPersonAlreadyExists(newPersonName))
                        {
                            MessageBox.Show("A person with this name already exists. Please choose a different name.", "Duplicate Person", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        var person = CurrentBudgetSettings.People.FirstOrDefault(p => p.Name == currentName);
                        if (person != null)
                        {
                            person.Name = newPersonName;
                            CurrentBudgetSettings.Save();
                            RefreshSettingsUI();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_removePersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (c_personList.SelectedIndex >= 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove the selected person?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    string currentName = c_personList.SelectedItem.ToString();
                    var person = CurrentBudgetSettings.People.FirstOrDefault(p => p.Name == currentName);
                    if (person != null)
                    {
                        CurrentBudgetSettings.People.Remove(person);
                        CurrentBudgetSettings.Save();
                        RefreshSettingsUI();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private bool IsPersonAlreadyExists(string name)
        {
            return CurrentBudgetSettings.People.Any(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        #region PERSON ACCOUNTS

        private void c_personAccountsAvailableList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                AddSelectedPersonAccount();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_personAccAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddSelectedPersonAccount();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void AddSelectedPersonAccount()
        {
            PersonSetting selectedPerson = (PersonSetting)c_personList.SelectedItem;
            AccountSetting selectedAcc = c_personAccountsAvailableList.SelectedItem as AccountSetting;

            if (selectedPerson != null && selectedAcc != null)
            {
                c_personAccountsAddedList.Items.Add(selectedAcc);
                c_personAccountsAvailableList.Items.Remove(selectedAcc);

                selectedPerson.Accounts.Add(selectedAcc);
                CurrentBudgetSettings.People.First(p => p.Id == selectedPerson.Id).Accounts.Add(selectedAcc);
                CurrentBudgetSettings.Save();
            }
        }

        private void RemoveSelectedPersonAccount()
        {
            PersonSetting selectedPerson = (PersonSetting)c_personList.SelectedItem;
            AccountSetting selectedAcc = c_personAccountsAddedList.SelectedItem as AccountSetting;

            if (selectedPerson != null && selectedAcc != null)
            {
                c_personAccountsAddedList.Items.Remove(selectedAcc);
                c_personAccountsAvailableList.Items.Add(selectedAcc);

                selectedPerson.Accounts.Remove(selectedAcc);
                CurrentBudgetSettings.People.First(p => p.Id == selectedPerson.Id).Accounts.Remove(selectedAcc);
                CurrentBudgetSettings.Save();
            }
        }

        private void c_personAccRemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveSelectedPersonAccount();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_personAccountsAddedList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                RemoveSelectedPersonAccount();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        #endregion

        #region CATEGORY GROUPS COLORS

        private void c_backColorButton_Click(object sender, EventArgs e)
        {
            try
            {
                CatGroupEditBackColor();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_fontColorButton_Click(object sender, EventArgs e)
        {
            try
            {
                CatGroupEditForeColor();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void c_catGroupListview_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CatGroupEditBackColor();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CatGroupEditBackColor()
        {
            if(c_catGroupListview.SelectedItems.Count > 0)
            {
                if (c_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (ListViewItem item in c_catGroupListview.SelectedItems)
                    {
                        item.BackColor = c_colorDialog.Color;
                        
                        CategoryGroupColorSetting listCatGrpSetting = item.Tag as CategoryGroupColorSetting;
                        if(listCatGrpSetting != null)
                            listCatGrpSetting.BackColor = ColorSetting.CreateFromColor(c_colorDialog.Color);

                        CategoryGroupColorSetting budgetCatGrpSetting = CurrentBudgetSettings.CategoryGroupColors.Find(cg => cg.Id == listCatGrpSetting.Id);
                        budgetCatGrpSetting.BackColor = ColorSetting.CreateFromColor(c_colorDialog.Color);

                        CurrentBudgetSettings.Save();
                    }
                }
            }
        }

        private void CatGroupEditForeColor()
        {

        }

        #endregion
    }
}
