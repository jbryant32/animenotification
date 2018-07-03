using AnimeAratoBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeAratoBackend.Data
{
    public class AODatabase:DbContext
    {
        DbSet<SqlTable_Now_Playing> TableNowPlaying { get; set; }
        DbSet<SqlTable_Media> TableMedia { get; set; }
        DbSet<SqlTable_ShowDates> TableShowDates { get; set; }

        public AODatabase(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SqlTable_Now_Playing> GetNowPlayingTable()
        {
            return TableNowPlaying;
        }
        public DbSet<SqlTable_Media> getMediaTable()
        {
            return TableMedia;
        }
        public DbSet<SqlTable_ShowDates> getShowDatesTable()
        {
            return TableShowDates;
        }

    }
}
