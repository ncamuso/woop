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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using SpoilBlock.Controllers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace SpoilBlock_Tests
{
    public class AddControllerTests
    {
        private Mock<IWoopuserRepository> _mockwoopUserRepository;
        private Mock<IMediumRepository> _mockmediumRepository;
        private Mock<IWoopUserMediumRepository> _mockwoopUserMediumRepository;
        private Mock<IHttpContextAccessor> _mockhttpContextAccessor;
        private List<Medium> testWatchlist;

        [SetUp]
        public void Setup()
        {
            _mockwoopUserRepository = new Mock<IWoopuserRepository>();
            _mockmediumRepository = new Mock<IMediumRepository>();
            _mockwoopUserMediumRepository = new Mock<IWoopUserMediumRepository>();
            _mockhttpContextAccessor = new Mock<IHttpContextAccessor>();

            Woopuser testUser = new Woopuser { AspnetIdentityId = "12345", Id = 12345, Username = "Carol" };
            _mockwoopUserRepository.Setup(a => a.GetWoopUserByIdentityIdAsync(It.IsAny<string>())).ReturnsAsync(testUser);


            testWatchlist = new List<Medium>{ new Medium { Id = 1, Imdbid = "as0110912", Title = "The Green Mile" } };

            _mockwoopUserMediumRepository.Setup(a => a.GetListOfShowsForUser(12345)).Returns(testWatchlist);
            _mockwoopUserMediumRepository.Setup(a => a.AddOrUpdate(It.IsAny<WoopuserMedium>())).Callback((WoopuserMedium m) => testWatchlist.Add(m.Media));
            _mockwoopUserMediumRepository.Setup(a => a.GetAll()).Returns(new List<WoopuserMedium>() { new WoopuserMedium {MediaId = 1, Id = 1, UserId=12345, Media = new Medium { Id = 1, Imdbid = "as0110912", Title = "The Green Mile" } } }.AsQueryable);
            _mockwoopUserMediumRepository.Setup(a => a.DeleteById(1)).Callback((int i) => testWatchlist.Remove(testWatchlist.FirstOrDefault()));

            _mockmediumRepository.Setup(a => a.ExistsByImdbID("as0110912")).Returns(true);
            _mockmediumRepository.Setup(a => a.FindByImdbID("as0110912")).Returns(testWatchlist.Find(m => m.Id == 1));
            _mockmediumRepository.Setup(a => a.FindByImdbID("tgf010912")).Returns(new Medium { Id = 2, Imdbid = "tgf010912", Title = "Deadpool" });
            _mockmediumRepository.Setup(a => a.AddOrUpdate(It.IsAny<Medium>())).Returns(new Medium { Id = 2, Imdbid = "tgf010912", Title = "Deadpool" });



            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal();
            var identity = new ClaimsIdentity(new List<Claim> { new Claim(ClaimTypes.NameIdentifier, "12345") });
            context.User.AddIdentity(identity);

            _mockhttpContextAccessor.Setup(a => a.HttpContext).Returns(context);
        }

        [Test]
        public async Task TestAddController_GetCurrentWatchlistIDs_ReturnsCorrectValue()
        {
            AddController controller = new AddController(_mockwoopUserRepository.Object, _mockmediumRepository.Object, _mockwoopUserMediumRepository.Object, _mockhttpContextAccessor.Object);

            var result = await controller.GetCurrentWatchListIDs();

            var list = JsonConvert.SerializeObject(new List<string> { "as0110912" });

            var expected = controller.Json(new { success = true, message = "OK", list = list });

            Assert.That(JsonConvert.SerializeObject(result.Value).Equals(JsonConvert.SerializeObject(expected.Value)));
        }

        [Test]
        public async Task AddController_AddMediaToWatchlist_AddsMedia()
        {
            AddController controller = new AddController(_mockwoopUserRepository.Object, _mockmediumRepository.Object, _mockwoopUserMediumRepository.Object, _mockhttpContextAccessor.Object);

            await controller.AddMediaToWatchlist("{ Id: 2, Imdbid: \"tgf010912\", Title:  \"Deadpool\"}");

            Assert.IsTrue(testWatchlist.Exists(a => a.Id == 2));
        }

        [Test]
        public async Task AddController_DeleteMediaFromWatchlist_DeletesMedia()
        {
            AddController controller = new AddController(_mockwoopUserRepository.Object, _mockmediumRepository.Object, _mockwoopUserMediumRepository.Object, _mockhttpContextAccessor.Object);

            await controller.DeleteShowFromWatchlist("1");

            Assert.IsTrue(testWatchlist.Count == 0);
        }

        [Test]
        public async Task AddController_GetMediaStatus_GetsStatus()
        {
            AddController controller = new AddController(_mockwoopUserRepository.Object, _mockmediumRepository.Object, _mockwoopUserMediumRepository.Object, _mockhttpContextAccessor.Object);

            var result = await controller.GetMediaStatuses();

            var list = JsonConvert.SerializeObject(new List<Object> { new { MediaId = 1, BlockageLevel = 0 } });

            var expected = controller.Json(new { success = true, message = "OK", list = list });

            Assert.That(JsonConvert.SerializeObject(result.Value).Equals(JsonConvert.SerializeObject(expected.Value)));
        }

    }
}
