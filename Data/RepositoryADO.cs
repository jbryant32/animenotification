using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeAratoBackend.Model;

namespace AnimeAratoBackend.Data
{
    public class RepositoryADO : IRepository
    {
        public RepositoryADO()
        {

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

        public Task<MovieDataForApp[]> GetAllShowings()
        {
            throw new NotImplementedException();
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
