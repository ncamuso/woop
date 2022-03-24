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

        public async Task<Tuple<IEnumerable<IMDbEntry>, string?>> GetNewShowsResult()
        {
            return (Tuple<IEnumerable<IMDbEntry>, string?>)ParseIMDbJSON(await SendRequestAsync(string.Format(_IMDbUrlBase, _IMDbApiKey)));
        }

        public IEnumerable<IMDbEntry> ParseIMDbJSON(string rawJSON)
        {
            if (rawJSON == null || rawJSON == "") { return new List<IMDbEntry>(); }
            IMDbResult? result;

            try
            {
                result = JsonConvert.DeserializeObject<IMDbResult>(rawJSON);
            }
            catch (Exception e)
            {
                return new List<IMDbEntry>();
            }


            if (result == null) { return new List<IMDbEntry>(); }
            else if (result.errormessage != "") { return new List<IMDbEntry>(); }

            return result.results;
        }

        private async Task<string> SendRequestAsync(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("Get"), uri);
            HttpResponseMessage response = new HttpResponseMessage();
            
            
            var client = _httpClientFactory.CreateClient();
            
            response =  await client.SendAsync(request);

            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
