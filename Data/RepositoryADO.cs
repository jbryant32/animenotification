using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeAratoBackend.Data
{
    public class RepositoryADO : IRepository
    {

        string connectionString { get; set; }
        AODatabase context { get; set; }
        public RepositoryADO(AODatabase context)
        {

            this.context = context;
            connectionString = this.context.Database.GetDbConnection().ConnectionString;
        }

        public async Task<string> AddBulkMovies(MovieData[] movies)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction("UpdateAnimeAratoMultple");
                command.Transaction = transaction;
                try
                {
                    foreach (var movie in movies)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@title", movie.Title));
                        command.Parameters.Add(new SqlParameter("@poster_sm", movie.poster_path));
                        command.Parameters.Add(new SqlParameter("@poster_md", movie.poster_path));
                        command.Parameters.Add(new SqlParameter("@poster_lg", movie.poster_path));
                        command.Parameters.Add(new SqlParameter("@poster_lgx", movie.poster_path));
                        command.Parameters.Add(new SqlParameter("@backdrop_sm", movie.backdrop_path));
                        command.Parameters.Add(new SqlParameter("@backdrop_md", movie.backdrop_path));
                        command.Parameters.Add(new SqlParameter("@backdrop_lg", movie.backdrop_path));
                        command.Parameters.Add(new SqlParameter("@id", movie.id.ToString()));
                        command.Parameters.Add(new SqlParameter("@overview", movie.overview));
                        command.Parameters.Add(new SqlParameter("@dubbed", movie.offeringDubbed));
                        command.Parameters.Add(new SqlParameter("@subbed", movie.offeringSubbed));
                        command.Parameters.Add(new SqlParameter("@youtube", movie.youTube));
                        command.Parameters.Add(new SqlParameter("@theatricalReleaseStartDate", movie.MovieDates[0]));
                        command.Parameters.Add(new SqlParameter("@date", movie.MovieDates[0]));
                        command.Parameters.Add(new SqlParameter("@theaterUrl", movie.theaterUrl));
                      
                        command.CommandText = "INSERT INTO [now playing] VALUES(@title,@dubbed,@subbed,@youtube,@overview,@id,@theatricalReleaseStartDate,@theaterUrl)";
                        await command.ExecuteNonQueryAsync();
                        command.CommandText = "INSERT INTO [moving media] VALUES(@title,@poster_sm,@poster_md,@poster_lg,@poster_lgx,@backdrop_sm,@backdrop_md,@backdrop_lg,@id)";
                        await command.ExecuteNonQueryAsync();

                        foreach (var showingData in movie.MovieDates)
                        {
                            var indexForRemoving = command.Parameters.IndexOf("@date");
                            command.Parameters.RemoveAt(indexForRemoving);
                            command.Parameters.Add(new SqlParameter("@date", showingData));
                          
                            command.CommandText = "INSERT INTO [show dates] VALUES(@title,@date,@id)";
                            await command.ExecuteNonQueryAsync();
                        }

                    }
                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    try
                    {
                        transaction.Rollback();
                        return "Huston we have a problem \n" + ex.Message;
                    }
                    catch (Exception ex2)
                    {
                        return "Huston we have a problem \n" + ex2.Message;
                    }

                }


            }
            return "Transaction Completed!";
        }

        public async Task<string> deleteBulkMovies(string[] movieIds)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction("deleteMultipleMovies");
                command.Transaction = transaction;
                try
                {


                    foreach (var movieId in movieIds)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new SqlParameter("@id", movieId));

                        command.CommandText = "DELETE FROM [moving media] WHERE [id] = @id";
                        await command.ExecuteNonQueryAsync();
                        command.CommandText = "DELETE FROM [now playing] WHERE [id] = @id";
                        await command.ExecuteNonQueryAsync();
                        command.CommandText = "DELETE FROM [show dates] WHERE [id] = @id";
                        await command.ExecuteNonQueryAsync();


                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    try
                    {
                        transaction.Rollback();
                        return "Huston we have a problem \n" + ex.Message;
                    }
                    catch (Exception ex2)
                    {

                        return "Huston we have a problem \n " + ex2.Message;
                    }

                }
            }
            return "Transaction Completed!";
        }

        public Task AddMovie(MovieData movie)
        {
            throw new NotImplementedException();
        }

        public int Delete(string[] id)
        {

            throw new NotImplementedException();
        }

        public MovieDataForApp[] GetAllNoMedia(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDataForApp[]> GetAllShowings()
        {
            var tmplst = new List<MovieDataForApp>();
           

            var mediaTable = context.getMediaTable();
            var nowPlaying = context.GetNowPlayingTable();
            var showDates = context.getShowDatesTable();
            var mediaResults = mediaTable.FromSql("SELECT * FROM [moving media]").ToList();
            var NowPlayingResults = nowPlaying.FromSql("SELECT * FROM [now playing]").ToList();
            var Dates = showDates.FromSql("SELECT * FROM [show dates]").ToList(); 
            foreach (var nowplaying in NowPlayingResults)
            {
                var tmpmovie = new MovieDataForApp();
                var showings = new List<string>();
                tmpmovie.title = nowplaying.Title;
                tmpmovie.id = Int32.Parse(nowplaying.Id);
                tmpmovie.trailer = nowplaying.YouTube;
                tmpmovie.theaterUrl = nowplaying.TheaterUrl;
                tmpmovie.Dubbed = nowplaying.Dubbed;
                tmpmovie.Subbed = nowplaying.Subbed;
                tmpmovie.theatricalRelease = nowplaying.ReleaseDate;
                tmpmovie.releaseDate = nowplaying.ReleaseDate;
                tmpmovie.overview = nowplaying.OverView;

                foreach (var mediatable in mediaResults)
                {
                    tmpmovie.poster_sm = mediatable.poster_sm;
                    tmpmovie.poster_md = mediatable.poster_md;
                    tmpmovie.poster_lg = mediatable.poster_lg;
                    tmpmovie.poster_lgx = mediatable.poster_lgx;
                    tmpmovie.backdrop_sm = mediatable.backdrop_sm;
                    tmpmovie.backdrop_md = mediatable.backdrop_md;
                    tmpmovie.backdrop_lg = mediatable.backdrop_lg;
                }

                foreach (var showDate in Dates)
                {
                    if (tmpmovie.id ==Int32.Parse(showDate.id))
                    {
                        showings.Add(showDate.date);
                        tmpmovie.showings = showings.ToArray();
                    }
                }
                tmplst.Add(tmpmovie);
            }
            return tmplst.ToArray();
        }

        public string[] getAllTitles()
        {
            throw new NotImplementedException();
        }

        public string[] getMissingTitles(int[] MovieId)
        {
            throw new NotImplementedException();
        }

        public MovieDataForApp getMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDataForApp[]> TestEnd()
        {
            throw new NotImplementedException();
        }
    }
}
