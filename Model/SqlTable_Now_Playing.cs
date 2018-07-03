using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    [Table("now playing")]
    public class SqlTable_Now_Playing
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("release date")]
        public string ReleaseDate { get; set; }
        [Column("dubbed")]
        public string  Dubbed { get; set; }
        [Column("subbed")]
        public string Subbed { get; set; }
        [Column("youtube")]
        public string YouTube { get; set; }
        [Column("overview")]
        public string OverView { get; set; }
        [Column("theater url")]
        public string TheaterUrl { get; internal set; }
    }
}
