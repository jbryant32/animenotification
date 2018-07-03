using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    [Table("moving media")]
    public class SqlTable_Media
    {
        [Key ,Column("id")]
        public string id { get; set; }
        [Column("title")]
        public string title { get; internal set; }
        [Column("poster sm")]
        public string poster_sm { get; set; }
        [Column("poster md")]
        public string poster_md { get; set; }
        [Column("poster lg")]
        public string poster_lg { get; set; }
        [Column("poster lgx")]
        public string poster_lgx { get; set; }
        [Column("backdrop sm")]
        public string backdrop_sm { get; set; }
        [Column("backdrop md")]
        public string backdrop_md { get; set; }
        [Column("backdrop lg")]
        public string backdrop_lg { get; set; }
      
    }
}
