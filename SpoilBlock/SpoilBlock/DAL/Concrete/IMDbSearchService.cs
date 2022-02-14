using Newtonsoft.Json;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.Models;
using SpoilBlock.Models.IMDb;
using System.Collections.Generic;
using System.Net;

namespace SpoilBlock.DAL.Concrete
{
    public class IMDbSearchService : IIMDbSearchService
    {
        private readonly string _IMDbApiKey;
        private static readonly string _IMDbUrlBase = "https://imdb-api.com/en/API/SearchTitle/{0}/{1}";
        private static readonly HttpClient _httpClient = new HttpClient();
        public IMDbSearchService(string IMDbApiKey)
        {
            _IMDbApiKey = IMDbApiKey;
        }

        public IEnumerable<IMDbEntry> GetSearchResults(string search)
        {
            return ParseIMDbJSON(SendRequest(string.Format(_IMDbUrlBase, _IMDbApiKey, search)));
        }

        public IEnumerable<IMDbEntry> ParseIMDbJSON(string rawJSON)
        {
            if(rawJSON == null || rawJSON == "") { return new List<IMDbEntry>(); }
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
            //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
