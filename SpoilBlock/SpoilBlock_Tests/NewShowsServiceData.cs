using SpoilBlock.Models;
using SpoilBlock.Models.IMDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpoilBlock_Tests
{
    public class NewShowsServiceData
    {
        public readonly string validIMDbJSON = "{\"items\":[{\"id\":\"tt5108870\"title\":\"Morbius\",\"fullTitle\":\"Morbius(2022)\",\"year\":\"2022\",\"releaseState\":\"April 1\",\"image\":\"https://imdb-api.com/images/original/MV5BNWExYzEwY2UtZTNhYi00MDRjLTg4YzYtN2QzN2E3MjIwY2Q5XkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_Ratio0.6699_AL_.jpg\",\"runtimeMins\":\"108\",\"runtimeStr\":\"1h 48mins\",\"plot\":\"Biochemist Michael Morbius tries to cure himself of a rare blood disease, but he inadvertently infects himself with a form of vampirism instead.\",\"contentRating\":\"PG-13\",\"imDbRating\":\"\",\"imDbRatingCount\":\"\",\"metacriticRating\":\"\",\"genres\":\"Action, Adventure, Drama, Horror, Sci-Fi, Thriller\",\"genreList\":[{\"key\":\"Action\",\"value\":\"Action\"},{\"key\":\"Adventure\",\"value\":\"Adventure\"},{\"key\":\"Drama\",\"value\":\"Drama\"},{\"key\":\"Horror\",\"value\":\"Horror\"},{\"key\":\"Sci-Fi\",\"value\":\"Sci-Fi\"},{\"key\":\"Thriller\",\"value\":\"Thriller\"}],\"directors\":\"Daniel Espinosa\",\"directorList\":[{\"id\":\"nm1174251\",\"name\":\"Daniel Espinosa\"}],\"stars\":\"Jared Leto, Michael Keaton, Adria Arjona, Jared Harris\",\"starList\":[{\"id\":\"nm0001467\",\"name\":\"Jared Leto\"},{\"id\":\"nm0000474\",\"name\":\"Michael Keaton\"},{\"id\":\"nm5245722\",\"name\":\"Adria Arjona\"},{\"id\":\"nm0364813\",\"name\":\"Jared Harris\"}]}]}";
        
       public readonly string validIMDbJSONNoResultsErrorMessage = "{\"items\":[],\"errorMessage\":\"Some Error\"}";
        public readonly IMDbNewShows expectedValidIMDbJSONResponse = new IMDbNewShows
        {
            
            items = new List<IMDbUpComing>
            { new IMDbUpComing{
                id = "tt5108870",


                title   ="Morbius",
                fullTitle  = "Morbius (2022)",
                year    ="2022",
                releaseState =   "April 1",
                image   ="https://m.media-amazon.com/images/M/MV5BNWExYzEwY2UtZTNhYi00MDRjLTg4YzYtN2QzN2E3MjIwY2Q5XkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_UX128_CR0,4,128,176_AL_.jpg",
                runtimeMins= "108",
                runtimeStr=  "1h 48mins",
                plot    ="Biochemist Michael Morbius tries to cure himself of a rare blood disease, but he inadvertently infects himself with a form of vampirism instead.",
                contentRating  = "PG-13",
                imDbRating  ="",
                imDbRatingCount ="",
                metacriticRating  =  "",
                genres  ="Action, Adventure, Drama, Horror, Sci-Fi, Thriller",
                genreList = new List<GenreList>{
                 new GenreList
                 {
                  key = "Action",
                  value   ="Action"
                 },
                 new GenreList
                 {
                  key ="Adventure",
                  value   ="Adventure"
                 },
                 new GenreList
                 {
                  key = "Drama",
                  value   ="Drama"
                 },
                 new GenreList
                 {
                  key = "Horror",
                  value   ="Horror"
                 },
                 new GenreList
                 {
                  key = "Sci-Fi",
                  value   ="Sci-Fi"
                 },
                 new GenreList
                 {
                  key = "Thriller",
                  value   ="Thriller"
                 }
                },
                
                directors =  "Daniel Espinosa",
                directorList = new List<DirectorList>
                { 
                    new DirectorList
                    {
                        id = "nm1174251",
                        name    ="Daniel Espinosa",
                    }
                },
                
                
                stars   ="Jared Leto, Michael Keaton, Adria Arjona, Jared Harris",
                starList = new List<StarList>
                {
                    new StarList
                    {
                        id = "nm0001467",
                        name    ="Jared Leto"
                    },
                    new StarList
                    {
                        id =  "nm0000474",
                        name    ="Michael Keaton",
                    },
                    new StarList
                    {
                        id  ="nm5245722",
                        name    ="Adria Arjona",
                    },
                    new StarList
                    {
                        id = "nm0364813",
                        name    ="Jared Harris"
                    }
                }
            }
            }

        };
    }
}
