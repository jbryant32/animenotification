using AnimeAratoBackend.Data;
using AnimeAratoBackend.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Services
{
    public class HttpApiCalls
    {
        static HttpClient clientTheMoviedb = new HttpClient() { BaseAddress = new Uri("https://api.themoviedb.org") };
        static HttpClient imageClient = new HttpClient() { BaseAddress = new Uri("http://image.tmdb.org/t/p/") };
        public static IRepository repository { get; set; }
        //takes the movies from the data base and makes an apit call to the moviedb end point for that movies information
        public static async Task<MovieDataForApp[]> getMovieDb(MovieData[] dbApiMoveData)
        {

            var appData = new MovieDataForApp();
            var tmpList = new List<MovieDataForApp>();
            var payload = new TheMovieDb();


            foreach (var movie in dbApiMoveData)
            {
                var response = await clientTheMoviedb.GetAsync($"/3/search/movie?api_key=88c90f084b54e6c2a73b7295abdf08c0&query={movie.Title}&include_adult=false&append_to_response=videos,images");
                var data = await response.Content.ReadAsStringAsync();
                payload = JsonConvert.DeserializeObject<TheMovieDb>(data);
                await createDataForMobileEndPoint(payload, tmpList);
            }

            return tmpList.ToArray();
        }
        public static async Task<Results>  getMovieSingle( string movie)
        {
            var response = await clientTheMoviedb.GetAsync($"/3/search/movie?api_key=88c90f084b54e6c2a73b7295abdf08c0&query={movie}&include_adult=false&append_to_response=videos,images");
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TheMovieDb>(data).results[0];
        }
        //downloads all images for each movie in the database and creates a new data object for the mobile end user
        private static async Task createDataForMobileEndPoint(TheMovieDb payload, List<MovieDataForApp> tmpList)
        {
            var appData = new MovieDataForApp();
            var result = payload.results[0];//gets the first result only in the payload

            var imagePosterSmall = await imageClient.GetAsync($"w92{result.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterMedium = await imageClient.GetAsync($"w154{result.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterLarge = await imageClient.GetAsync($"w185{result.poster_path}").Result.Content.ReadAsByteArrayAsync();
            var imagePosterLargeX = await imageClient.GetAsync($"w342{result.poster_path}").Result.Content.ReadAsByteArrayAsync();

            var backdropSmall = await imageClient.GetAsync($"w300{result.backdrop_path}").Result.Content.ReadAsByteArrayAsync();
            var backdropMedium = await imageClient.GetAsync($"w780{result.backdrop_path}").Result.Content.ReadAsByteArrayAsync();
            var backdropLarge = await imageClient.GetAsync($"w1280{result.backdrop_path}").Result.Content.ReadAsByteArrayAsync();
            var overview = result.overview;
            var youTubeTrailer = repository.getMovie(result.id).trailer;
            //converts the data for use at the mobile device end point
            appData.poster_sm = Convert.ToBase64String(imagePosterSmall);
            appData.poster_md = Convert.ToBase64String(imagePosterMedium);
            appData.poster_lg = Convert.ToBase64String(imagePosterLarge);

            appData.backdrop_sm = Convert.ToBase64String(backdropSmall);
            appData.backdrop_md = Convert.ToBase64String(backdropMedium);
            appData.backdrop_lg = Convert.ToBase64String(backdropLarge);
            appData.id = result.id;
            appData.theatricalRelease = repository.getMovie(result.id).releaseDate;
            appData.trailer = youTubeTrailer;
            appData.overview = overview;
            appData.title = result.title;

            tmpList.Add(appData);


        }
    }
}
