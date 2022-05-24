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
    public class IMDbNewShowsServiceTests
    {
        private NewShowsServiceData _newShowsServiceData = new NewShowsServiceData();


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_NewShowsService_SearchCorrectlyInterpretsJSON()
        {
            IMDbNewShowsService service = new IMDbNewShowsService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            var result = service.ParseIMDbUpComingJSON(_newShowsServiceData.validIMDbJSON).Item1.ToList();
            List<IMDbUpComing> expected = _newShowsServiceData.expectedValidIMDbJSONResponse.items.ToList();
            CollectionAssert.AreEqual(expected, result);
        }


        [Test]
        public void Test_SearchService_Throws_ArgumentNullException_If_JSON_is_null()
        {
            IMDbNewShowsService service = new IMDbNewShowsService(new Mock<IHttpClientFactory>().Object, new APIKeyAccessor(""));

            Assert.Throws<ArgumentNullException>(delegate { service.ParseIMDbUpComingJSON(null); });
        }

    }
}
