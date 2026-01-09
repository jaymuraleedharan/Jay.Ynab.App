using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;

namespace YnabApp.BL.Reflect
{
    public class DataCruncherForReflection
    {
        List<string> categoryGroupExcludeList = new List<string>()
        {
            "Credit Card Payments",
            "Hidden Categories",
            "Internal Master Category"
        };

        public DataCruncherForReflection()
        {
            
        }

        public async Task<List<ReflectCategoryGroupData>> CrunchCategroyGroupDataAsync(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            List<ReflectCategoryGroupData> reflectCategoryGroupDatas = new List<ReflectCategoryGroupData>();

            await Task.Run(() =>
            {
                reflectCategoryGroupDatas = GenerateCrunchCategroyGroupData(categoryGroupDatas, transactionDatas, isYearly, reportDate);

            });

            return reflectCategoryGroupDatas;
        }

        private List<ReflectCategoryGroupData> GenerateCrunchCategroyGroupData(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            List<ReflectCategoryGroupData> reflectCategoryGroupDatas = new List<ReflectCategoryGroupData>();

            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            foreach (var categoryGroup in categoryGroupDatas)
            {
                if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]"))
                    continue;

                ReflectCategoryGroupData reflectCategoryGroup = new(categoryGroup.Id, categoryGroup.Name, categoryGroup);
                foreach (var caregory in categoryGroup.Categories)
                {
                    var categoryTransactions = matchingTransactions.Where(t => t.CategoryId == caregory.Id);
                    if (categoryTransactions.Any())
                    {
                        decimal categoryTotal = categoryTransactions.Sum(t => t.Amount);
                        reflectCategoryGroup.Amount += categoryTotal;
                    }
                }
                reflectCategoryGroupDatas.Add(reflectCategoryGroup);
            }

            return reflectCategoryGroupDatas.OrderBy(cg => cg.Amount).ToList();
        }


        public async Task<List<ReflectCategoryData>> CrunchCategroyDataAsync(CategoryGroupData[] categoryGroupData, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            await Task.Run(() =>
            {
                reflectCategoryDatas = GenerateCrunchCategoryData(categoryGroupData, transactionDatas, isYearly, reportDate);
            });

            return reflectCategoryDatas;
        }

        private List<ReflectCategoryData> GenerateCrunchCategoryData(CategoryGroupData[] categoryGroupDatas, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            List<ReflectCategoryData> reflectCategoryDatas = new List<ReflectCategoryData>();

            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            foreach (var categoryGroup in categoryGroupDatas)
            {
                if (categoryGroupExcludeList.Contains(categoryGroup.Name) || categoryGroup.Name.Contains("[?]"))
                    continue;
                
                foreach (var category in categoryGroup.Categories)
                {
                    ReflectCategoryData reflectCategory = new(category.Id, categoryGroup.Name, category.Name, category);

                    var categoryTransactions = matchingTransactions.Where(t => t.CategoryId == category.Id);
                    if (categoryTransactions.Any())
                    {
                        decimal categoryTotal = categoryTransactions.Sum(t => t.Amount);
                        reflectCategory.Amount += categoryTotal;
                    }

                    reflectCategoryDatas.Add(reflectCategory);
                }                
            }

            return reflectCategoryDatas.OrderBy(cg => cg.Amount).ToList();
        }

        public List<TransactionData> FilterCategoryGroupTransactions(ReflectCategoryGroupData categoryGroupData, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);

            List<TransactionData> filteredTransactions = new List<TransactionData>();
            foreach (TransactionData transactionData in matchingTransactions)
            {
                foreach (var categoryData in categoryGroupData.CategoryGroup.Categories)
                {
                    if (transactionData.CategoryId == categoryData.Id)
                        filteredTransactions.Add(transactionData);
                }
            }
            return filteredTransactions;
        }



        public List<TransactionData> FilterCategoryTransactions(ReflectCategoryData categoryData, TransactionData[] transactionDatas, bool isYearly, DateTime reportDate)
        {
            IEnumerable<TransactionData> matchingTransactions;
            if (isYearly)
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year);
            else
                matchingTransactions = transactionDatas.Where(t => t.TransDateTime.Year == reportDate.Year && t.TransDateTime.Month == reportDate.Month);


            List<TransactionData> filteredTransactions = new List<TransactionData>();
            foreach (TransactionData transactionData in matchingTransactions)
            {
                if (transactionData.CategoryId == categoryData.ID)
                    filteredTransactions.Add(transactionData);
            }
            return filteredTransactions;
        }
    }
}
