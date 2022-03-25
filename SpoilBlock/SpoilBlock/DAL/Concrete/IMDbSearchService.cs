using Newtonsoft.Json;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using SpoilBlock.Models.IMDb;
using System.Collections.Generic;
using System.Net;

namespace SpoilBlock.DAL.Concrete
{
    class InvalidJSONException : Exception
    {
        public InvalidJSONException(string message)
        {
            
        }
    }

    public class IMDbSearchService : IIMDbSearchService
    {
        private string _IMDbApiKey;
        private static readonly string _IMDbUrlBase = "https://imdb-api.com/en/API/SearchTitle/{0}/{1}";
        private readonly IHttpClientFactory _httpClientFactory;
        public IMDbSearchService(IHttpClientFactory factory, IAPIKeyAccessor accessor)
        {
            _httpClientFactory = factory;
            _IMDbApiKey = accessor.IMDbKey;
        }

        public async Task<Tuple<IEnumerable<IMDbEntry>, string?>> GetSearchResultsAsync(string search)
        {
            return ParseIMDbJSON(await SendRequestAsync(string.Format(_IMDbUrlBase, _IMDbApiKey, search)));
        }

        public  Tuple<IEnumerable<IMDbEntry>, string?> ParseIMDbJSON(string rawJSON)
        {
            if (rawJSON == null)
                throw new ArgumentNullException(nameof(rawJSON));
            else if (rawJSON.Length == 0)
                throw new ArgumentException("rawJSON was empty");

            IMDbResult? result;

            result = JsonConvert.DeserializeObject<IMDbResult>(rawJSON);

            if (result == null)
                throw new ArgumentException("rawJSON didn't parse correctly");

            string? errorMessage = result.errormessage;

            if (result.results == null) { throw new InvalidJSONException("The JSON parse didn't populate results"); }

            return new Tuple<IEnumerable<IMDbEntry>, string?>(result.results, errorMessage);
        }

        private async Task<string> SendRequestAsync(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("Get"), uri);
            HttpResponseMessage response = new HttpResponseMessage();

            var client = _httpClientFactory.CreateClient();

            response = await client.SendAsync(request);

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
