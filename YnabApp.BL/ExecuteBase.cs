using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace YnabApp.BL
{
    public abstract class ExecuteBase
    {
        //protected const string DevToken = @"0b93be518a2694b9614c62b81cd3e15999e52b9faedf4ee796b2f4a20549afba";

        //protected const string BaseUrl = @"https://api.youneedabudget.com/v1";

        protected readonly string DevToken;

        protected readonly string BaseUrl;

        protected abstract string ExecuteUrl { get; }

        protected static readonly HttpClient _client = new();

        protected string RawResponse { get; set; }

        protected JObject JsonResponse { get; set; }

        protected ExecuteBase() 
        {
            DevToken = ConfigManager.App.YnabApi.DevToken;
            BaseUrl = ConfigManager.App.YnabApi.BaseUrl;
        }

        protected async Task ExecuteAsync()
        {
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {DevToken}");
            HttpResponseMessage response = await _client.GetAsync(BaseUrl + ExecuteUrl);
            response.EnsureSuccessStatusCode();
            RawResponse = await response.Content.ReadAsStringAsync();
        }

        protected bool ParseRawResponse()
        {
            JsonResponse = JObject.Parse(RawResponse);

            if (JsonResponse == null)
                throw new ApplicationException("Invalid JSON Response");

            if (JsonResponse["data"] != null)
                return false;
            else if (JsonResponse["error"] != null)
                return true;
            else
                throw new ApplicationException("Unrecognized Response");
        }

        protected ErrorData GetError()
        {
            return JsonConvert.DeserializeObject<ErrorData>(RawResponse);
        }

    }
}
