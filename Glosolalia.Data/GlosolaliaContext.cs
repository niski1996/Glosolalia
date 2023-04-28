using System.ComponentModel;
using System.Configuration;
using Core.Common.Contracts;
using System.Runtime.Serialization;
using Glosolalia.Buisness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Glosolalia.Data
{
    public class GlosolaliaContext : DbContext
    {
        public DbSet<PlWord> PlWords { get; set; }
        public DbSet<EnWord> EnWords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            ConnectionStringSettings settings =
        ConfigurationManager.ConnectionStrings["GlosolaliaDB"];
            optionsBuilder.UseSqlServer(
                settings.ConnectionString
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();
            modelBuilder.Entity<EnWordPlWord>().HasKey(s => new { s.IdEnWord, s.IdPlWord });
            modelBuilder.Entity<EnWord>().Ignore(e => e.EntityId);
        }
    }
}

