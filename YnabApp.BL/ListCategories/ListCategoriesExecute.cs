using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace YnabApp.BL.ListCategories
{
    public class ListCategoriesExecute : ExecuteBase
    {
        public ListCategoriesExecute() : base() { }

        protected override string ExecuteUrl
        {
            get { return $"/budgets/{BudgetID}/categories"; }
        }

        public string BudgetID { get; set; }

        public async Task<CategoryGroupData[]> ListCAtegoriesAsync(string budgetID)
        {
            BudgetID = budgetID;

            CacheManager cache = new CacheManager(CacheType.Categories);
            string dataFromCache = await cache.GetDataFromCacheAsync();
            if (!string.IsNullOrEmpty(dataFromCache))
            {
                RawResponse = dataFromCache;
            }
            else
            {
                await base.ExecuteAsync();
                await cache.SaveToCacheAsync(base.RawResponse);
            }

            if (ParseRawResponse())
                throw new YnabException("Error while getting Categories List", GetError());

            return ConvertData();
        }


        protected CategoryGroupData[] ConvertData()
        {
            List<CategoryGroupData> list = new();

            JToken categoryGroups = JsonResponse["data"]["category_groups"];
            if (categoryGroups != null)
                foreach (var catGroup in categoryGroups)
                {
                    var categoryGroupData = new CategoryGroupData()
                    {
                        Id = catGroup["id"].ToString(),
                        Name = catGroup["name"].ToString(),
                        IsHidden = Boolean.Parse(catGroup["hidden"].ToString()),
                        IsDeleted = Boolean.Parse(catGroup["deleted"].ToString()),
                    };

                    if (IsExcludeCategory(categoryGroupData.Name) == true ||  categoryGroupData.Name.Contains("[?]"))
                        continue;

                    JToken categories = catGroup["categories"];
                    if(categories!= null)
                        foreach(var cat in categories)
                        {
                            var catData = new CategoryData()
                            {
                                Id = cat["id"].ToString(),
                                CategoryGroupId = cat["category_group_id"].ToString(),
                                Name = cat["name"].ToString(),
                                IsHidden = Boolean.Parse(cat["hidden"].ToString()),
                                IsDeleted = Boolean.Parse(cat["deleted"].ToString()),
                            };
                            categoryGroupData.Categories.Add(catData);
                        }
                    list.Add(categoryGroupData);
                }

            return list.ToArray();
        }

        private bool? IsExcludeCategory(string catGroupName)
        {
            return ConfigManager.App.ExcludeCategories?.ToList().Contains(catGroupName);
        }
    }
}
