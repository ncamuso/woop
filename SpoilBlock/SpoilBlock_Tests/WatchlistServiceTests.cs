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
using Microsoft.EntityFrameworkCore;

namespace SpoilBlock_Tests
{
    public class WatchlistServiceTests
    {
        private Mock<WOOPDbContext> _mockContext;
        private Mock<DbSet<WoopuserMedium>> _mockUserMediumDbSet;
        private List<Woopuser> _users = WatchlistFakeData.UsersList;
        private List<Medium> _medium = WatchlistFakeData.MediumList;
        private List<WoopuserMedium> userMedia = WatchlistFakeData.UserMediumList;

        private Mock<DbSet<T>> GetMockDbSet<T>(IQueryable<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());
            return mockSet;
        }

        [SetUp]
        public void Setup()
        {
            _mockUserMediumDbSet = GetMockDbSet(userMedia.AsQueryable());
            _mockUserMediumDbSet.Setup(a => a.Find(It.IsAny<object[]>())).Returns((object[] x) =>
            {
                int id = (int)x[0];
                return userMedia.Where(c => c.Id == id).First();
            });

            _mockContext = new Mock<WOOPDbContext>();
            _mockContext.Setup(ctx => ctx.WoopuserMedia).Returns(_mockUserMediumDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<WoopuserMedium>()).Returns(_mockUserMediumDbSet.Object);

        }

        [Test]
        public void SanityTest()
        {
            Assert.Pass();
        }

        [Test]
        public void UserMediumRepository_GetListOfShowsForUser_Should_ReturnUserAndTheirListOfMedias()
        {
            // Arrange
            IWoopUserMediumRepository umRepo = new WoopUserMediumRepository(_mockContext.Object);
            int userId = 1;
            var expectedList = new List<Medium>
            {
                new Medium{Id = 1, Imdbid= "as0110912", Title= "The Green Mile"},
                new Medium{Id = 2, Imdbid= "tgf010912", Title= "Deadpool"}
            };

            //Act
            IEnumerable<Medium> actualList = umRepo.GetListOfShowsForUser(userId);
            

            
                Assert.That(actualList.Count(), Is.EqualTo(expectedList.Count));
                foreach (var a in expectedList)
                {
                    Assert.That(actualList.Any(i => i.Title.Equals(a.Title)));
               };
        }


    }
}
