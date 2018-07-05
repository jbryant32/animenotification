using AnimeAratoBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Data
{
    public interface IRepository
    {
        string[] getMissingTitles(int[] MovieId);
        string[] getAllTitles();
        int Delete(string[] id);
        MovieDataForApp getMovie(int id);
        Task<MovieDataForApp[]> GetAllShowings();
        Task AddMovie(MovieData movie);
        Task<string> AddBulkMovies(MovieData[] movies);
        Task<string> deleteBulkMovies(string[] movieIds);
        MovieDataForApp[] GetAllNoMedia(int id);
        Task<MovieDataForApp[]> TestEnd();
    }
}
