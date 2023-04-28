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
            ConnectionStringSettings settings =
        ConfigurationManager.ConnectionStrings["GlosolaliaDB"];
            optionsBuilder.UseSqlServer(
                settings.ConnectionString
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Word>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();
            modelBuilder.Entity<EnWordPlWord>().HasKey(s => new { s.IdEnWord, s.IdPlWord });
            //modelBuilder.Entity<EnWord>().Ignore(e => e.EntityId);
            //modelBuilder.Entity<Language>().Ignore(e => e.EntityId);
            modelBuilder.Entity<Language>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Language>().Property(e=>e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Word>().HasIndex(e => e.Value).IsUnique();
            //modelBuilder.Entity<Word>().HasIndex(e => e.Language);
            modelBuilder.Entity<Word>().HasIndex(e => e.Progress);
            modelBuilder.Entity<Word>().HasIndex(e => e.LastInput);

            modelBuilder.Entity<Tag>().HasIndex(e => e.Value).IsUnique();


        }
    }
}

