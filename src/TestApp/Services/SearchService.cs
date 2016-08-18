using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TestApp.Models;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TestApp.Services
{
    public class SearchService : ISearchService
    {
        private IConfigurationRoot _configuration;

        public SearchService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public async Task<SearchResultsModel> RunSearch(SearchModel search)
        {
            var uri = CreateUriFromParams(search);
            var resultXml = await GetResultFromClient(uri);
            var result = new SearchResultsModel(resultXml);
            return result;
        }

        private async Task<string> GetResultFromClient(Uri uri)
        {
            using (var client = new HttpClient())
            {               
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new HttpRequestException($"{response.StatusCode} Fatal Error: {response.ReasonPhrase}");
                }
            }
        } 

        private Uri CreateUriFromParams(SearchModel search)
        {
            var baseUri = _configuration["SearchCfg:BaseUri"];
            var apiKey = _configuration["SearchCfg:Key"];
            var address = WebUtility.UrlEncode(search.Address);
            var cityStateZip = WebUtility.UrlEncode(search.CityStateZip);

            var buildUri = new StringBuilder(baseUri);
            buildUri.AppendFormat("?zws-id={0}&address={1}&citystatezip={2}", apiKey, address, cityStateZip);
            if (search.RentzEstimate)
                buildUri.Append("&rentzestimate=true");

            return new Uri(buildUri.ToString());
        }
    }
}
