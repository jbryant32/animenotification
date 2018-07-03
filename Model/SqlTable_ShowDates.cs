using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Model
{
    [Table("show dates")]
    public class SqlTable_ShowDates
    {
        [Column("row number"),Key]
        public int rowNumber { get; set; }
        [Column("id")]
        public string id { get; set; }
        [Column("title")]
        public string title { get; set; }
        [Column("date")]
        public string date { get; set; }
    }
}
