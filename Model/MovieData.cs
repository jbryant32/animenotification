using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    /// <summary>
    /// The movie data colleced from the frontend
    /// </summary>
    public class MovieData
    {
        public string Title { get; set; }
        public int id { get; set; }
        public string offeringSubbed { get; set; }
        public string offeringDubbed { get; set; }
        public string[] MovieDates { get; set; }
        public string theatricalReleaseStartDate { get; set; }
        public string youTube { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public string special_posterUrl { get; set; }//TODO
        public string overview { get; set; }
        public string theaterUrl { get; set; }
    }
}
