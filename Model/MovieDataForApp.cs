using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    public class MovieDataForApp
    {
        public string theaterUrl { get; set; }

        public string poster_sm { get; set; }
        public string poster_md { get; set; }
        public string poster_lg { get; set; }
        public string poster_lgx { get; set; }

        public string backdrop_sm { get; set; }
        public string backdrop_md { get; set; }
        public string backdrop_lg { get; set; }

        public string Subbed { get; set; }
        public string Dubbed { get; set; }


        public string trailer { get; set; }
        public string overview { get; set; }
        public string releaseDate { get; set; }
        public string theatricalRelease { get; set; }
        public string[] showings { get; set; }
        public int id { get; set; }
        public string title { get; set; }

    }
}
