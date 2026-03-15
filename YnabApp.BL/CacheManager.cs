using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Runtime;

namespace YnabApp.BL
{
    public class CacheManager
    {
        private CacheType Type { get; set; }

        private string CacheFolder { get; set; }

        public CacheManager(CacheType type) 
        { 
            Type = type;
            CacheFolder = Path.Combine(ConfigManager.Env.LocalBinFolder, ConfigManager.App.YnabCache.CacheFolder);
            EnsureCacheFolderExists();
        }

        private void EnsureCacheFolderExists()
        {
            if (!Directory.Exists(CacheFolder))
                Directory.CreateDirectory(CacheFolder);
        }

        //For Accounts and Categories
        private string GenerateCacheFileName()
        {
            // Accounts.json | Categories.json
            return $"{Type.ToString()}.json";
        }

        //For Transactions
        private string GenerateCacheFileName(DateTime historyStartDate)
        {
            // Transactions_20160101.json
            return $"{Type.ToString()}_{historyStartDate.ToString("yyyyMMdd")}.json";
        }

        //For Accounts and Categories
        public async Task<string> SaveToCacheAsync(string rawResponse)
        {
            DeletePriorFiles();

            string fileName = GenerateCacheFileName();
            string fullFilePath = Path.Combine(CacheFolder, fileName);

            await File.WriteAllTextAsync(fullFilePath, rawResponse);

            return fileName;
        }

        //For Transactions
        public async Task<string> SaveToCacheAsync(DateTime historyStartDate, string rawResponse)
        {
            DeletePriorFiles();

            string fileName = GenerateCacheFileName(historyStartDate);
            string fullFilePath = Path.Combine(CacheFolder, fileName);

            await File.WriteAllTextAsync(fullFilePath, rawResponse);

            return fileName;
        }

        //For all types
        private void DeletePriorFiles()
        {
            var priorFiles = SearchCacheFolder().ToList();
            priorFiles.ForEach(f => File.Delete(f));
        }

        //For Accounts and Categories
        public async Task<string> GetDataFromCacheAsync()
        {
            string cacheData = string.Empty;

            if (ConfigManager.App.YnabCache.IsCachingEnabled)
            {
                var files = SearchCacheFolder().ToList();

                if (files.Count > 0)
                    cacheData = await File.ReadAllTextAsync(files[0]); //return first file found
            }
            
            return cacheData;
        }

        //For Transactions
        public async Task<string> GetDataFromCacheAsync(DateTime historyStartDate)
        {
            string cacheData = string.Empty;

            if (ConfigManager.App.YnabCache.IsCachingEnabled)
            {
                var files = SearchCacheFolder(historyStartDate).ToList();

                if (files.Count > 0)
                    cacheData = await File.ReadAllTextAsync(files[0]); //return first file found
            }

            return cacheData;
        }

        private bool IsCacheFileExpired(string filePath)
        {
            FileInfo fInfo = new FileInfo(filePath);
            double cacheAgeInDays = (DateTime.Now - fInfo.CreationTime).TotalDays;
            return (cacheAgeInDays > (double)ConfigManager.App.YnabCache.AutoExpirationInDays);
        }


        //For Accounts and Categories
        private List<string> SearchCacheFolder()
        {
            // Accounts.json | Categories.json | Transactions_20160101.json
            List<string> matchingCacheFiles = new List<string>();
            IEnumerable<string> files = Directory.EnumerateFiles(CacheFolder, $"{Type.ToString()}_*.json").ToList();
            foreach (var item in files)
            {
                if(!IsCacheFileExpired(item))
                    matchingCacheFiles.Add(item);
            }
            return matchingCacheFiles.ToList();
        }

        //For Transactions
        private List<string> SearchCacheFolder(DateTime historyStartDate)
        {
            List<string> matchingCacheFiles = new List<string>();

            // Transactions_20160101.json
            IEnumerable<string> files = Directory.EnumerateFiles(CacheFolder, $"{Type.ToString()}_*.json").ToList();
            foreach (var item in files)
            {
                if (IsCacheFileExpired(item))
                    continue;

                //Get Cache History Start Date
                DateTime cacheHistoryStartDate = DateTime.MaxValue;
                string fileName = Path.GetFileNameWithoutExtension(item);
                string[] nameParts = fileName.Split("_".ToArray());
                if (nameParts.Length > 1)
                {
                    string startDateString = nameParts[1];
                    cacheHistoryStartDate = ParseDateFromString(startDateString);
                }

                //Check if Cache contains the requested History or more.
                int result = DateTime.Compare(cacheHistoryStartDate, historyStartDate);
                //If Cache has all the data requested, use it.
                if (result <= 0)
                    matchingCacheFiles.Add(item);
            }
            return matchingCacheFiles.ToList();
        }

        private DateTime ParseDateFromString(string dateString)
        {
            //yyyyMMdd
            if (!string.IsNullOrEmpty(dateString) && dateString.Length == 8)
                return new DateTime(Convert.ToInt32(dateString.Substring(0, 4)),
                                        Convert.ToInt32(dateString.Substring(4, 2)),
                                        Convert.ToInt32(dateString.Substring(6, 2)));
            else
                return DateTime.MaxValue;
        }


        public bool ClearCache()
        {
            var files = Directory.EnumerateFiles(CacheFolder, "*.json").ToList();
            files.ForEach( f => File.Delete(f));
            return true;
        }
    }


    public enum CacheType
    {
        Accounts,
        Categories,
        Transactions
    }
}

