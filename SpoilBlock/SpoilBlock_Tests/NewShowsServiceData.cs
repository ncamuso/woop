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
        public readonly string validIMDbJSON = "{\"items\":[{\"id\":\"tt1745960\",\"title\":\"Top Gun: Maverick\",\"fullTitle\":\"Top Gun: Maverick (2022)\",\"year\":\"2022\",\"releaseState\":\"May 27\",\"image\":\"https://m.media-amazon.com/images/M/MV5BMmIwZDMyYWUtNTU0ZS00ODJhLTg2ZmEtMTk5ZmYzODcxODYxXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_UX128_CR0,4,128,176_AL_.jpg\",\"runtimeMins\":\"131\",\"runtimeStr\":\"2h 11mins\",\"plot\":\"After more than thirty years of service as one of the Navy's top aviators, Pete Mitchell is where he belongs, pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him.\",\"contentRating\":\"PG-13\",\"imDbRating\":\"\",\"imDbRatingCount\":\"\",\"metacriticRating\":\"80\",\"genres\":\"Action, Drama\",\"genreList\":[{\"key\":\"Action\",\"value\":\"Action\"},{\"key\":\"Drama\",\"value\":\"Drama\"}],\"directors\":\"Joseph Kosinski\",\"directorList\":[{\"id\":\"nm2676052\",\"name\":\"Joseph Kosinski\"}],\"stars\":\"Tom Cruise, Jennifer Connelly, Miles Teller, Monica Barbaro\",\"starList\":[{\"id\":\"nm0000129\",\"name\":\"Tom Cruise\"},{\"id\":\"nm0000124\",\"name\":\"Jennifer Connelly\"},{\"id\":\"nm1886602\",\"name\":\"Miles Teller\"},{\"id\":\"nm4834815\",\"name\":\"Monica Barbaro\"}]},{\"id\":\"tt7466442\",\"title\":\"The Bob's Burgers Movie\",\"fullTitle\":\"The Bob's Burgers Movie (2022)\",\"year\":\"2022\",\"releaseState\":\"May 27\",\"image\":\"https://m.media-amazon.com/images/M/MV5BYzFhNDNkY2UtYjc3ZS00NzVkLTlhNzEtYmZiZGMzYmRjMjVhXkEyXkFqcGdeQXVyMjQwMDg0Ng@@._V1_UX128_CR0,4,128,176_AL_.jpg\",\"runtimeMins\":\"102\",\"runtimeStr\":\"1h 42mins\",\"plot\":\"The Belchers try to save the restaurant from closing as a sinkhole forms in front of it, while the kids try to solve a mystery that could save their family's restaurant.\",\"contentRating\":\"PG-13\",\"imDbRating\":\"\",\"imDbRatingCount\":\"\",\"metacriticRating\":\"\",\"genres\":\"Animation, Adventure, Comedy, Musical\",\"genreList\":[{\"key\":\"Animation\",\"value\":\"Animation\"},{\"key\":\"Adventure\",\"value\":\"Adventure\"},{\"key\":\"Comedy\",\"value\":\"Comedy\"},{\"key\":\"Musical\",\"value\":\"Musical\"}],\"directors\":\"Loren Bouchard, Bernard Derriman\",\"directorList\":[{\"id\":\"nm0098908\",\"name\":\"Loren Bouchard\"},{\"id\":\"nm0220615\",\"name\":\"Bernard Derriman\"}],\"stars\":\"H. Jon Benjamin, Kristen Schaal, Dan Mintz, Stephanie Beatriz\",\"starList\":[{\"id\":\"nm0071304\",\"name\":\"H. Jon Benjamin\"},{\"id\":\"nm1102891\",\"name\":\"Kristen Schaal\"},{\"id\":\"nm2089814\",\"name\":\"Dan Mintz\"},{\"id\":\"nm3715867\",\"name\":\"Stephanie Beatriz\"}]}],\"errorMessage\":\"\"}";

        public readonly string invalidAPIKeyErrorMessage = "{\"items\":[],\"errorMessage\":\"Invalid API Key\"}";
        public readonly IMDbNewShows expectedValidIMDbJSONResponse = new IMDbNewShows
        {
            
            items = new List<IMDbUpComing>
            {
                new IMDbUpComing
                {
                    id = "tt1745960",
                    title = "Top Gun: Maverick",
                    fullTitle = "Top Gun: Maverick (2022)",
                    year = "2022",
                    releaseState = "May 27",
                    image = "https://m.media-amazon.com/images/M/MV5BMmIwZDMyYWUtNTU0ZS00ODJhLTg2ZmEtMTk5ZmYzODcxODYxXkEyXkFqcGdeQXVyMTEyMjM2NDc2._V1_UX128_CR0,4,128,176_AL_.jpg",
                    runtimeMins = "131",
                    runtimeStr = "2h 11mins",
                    plot = "After more than thirty years of service as one of the Navy's top aviators, Pete Mitchell is where he belongs, pushing the envelope as a courageous test pilot and dodging the advancement in rank that would ground him.",
                    contentRating = "PG-13",
                    imDbRating = "",
                    imDbRatingCount = "",
                    metacriticRating = "80",
                    genres  ="Action, Drama",
                    genreList = new List<GenreList>{
                     new GenreList
                     {
                      key = "Action",
                      value = "Action"
                     },
                     new GenreList
                     {
                      key = "Drama",
                      value = "Drama"
                     }
                    },

                    directors = "Joseph Kosinski",
                    directorList = new List<DirectorList>
                    {
                        new DirectorList
                        {
                            id = "nm2676052",
                            name = "Joseph Kosinski"
                        }
                    },
                    stars = "Tom Cruise, Jennifer Con… Teller, Monica Barbaro",
                    starList = new List<StarList>
                    {
                        new StarList
                        {
                            id = "nm0000129",
                            name = "Tom Cruise"
                        },
                        new StarList
                        {
                            id = "nm0000124",
                            name = "Jennifer Connelly"
                        },
                        new StarList
                        {
                            id = "nm1886602",
                            name = "Miles Teller"
                        },
                        new StarList
                        {
                            id = "nm4834815",
                            name = "Monica Barbaro"
                        }
                    }
                },
                new IMDbUpComing
                {
                    id = "tt7466442",
                    title = "The Bob's Burgers Movie",
                    fullTitle = "The Bob's Burgers Movie (2022)",
                    year = "2022",
                    releaseState = "May 27",
                    image = "https://m.media-amazon.c…28_CR0,4,128,176_AL_.jpg",
                    runtimeMins = "102",
                    runtimeStr = "1h 42mins",
                    plot = "The Belchers try to save the restaurant from closing as a sinkhole forms in front of it, while the kids try to solve a mystery that could save their family's restaurant.",
                    contentRating = "PG-13",
                    imDbRating = "",
                    imDbRatingCount = "",
                    metacriticRating = "",
                    genres  ="Animation, Adventure, Comedy, Musical",
                    genreList = new List<GenreList>{
                     new GenreList
                     {
                      key = "Animation",
                      value = "Animation"
                     },
                     new GenreList
                     {
                      key = "Adventure",
                      value = "Adventure"
                     },
                     new GenreList
                     {
                      key = "Comedy",
                      value = "Comedy"
                     },
                     new GenreList
                     {
                      key = "Musical",
                      value = "Musical"
                     }
                    },

                    directors = "Loren Bouchard, Bernard Derriman",
                    directorList = new List<DirectorList>
                    {
                        new DirectorList
                        {
                            id = "nm0098908",
                            name = "Loren Bouchard"
                        },
                        new DirectorList
                        {
                            id = "nm0220615",
                            name = "Bernard Derriman"
                        }
                    },
                    stars = "H. Jon Benjamin, Kristen Schaal, Dan Mintz, Stephanie Beatriz",
                    starList = new List<StarList>
                    {
                        new StarList
                        {
                            id = "nm0071304",
                            name = "H. Jon Benjamin"
                        },
                        new StarList
                        {
                            id = "nm1102891",
                            name = "Kristen Schaal"
                        },
                        new StarList
                        {
                            id = "nm2089814",
                            name = "Dan Mintz"
                        },
                        new StarList
                        {
                            id = "nm3715867",
                            name = "Stephanie Beatriz"
                        }
                    }
                }
            },
            errormessage = ""
        };
    }
}
