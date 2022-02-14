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
            IMDbSearchService service = new IMDbSearchService("");

            List<IMDbEntry> result = service.ParseIMDbJSON(_searchServiceData.validIMDbJSON).ToList();
            List<IMDbEntry> expected = _searchServiceData.expectedValidIMDbJSONResponse.results.ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_SearchService_SearchReturnsEmptyListIfNoResults()
        {
            IMDbSearchService service = new IMDbSearchService("");

            List<IMDbEntry> result = service.ParseIMDbJSON(_searchServiceData.validIMDbJSONNoResults).ToList();
            List<IMDbEntry> expected = new List<IMDbEntry>();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Test_SearchService_SearchReturnsEmptyListIfErrorMessage()
        {
            IMDbSearchService service = new IMDbSearchService("");

            List<IMDbEntry> result = service.ParseIMDbJSON(_searchServiceData.validIMDbJSONNoResultsErrorMessage).ToList();
            List<IMDbEntry> expected = new List<IMDbEntry>();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
