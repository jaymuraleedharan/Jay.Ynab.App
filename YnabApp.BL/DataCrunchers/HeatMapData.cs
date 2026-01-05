using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListBudgets;
using YnabApp.BL.ListAccounts;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.BL.DataCrunchers
{
    public class HeatMapData
    {
        public DateTime MapDate { get; set; }

        public decimal CrunchedAmount { get; set; }

        internal List<AccountData> Accounts = new();

        internal List<CategoryGroupData> CategoryGroups = new();

        internal List<CategoryData> Categories = new();


        public void BuildAccounts(AccountData[] accountDatas)
        {
            foreach (AccountData accData in accountDatas)
                Accounts.Add(new AccountData()
                {
                    Id = accData.Id,
                    Name = accData.Name,
                    Balance = 0,
                    IsClosed = accData.IsClosed,
                    IsDeleted = accData.IsDeleted,
                    Type = accData.Type
                });
        }

        public void BuildCategories(CategoryGroupData[] catGroupDatas)
        {
            foreach(var catGroupData in catGroupDatas)
            {
                var catGroupNew = new CategoryGroupData()
                {
                    Id = catGroupData.Id,
                    Name = catGroupData.Name,
                    IsDeleted = catGroupData.IsDeleted,
                    IsHidden = catGroupData.IsHidden
                };
                CategoryGroups.Add(catGroupNew);

                foreach (var catData in catGroupData.Categories)
                {
                    Categories.Add(new CategoryData()
                    {
                        Id = catData.Id,
                        Name = catData.Name,
                        CategoryGroupId = catData.CategoryGroupId,
                        IsDeleted = catData.IsDeleted,
                        IsHidden = catData.IsHidden
                    });
                }
                
            }
        }

        public decimal AccountTotal(string accountId)
        {
            return Accounts.Find(a => a.Id == accountId).CrunchedAmount;
        }

        public decimal CategoryGroupTotal(string catGroupId)
        {
            return CategoryGroups.Find(c => c.Id == catGroupId).CrunchedAmount;
        }

        public decimal CategoryTotal(string categoryId)
        {
            return Categories.Find(c => c.Id == categoryId).CrunchedAmount;
        }
    }
}
