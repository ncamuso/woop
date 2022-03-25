using Newtonsoft.Json;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using SpoilBlock.Models.IMDb;
using System.Collections.Generic;
using System.Net;

namespace SpoilBlock.DAL.Concrete
{
    public class IMDbNewShowsService: IIMDbNewShowsService
    {
        private readonly string _IMDbApiKey; 
        private static readonly string _IMDbUrlBase = "https://imdb-api.com/en/API/ComingSoon/{0}";
        private readonly IHttpClientFactory _httpClientFactory;

        public IMDbNewShowsService(IHttpClientFactory factory, IAPIKeyAccessor accessor)
        {
            _httpClientFactory = factory;
            _IMDbApiKey = accessor.IMDbKey;
        }

        public async Task<Tuple<IEnumerable<IMDbUpComing>, string?>> GetNewShowsResult()
        {
            return ParseIMDbUpComingJSON(await SendUpComingRequestAsync(string.Format(_IMDbUrlBase, _IMDbApiKey)));
        }

        public Tuple<IEnumerable<IMDbUpComing>, string?> ParseIMDbUpComingJSON(string rawJSON)
        {
            if (rawJSON == null)
                throw new ArgumentNullException(nameof(rawJSON));
            else if (rawJSON.Length == 0)
                throw new ArgumentException("rawJSON was empty");


            IMDbNewShows result;

            result = JsonConvert.DeserializeObject<IMDbNewShows>(rawJSON);

            if (result == null)
                throw new ArgumentException("rawJSON didn't parse correctly");

            string? errorMessage = result.errorMessage;

            if (result.items == null) { throw new InvalidJSONException("The JSON parse didn't populate results"); }

            return new Tuple<IEnumerable<IMDbUpComing>, string?>(result.items, errorMessage);
        }

        private async Task<string> SendUpComingRequestAsync(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("Get"), uri);
            HttpResponseMessage response = new HttpResponseMessage();
            
            
            var client = _httpClientFactory.CreateClient();
            
            response =  await client.SendAsync(request);

            return response.Content.ReadAsStringAsync().Result;
        }
    }

    
}
