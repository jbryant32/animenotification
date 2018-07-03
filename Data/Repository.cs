using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;
using Microsoft.EntityFrameworkCore;
namespace AnimeAratoBackend.Data
{
    //public class Repository : IRepository
    //{
    //    Dictionary<int, MovieDataForServerDB> tmpDb = new Dictionary<int, MovieDataForServerDB>();
        
    //    public Repository( ) 
    //    {
    //        tmpDb.Add(15370, new MovieDataForServerDB()
    //        {
    //            Title = "The Cat Returns",
    //            id = 15370,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "Yes",
    //            MovieDates = new string[] { "04-22-2018", "04-23-2018", "04-25-2018" },
    //            youTube = "Gp-H_YOcYTM",
    //            theatricalReleaseStartDate ="04-22-2018"

    //        });

    //        tmpDb.Add(461758, new MovieDataForServerDB()
    //        {
    //            Title = "Digimon adventure tri coexistence",
    //            id = 461758,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "No",
    //            MovieDates = new string[] { "05-10-2018" },
               
    //            youTube = "E7jgUKio_4g",
    //            theatricalReleaseStartDate = "05-10-2018"

    //        });
    //        tmpDb.Add(11621, new MovieDataForServerDB()
    //        {
    //            Title = "Porco rosso",
    //            id = 11621,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "yes",
    //            MovieDates = new string[] { "05-20-2018", "05-21-2018", "05-22-2018" },
    //            youTube = "awEC-aLDzjs",
    //            theatricalReleaseStartDate = "05-20-2018"

    //        });
    //        tmpDb.Add(10515, new MovieDataForServerDB()
    //        {
    //            Title = "Castle in the Sky",
    //            id = 10515,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "yes",
    //            MovieDates = new string[] { "11-18-2018", "11-19-2018", "11-20-2018" },
    //            youTube = "McM0_YHDm5A",
    //            theatricalReleaseStartDate = "11-18-2018"

    //        });
    //        tmpDb.Add(128, new MovieDataForServerDB()
    //        {
    //            Title = "Princess Mononoke",
    //            id = 128,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "yes",
    //            MovieDates = new string[] { "07-22-2018", "07-23-2018", "07-24-2018" },
    //            youTube = "4OiMOHRDs14",
    //            theatricalReleaseStartDate = "07-22-2018"

    //        });

    //        tmpDb.Add(15283, new MovieDataForServerDB()
    //        {
    //            Title = "Pom Poko",
    //            id = 15283,
    //            offeringDubbed = "Yes",
    //            offeringSubbed = "yes",
    //            MovieDates = new string[] { "07-22-2018", "07-23-2018", "07-24-2018" },
    //            youTube = "_7cowIHjCD4",
    //            theatricalReleaseStartDate = "07-22-2018"

    //        });



    //    }

    //    public string[] getAllTitles()
    //    {
    //        throw new NotImplementedException();
    //    }
    //    //returns the information thats is missing from the database
    //    public string[] getMissingTitles(int[] MovieId)
    //    {
    //        List<string> tmp = new List<string>();
    //        foreach (var id in tmpDb.Keys)
    //        {
    //            var isMissing = MovieId.Contains(id);
    //            if (!isMissing)
    //            {
    //                tmp.Add(tmpDb[id].Title);
    //            }
               
    //        }
    //        return tmp.ToArray();
    //    }
       
    //    public MovieDataForServerDB getMovie(int id)
    //    {
    //        return tmpDb[id];
    //    }

    //    public MovieDataForServerDB[] GetAllShowings()//this needs a test
    //    {
    //        var tmpLst = new List<MovieDataForServerDB>();
    //        foreach (var key in tmpDb.Keys)
    //        {
    //            tmpLst.Add(tmpDb[key]);//conver to plain array
    //        }
    //        //var animeMovies = Database.ExecuteSqlCommandAsync("")
    //        return tmpLst.ToArray();
    //    }

    //    public void AddMovie(MovieDataForServerDB movie)
    //    {
    //        tmpDb.Add(movie.id, movie);
    //    }

    //    public void AddMovie(MovieDataForServerDB[] movie)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Task IRepository.AddMovie(MovieDataForServerDB movie)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
