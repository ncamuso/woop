using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using SpoilBlock.Models;

namespace SpoilBlock.Models.ViewModels
{
    public class WatchlistViewModel
    {

        public bool HasWoopUser { get; set; }

        public string Username { get; set; }

        public bool IsEmpty { get; set; }

        public  IEnumerable<Medium> AllShows { get; set; }
        public IEnumerable<int> Levels { get; set; }


        //public void GetLevel(int id)
        //{ 
        //    foreach(var show in AllShows)
        //    if()
        //}

        public WatchlistViewModel()
        { 
            HasWoopUser = false;
            Username = String.Empty;
            AllShows = new List<Medium>();
            Levels = new List<int>();

        }

        

    }
}
