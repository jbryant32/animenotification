using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    public class TheMovieDb
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public IList<Results> results { get; set; }
    }
    public class Results
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }
}
