using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AnimeAratoBackend.Data;
using AnimeAratoBackend.Model;
using AnimeAratoBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeAratoBackend.Controllers
{
    //the public facing api endpoints
    [Route("api/v1")]
    public class ValuesController : Controller
    {
        IRepository repository { get; set; }

        public ValuesController(IRepository repository)
        {
            this.repository = repository;
            HttpApiCalls.repository = repository;
        }
      
        [HttpGet("{id}"), Route("getMovieInfo")]
        public MovieDataForApp GetMovie(int id)//add api key
        {
            return repository.getMovie(id);
        }
        [HttpGet("{id}"), Route("getTest")]
        public async Task<MovieDataForApp[]> GetMovies()
        {
           return await repository.TestEnd();
        }
        //this end point gets all current movies showing
        [HttpGet("{id}"), Route("allMovies")]
        public async Task<MovieDataForApp[]> Get(int id)//this needs a test method
        {
            var data = await repository.GetAllShowings();

            return data;
        }
        //this end point gets all the movies without getting the media
        [HttpGet("{id}"), Route("GetAllNoMedia")]
        public MovieDataForApp[] GetAllNoMedia(int id)
        {
            return repository.GetAllNoMedia(id);
        }

        //TODO this end point will only pulll the movies that are missing
        [HttpPost, Route("checkUpdate")]
        public string[] CheckUpdateNeeded([FromBody]Titles titles)//add api key
        {

            return repository.getMissingTitles(titles.MoviesIds);//not implemented yet
        }

 
    }
}
