using AnimeAratoBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Data
{
    public class RepositoryDb : IRepository
    {
        AODatabase context { get; set; }
        static HttpClient imageClient = new HttpClient() { BaseAddress = new Uri("http://image.tmdb.org/t/p/") };

        public RepositoryDb(AODatabase context)
        {
            this.context = context;
        }

        public int Delete(string[] id)
        {
            var count = 0;
            foreach (var item in id)
            {
                count++;
                context.Database.ExecuteSqlCommand("DELETE FROM [moving media] WHERE id = {0} DELETE FROM [now playing] WHERE id = {0} DELETE FROM[show dates] WHERE id = {0}", item);
            }
            return count;
        }

        public void AddMovie(MovieData[] movies)
        {
            throw new NotImplementedException();

        }
        public async Task AddMovie(MovieData movie)
        {
            ////http calls to TheMovieDb.com for the coresponding background art
            var imagePosterSmall = await imageClient.GetAsync($"w92{movie.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterMedium = await imageClient.GetAsync($"w154{movie.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterLarge = await imageClient.GetAsync($"w185{movie.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterLargeX = await imageClient.GetAsync($"w342{movie.poster_path}").Result.Content.ReadAsByteArrayAsync();

            var backdropSmall = await imageClient.GetAsync($"w300{movie.backdrop_path}").Result.Content.ReadAsByteArrayAsync();
            var backdropMedium = await imageClient.GetAsync($"w780{movie.backdrop_path}").Result.Content.ReadAsByteArrayAsync();
            var backdropLarge = await imageClient.GetAsync($"w1280{movie.backdrop_path}").Result.Content.ReadAsByteArrayAsync();


            #region table data staging
            var nowPlaying = new SqlTable_Now_Playing();
            nowPlaying.Title = movie.Title;
            nowPlaying.Id = movie.id.ToString();
            nowPlaying.Subbed = movie.offeringSubbed;
            nowPlaying.Dubbed = movie.offeringDubbed;
            nowPlaying.OverView = movie.overview;
            nowPlaying.YouTube = movie.youTube;
            nowPlaying.OverView = movie.overview;
            nowPlaying.TheaterUrl = movie.theaterUrl;
            nowPlaying.ReleaseDate = movie.theatricalReleaseStartDate;
            var media = new SqlTable_Media();
            media.id = movie.id.ToString();
            media.title = movie.Title;
            media.backdrop_sm = Convert.ToBase64String(backdropSmall);
            media.backdrop_md = Convert.ToBase64String(backdropMedium);
            media.backdrop_lg = Convert.ToBase64String(backdropLarge);

            media.poster_sm = Convert.ToBase64String(imagePosterSmall);
            media.poster_md = Convert.ToBase64String(imagePosterMedium);
            media.poster_lg = Convert.ToBase64String(imagePosterLarge);
            media.poster_lgx = Convert.ToBase64String(imagePosterLargeX);

            List<SqlTable_ShowDates> showings = new List<SqlTable_ShowDates>();
            foreach (var showing in movie.MovieDates)
            {
                showings.Add(new SqlTable_ShowDates() { id = movie.id.ToString(), date = showing, title = movie.Title });
            }
            #endregion



            #region sql tables
            var tableNowPlaying = context.GetNowPlayingTable();
            var tableShowDates = context.getShowDatesTable();
            var tableMedia = context.getMediaTable();
            #endregion


            using (var transaction = context.Database.BeginTransaction())
            {

                try
                {
                    tableNowPlaying.Add(nowPlaying);
                    context.SaveChanges();
                    tableMedia.Add(media);
                    context.SaveChanges();
                    tableShowDates.AddRange(showings);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception msg)
                {


                }

            }
        }

        public async Task<MovieDataForApp[]> TestEnd()
        {

            var tmplist = new List<MovieDataForApp>();
            var newMovieItem = new MovieDataForApp();
            newMovieItem.title = "Cowboy Bebop";
            newMovieItem.id = 76069;
            newMovieItem.overview ="(カウボーイビバップ Kaubōi Bibappu) is a 1998 Japanese anime television series animated by Sunrise featuring a production team led by director Shinichirō Watanabe, screenwriter Keiko Nobumoto, character designer Toshihiro Kawamoto, mechanical designer Kimitoshi Yamane, and composer Yoko Kanno. The twenty-six episodes ('sessions') of the series are set in the year 2071, and follow the lives of a bounty hunter crew traveling on their spaceship called Bebop. Cowboy Bebop explores philosophical concepts including existentialism, existential ennui, and loneliness.";
            tmplist.Add(newMovieItem);
            return tmplist.ToArray();
        }
        public async Task<MovieDataForApp[]> GetAllShowings()
        {
            var tmplist = new List<MovieDataForApp>();
            var tableNowPlaying = context.GetNowPlayingTable();//wrap in try catch 
            var tableShowDates = context.getShowDatesTable();
            var allMovies = tableNowPlaying.FromSql("SELECT * FROM [now playing]").ToArray();
            var tableMedia = context.getMediaTable();

            //foreach movie pulled from the database table [now playing] we combine it with the data pulled from the [movie media] table
            //TODO need to change the table name [moving media] to [movie media]
            foreach (var movie in allMovies)
            {
                var media = tableMedia.FromSql("SELECT * FROM [moving media] WHERE id = {0}", movie.Id).FirstOrDefault();//gets the current movie in the loop iterations table information
                var movieData = new MovieDataForApp()
                {
                    id = Int32.Parse(movie.Id),
                    title = movie.Title,
                    overview = movie.OverView,
                    trailer = movie.YouTube,
                    backdrop_lg = media.backdrop_lg,
                    backdrop_md = media.backdrop_md,
                    backdrop_sm = media.backdrop_sm,
                    poster_lgx = media.poster_lgx,
                    poster_lg = media.poster_lg,
                    poster_md = media.poster_md,
                    poster_sm = media.poster_sm,
                    theatricalRelease = movie.ReleaseDate,
                    releaseDate = movie.ReleaseDate,
                    theaterUrl = movie.TheaterUrl
                };

                tmplist.Add(movieData);
            }
            return tmplist.ToArray();
        }

        public string[] getAllTitles()
        {
            throw new NotImplementedException();
        }

        public string[] getMissingTitles(int[] MovieId)
        {
            throw new NotImplementedException();
        }

        //gets a a single movie using the movies id movie ids come from the MovieDB.com api
        public MovieDataForApp getMovie(int id)
        {
            var tableNowPlaying = context.GetNowPlayingTable();//wrap in try catch 
            var tableShowDates = context.getShowDatesTable();
            var FetchedMovie = tableNowPlaying.FromSql("SELECT * FROM [now playing] WHERE id = {0}", id).First();
            var tableMedia = context.getMediaTable();


            //var media = tableMedia.FromSql("SELECT * FROM [moving media] WHERE id = {0}", FetchedMovie.Id).FirstOrDefault();
            var ShowDates = tableShowDates.FromSql("SELECT * FROM [show dates] WHERE id = {0}", FetchedMovie.Id).ToArray().Select((showing) => { return showing.date; }).ToArray();
            var movieData = new MovieDataForApp()
            {
                id = Int32.Parse(FetchedMovie.Id),
                title = FetchedMovie.Title,
                overview = FetchedMovie.OverView,
                trailer = FetchedMovie.YouTube,
                //backdrop_lg = media.backdrop_lg,
                //backdrop_md = media.backdrop_md,
                //backdrop_sm = media.backdrop_sm,
                //poster_lgx = media.poster_lgx,
                //poster_lg = media.poster_lg,
                //poster_md = media.poster_md,
                //poster_sm = media.poster_sm,
                showings = ShowDates,
                theatricalRelease = FetchedMovie.ReleaseDate,
                releaseDate = FetchedMovie.ReleaseDate
            };



            return movieData;
        }

        //gets all current movies with image data
        public MovieDataForApp[] GetAllNoMedia(int id)
        {
            var tmplist = new List<MovieDataForApp>();
            var tableNowPlaying = context.GetNowPlayingTable();//wrap in try catch 
            var tableShowDates = context.getShowDatesTable();
            var allMovies = tableNowPlaying.FromSql("SELECT * FROM [now playing]").ToArray();

            foreach (var movie in allMovies)
            {
                var ShowDates = tableShowDates.FromSql("SELECT * FROM [show dates] WHERE id = {0}", movie.Id).ToArray().Select((showing) => { return showing.date; }).ToArray();

                var movieData = new MovieDataForApp()
                {
                    id = Int32.Parse(movie.Id),
                    title = movie.Title,
                    overview = movie.OverView,
                    trailer = movie.YouTube,
                    //backdrop_lg = media.backdrop_lg,
                    //backdrop_md = media.backdrop_md,
                    //backdrop_sm = media.backdrop_sm,
                    //poster_lgx = media.poster_lgx,
                    //poster_lg = media.poster_lg,
                    //poster_md = media.poster_md,
                    //poster_sm = media.poster_sm,
                    theatricalRelease = movie.ReleaseDate,
                    releaseDate = movie.ReleaseDate
                    ,
                    showings = ShowDates
                    ,
                    theaterUrl = movie.TheaterUrl
                };

                tmplist.Add(movieData);
            }
            return tmplist.ToArray();
        }
    }
}
