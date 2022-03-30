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
        public static readonly List<Woopuser> UsersList = new List<Woopuser>
        {
            new Woopuser{Id = 1, Username= "AnkitSth" },
            new Woopuser{Id = 2, Username= "Nathan" }
        };

        public static readonly List<Medium> MediumList = new List<Medium>
        {
            new Medium{Id = 1, Imdbid= "as0110912", Title= "The Green Mile"},
            new Medium{Id = 2, Imdbid= "tgf010912", Title= "Deadpool"},
            new Medium{Id = 3, Imdbid= "teh110912", Title= "Deadpool-2"},
            new Medium{Id = 4, Imdbid= "ww0160934", Title= "Batman Begins"}

        };

        public static readonly List<WoopuserMedium> UserMediumList = new List<WoopuserMedium>
        {
            new WoopuserMedium{Id = 1,BlockageLevel= 0, UserId= 1,MediaId=1 },
            new WoopuserMedium{Id = 2,BlockageLevel= 1, UserId= 1,MediaId=2 },
            new WoopuserMedium{Id = 3,BlockageLevel= 2, UserId= 2,MediaId=3 }
        };

        static WatchlistFakeData()
        {
            UserMediumList.ForEach(um =>
            {
                um.User = UsersList.Single(u => u.Id == um.UserId);
                um.Media = MediumList.Single(m => m.Id == um.MediaId);
            });

            MediumList.ForEach(m =>
            {
                m.WoopuserMedia = UserMediumList.Where(um => um.MediaId == m.Id).ToList();
            });

            UsersList.ForEach(u =>
            { 
                u.WoopuserMedia = UserMediumList.Where(um => um.UserId == u.Id).ToList();
            });

        }
    }
}
