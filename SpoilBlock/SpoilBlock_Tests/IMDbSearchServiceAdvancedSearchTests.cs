using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpoilBlock.DAL.Concrete;
using Moq;

namespace SpoilBlock_Tests
{
    public class IMDbSearchServiceAdvancedSearchTests
    {
        public Mock<IHttpClientFactory> _mockFactory;
        public APIKeyAccessor _fakeAccessor;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AdvancedSearch_InvalidQueryObject_ThrowsException()
        {
            //Arrange
            IMDbSearchService service = new IMDbSearchService(_mockFactory.Object, _fakeAccessor);

            //Act
            //Pass the AdvancedSearch method an invalid object

            //Assert that it throws an exception, probably a custom one
        }

        [Test]
        public void AdvancedSearch_ValidQueryObject_InvalidResponse_ThrowsException()
        {
            // Arrange (give it an httpclient that will throw an httprequest exception)
            IMDbSearchService service = new IMDbSearchService(_mockFactory.Object, _fakeAccessor);


            // Act
            //Pass the service a valid object

            //Assert
            //Assert that it throws an httprequest exception
        }

        [Test]
        public void AdvancedSearch_ValidQuery_ValidResponse_ParsesDataCorrectly()
        {
            // Arrange (setup the httpclient to return some valid JSON data)
            IMDbSearchService service = new IMDbSearchService(_mockFactory.Object, _fakeAccessor);

            // Act
            // Pass the service a valid request and get the response back

            // Assert
            //Assert that the list of IMDb results returned are correct based on the setup.
        }

        [Test]
        public void AdvancedSearch_ValidQuery_ErrormessagefromIMDb_returnsCorrectError()
        {
            // Arrange (set up the httpclient to return valid JSON but with an error message
            IMDbSearchService service = new IMDbSearchService(_mockFactory.Object, _fakeAccessor);

            // Act
            // Pass the service a valid request and get the response back

            // Assert
            //Assert the response contains the expected error message correctly without excepting
        }
    }
}
