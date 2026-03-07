using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Memory;

namespace YnabApp.BL
{
    public static class ConfigManager
    {
        public static IConfigurationRoot AllConfig { get; internal set; }

        public static AppSettings App { get; private set; }

        public static UISettings UI { get; private set; }

        static ConfigManager()
        {
            AllConfig = new ConfigurationBuilder()
                                    .SetBasePath(new Uri(AppContext.BaseDirectory).LocalPath)
                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                    .Build();

            App = new AppSettings();
            var appSection = AllConfig.GetSection("AppSettings");
            appSection.Bind(App);

            UI = new UISettings();
            var uiSection = AllConfig.GetSection("UISettings");
            uiSection.Bind(UI);

        }
    }

    public sealed class AppSettings
    {
        public YnabApiSettings YnabApi { get; set; }

        public YnabCacheSettings YnabCache { get; set; }
    }

    public sealed class YnabApiSettings
    {
        public string DevToken { get; set; } = null;

        public string BaseUrl { get; set; } = null;
    }

    public sealed class YnabCacheSettings
    {
        public string CacheFolder { get; set; } = null;

        public int AutoExpirationInDays { get; set; } = 0;
    }

    public sealed class UISettings
    {

    }

    public sealed class ColorSettings
    {
        public string Name { get; set; } = null;

        //public 
    }
}
