using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Domain;
using Glosolalia.entities;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data
{
    public class GlosolaliaContext:DbContext
    {
        public DbSet<PlWord> PlWords { get; set; }
        public DbSet<EnWord> EnWords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "server = 127.0.0.1,1433; Database = Glosolalia; Trusted_Connection = True; Encrypt=False"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<EnWordPlWord>().HasKey(s => new { s.IdEnWord, s.IdPlWord });


        }
    }
}
