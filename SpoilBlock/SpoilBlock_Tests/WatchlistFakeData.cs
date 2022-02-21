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
    public class WatchlistFakeData
    {
        public static readonly List<User> Users = new List<User>
        {
            new User{Id = 1, Username= "AnkitSth" }
        };

        public static readonly List<Medium> MediumList = new List<Medium>
        {
            new Medium{Id = 1, Imdbid= 1, Title= "The Green Mile"},
            new Medium{Id = 2, Imdbid= 2, Title= "Deadpool"}
        };

        public static readonly List<UserMedium> UserMediumList = new List<UserMedium>
        {
            new UserMedium{Id = 1,BlockageLevel= 0, UserId= 1,MediaId=1 },
            new UserMedium{Id = 2,BlockageLevel= 1, UserId= 1,MediaId=2 }
        };

        static WatchlistFakeData()
        {
            UserMediumList.ForEach(um =>
            {
                um.User = Users.Single(u => u.Id == um.UserId);
                um.Media = MediumList.Single(m => m.Id == um.MediaId);
            });

            MediumList.ForEach(m =>
            {
                m.UserMedia = UserMediumList.Where(um => um.MediaId == m.Id).ToList();
            });

            Users.ForEach(u =>
            { 
                u.UserMedia = UserMediumList.Where(um => um.UserId == u.Id).ToList();
            });

        }
    }
}
