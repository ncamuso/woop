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
        private readonly string _IMDbApiKey; //k_8fxastb5
        private static readonly string _IMDbUrlBase = "https://imdb-api.com/en/API/ComingSoon/{0}";
        private static readonly HttpClient _httpClient = new HttpClient();

        public IMDbNewShowsService(string IMDbApiKey)
        {
            _IMDbApiKey = IMDbApiKey;
        }

        public IEnumerable<IMDbEntry> GetNewShowsResult()
        {
            return ParseIMDbJSON(SendRequest(string.Format(_IMDbUrlBase, _IMDbApiKey)));
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

        private string SendRequest(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("Get"), uri);
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = _httpClient.Send(request);
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
