using SpoilBlock.Models;
using SpoilBlock.Models.IMDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpoilBlock_Tests
{
    public class SearchServiceData
    {
        public readonly string validIMDbJSON = "{\"searchType\":\"Title\",\"expression\":\"inception 2010\",\"results\":[{\"id\":\"tt1375666\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_Ratio0.6800_AL_.jpg\",\"title\":\"Inception\",\"description\":\"(2010)\"},{\"id\":\"tt1790736\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/MV5BMjE0NGIwM2EtZjQxZi00ZTE5LWExN2MtNDBlMjY1ZmZkYjU3XkEyXkFqcGdeQXVyNjMwNzk3Mjk@._V1_Ratio0.6800_AL_.jpg\",\"title\":\"Inception: Motion Comics\",\"description\":\"(2010 Video)\"},{ \"id\":\"tt5295990\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/MV5BZGFjOTRiYjgtYjEzMS00ZjQ2LTkzY2YtOGQ0NDI2NTVjOGFmXkEyXkFqcGdeQXVyNDQ5MDYzMTk@._V1_Ratio0.6800_AL_.jpg\",\"title\":\"Inception: Jump Right Into the Action\",\"description\":\"(2010 Video)\"},{ \"id\":\"tt1686778\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Inception: 4Movie Premiere Special\",\"description\":\"(2010 TV Movie)\"},{ \"id\":\"tt12960252\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Inception Premiere\",\"description\":\"(2010)\"},{ \"id\":\"tt1690359\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"ReelzChannel Spotlight\",\"description\":\"(2009– )\"},{ \"id\":\"tt1695201\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"HBO First Look\",\"description\":\"(1992– )\"},{ \"id\":\"tt1698324\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"At the Movies\",\"description\":\"(1986–2010)\"},{ \"id\":\"tt1701913\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"The Rotten Tomatoes Show\",\"description\":\"(2009– )\"},{ \"id\":\"tt17676648\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Comedy Film Nerds\",\"description\":\"(2009–2019)\"},{ \"id\":\"tt1799669\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Bum Reviews\",\"description\":\"(2008– )\"},{ \"id\":\"tt1805871\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Elevator\",\"description\":\"(2007– )\"},{ \"id\":\"tt1886283\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"The Distressed Watcher\",\"description\":\"(2010–2011)\"},{ \"id\":\"tt2078432\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Travel Companions\",\"description\":\"(2010–2012)\"},{ \"id\":\"tt2135194\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Hollywood on Set\",\"description\":\"(2003– )\"},{ \"id\":\"tt2135220\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Hollywood on Set\",\"description\":\"(2003– )\"},{ \"id\":\"tt2160855\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/MV5BODdiMzIzMjEtMjE1MC00ZjY0LWE1NTctOGYwMWYwMTQzNGE0XkEyXkFqcGdeQXVyMjg2MTMyNTM@._V1_Ratio1.7600_AL_.jpg\",\"title\":\"How It Should Have Ended\",\"description\":\"(2005– )\"},{ \"id\":\"tt2242729\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"The Angry Joe Show\",\"description\":\"(2009– )\"},{ \"id\":\"tt2278249\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Richard Roeper & the Movies\",\"description\":\"(2009– )\"},{ \"id\":\"tt2278251\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Richard Roeper & the Movies\",\"description\":\"(2009– )\"},{ \"id\":\"tt2386167\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"YourGeekNews.com\",\"description\":\"(2010– )\"},{ \"id\":\"tt3022202\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Zoom In\",\"description\":\"(2008– )\"},{ \"id\":\"tt3227032\",\"resultType\":\"Title\",\"image\":\"https://imdb-api.com/images/original/nopicture.jpg\",\"title\":\"Sorties Savantes\",\"description\":\"(2010–2013)\"}],\"errorMessage\":\"\"}";
        public readonly string validIMDbJSONNoResults = "{ \"searchType\":\"Title\", \"expression\":\"hjdhfasjf\", \"results\":[],\"errorMessage\":\"\"}";
        public readonly string validIMDbJSONNoResultsErrorMessage = "{ \"searchType\":\"Title\", \"expression\":\"hjdhfasjf\", \"results\":[],\"errorMessage\":\"SomeError\"}";
        public readonly IMDbResult expectedValidIMDbJSONResponse = new IMDbResult
        {
            searchType = "Title",
            expression = "inception 2010",
            results = new List<IMDbEntry>{
            new IMDbEntry{
                id = "tt1375666",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_Ratio0.6800_AL_.jpg",
                title = "Inception",
                description = "(2010)"
            },
            new IMDbEntry{
                id = "tt1790736",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/MV5BMjE0NGIwM2EtZjQxZi00ZTE5LWExN2MtNDBlMjY1ZmZkYjU3XkEyXkFqcGdeQXVyNjMwNzk3Mjk@._V1_Ratio0.6800_AL_.jpg",
                title = "Inception: Motion Comics",
                description = "(2010 Video)"
            },
            new IMDbEntry
            {
                id = "tt5295990",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/MV5BZGFjOTRiYjgtYjEzMS00ZjQ2LTkzY2YtOGQ0NDI2NTVjOGFmXkEyXkFqcGdeQXVyNDQ5MDYzMTk@._V1_Ratio0.6800_AL_.jpg",
                title = "Inception: Jump Right Into the Action",
                description = "(2010 Video)"
            },
            new IMDbEntry
            {
                id = "tt1686778",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Inception: 4Movie Premiere Special",
                description = "(2010 TV Movie)"
            },
            new IMDbEntry
            {
                id = "tt12960252",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Inception Premiere",
                description = "(2010)"
            },
            new IMDbEntry
            {
                id = "tt1690359",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "ReelzChannel Spotlight",
                description = "(2009– )"
            },
            new IMDbEntry
            {
                id = "tt1695201",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "HBO First Look",
                description = "(1992– )"
            },
            new IMDbEntry
            {
                id = "tt1698324",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "At the Movies",
                description = "(1986–2010)"
            },
            new IMDbEntry
            {
                id = "tt1701913",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "The Rotten Tomatoes Show",
                description = "(2009– )"
            },
            new IMDbEntry
            {
                id = "tt17676648",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Comedy Film Nerds",
                description = "(2009–2019)"
            },
            new IMDbEntry
            {
                id = "tt1799669",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Bum Reviews",
                description = "(2008– )"
            },
            new IMDbEntry
            {
                id = "tt1805871",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Elevator",
                description = "(2007– )"
            },
            new IMDbEntry
            {
                id = "tt1886283",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "The Distressed Watcher",
                description = "(2010–2011)"
            },
            new IMDbEntry
            {
                id = "tt2078432",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Travel Companions",
                description = "(2010–2012)"
            },
            new IMDbEntry
            {
                id = "tt2135194",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Hollywood on Set",
                description = "(2003– )"
            },
            new IMDbEntry
            {
                id = "tt2135220",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Hollywood on Set",
                description = "(2003– )"
            },
            new IMDbEntry
            {
                id = "tt2160855",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/MV5BODdiMzIzMjEtMjE1MC00ZjY0LWE1NTctOGYwMWYwMTQzNGE0XkEyXkFqcGdeQXVyMjg2MTMyNTM@._V1_Ratio1.7600_AL_.jpg",
                title = "How It Should Have Ended",
                description = "(2005– )"
            },
            new IMDbEntry
            {
                id = "tt2242729",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "The Angry Joe Show",
                description = "(2009– )"
            },
            new IMDbEntry
            {
                id = "tt2278249",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Richard Roeper & the Movies",
                description = "(2009– )"
            },
            new IMDbEntry
            {
                id = "tt2278251",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Richard Roeper & the Movies",
                description = "(2009– )"
            },
            new IMDbEntry
            {
                id = "tt2386167",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "YourGeekNews.com",
                description = "(2010– )"
            },
            new IMDbEntry
            {
                id = "tt3022202",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Zoom In",
                description = "(2008– )"
            },
            new IMDbEntry
            {
                id = "tt3227032",
                resultType = "Title",
                image = "https://imdb-api.com/images/original/nopicture.jpg",
                title = "Sorties Savantes",
                description = "(2010–2013)"
            }
            },
                errormessage = ""
            };
        }
}
