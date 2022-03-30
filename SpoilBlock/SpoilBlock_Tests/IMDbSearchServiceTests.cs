using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SpoilBlock.DAL.Abstract;
using SpoilBlock.DAL.Concrete;
using SpoilBlock.Models;
using System.Net.Http;
using Moq.Contrib.HttpClient;

namespace SpoilBlock_Tests
{
    public class IMDbSearchServiceTests
    {
        private SearchServiceData _searchServiceData = new SearchServiceData();

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test_SearchService_SearchCorrectlyInterpretsJSON()
        {
            IMDbSearchService service = new IMDbSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            var result = service.ParseIMDbJSON(_searchServiceData.validIMDbJSON).Item1.ToList();
            List<IMDbEntry> expected = _searchServiceData.expectedValidIMDbJSONResponse.results.ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_SearchService_SearchReturnsEmptyListIfNoResults()
        {
            IMDbSearchService service = new IMDbSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            List<IMDbEntry> result = service.ParseIMDbJSON(_searchServiceData.validIMDbJSONNoResults).Item1.ToList();
            List<IMDbEntry> expected = new List<IMDbEntry>();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_SearchService_Throws_ArgumentNullException_If_JSON_is_null()
        {
            IMDbSearchService service = new IMDbSearchService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            Assert.Throws<ArgumentNullException>(delegate { service.ParseIMDbJSON(null!); });
        }


    }
}
