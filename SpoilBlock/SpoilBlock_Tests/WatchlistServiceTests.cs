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
        private Mock<DbSet<UserMedium>> _mockUserMediumDbSet;
        private List<User> _users = WatchlistFakeData.Users;
        private List<Medium> _medium = WatchlistFakeData.MediumList;
        private List<UserMedium> userMedia = WatchlistFakeData.UserMediumList;

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
            _mockContext.Setup(ctx => ctx.UserMedia).Returns(_mockUserMediumDbSet.Object);
            _mockContext.Setup(ctx => ctx.Set<UserMedium>()).Returns(_mockUserMediumDbSet.Object);

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
            IUserMediumRepository umRepo = new UserMediumRepository(_mockContext.Object);
            int userId = 1;
            var expectedList = new List<UserMedium>
            {
                new UserMedium{ Id = 1, BlockageLevel = 0 , UserId=1, MediaId =1 },
                new UserMedium{ Id = 1, BlockageLevel = 1 , UserId=1, MediaId =2 }
            };

            //Act
            IEnumerable<UserMedium> actualList = umRepo.GetListOfShowsForUser(userId);
            //Assert

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedList, actualList);
            }
                
                );
        }
    }
}
