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
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Entity<EnWordPlWord>().HasKey(s => new { s.IdEnWord, s.IdPlWord });

            modelBuilder.Entity<PartOfSpeech>().Ignore(e => e.EntityId);
            modelBuilder.Entity<Language>().Ignore(e => e.EntityId);
            modelBuilder.Entity<Tag>().Ignore(e => e.EntityId);


            modelBuilder.Entity<Language>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tag>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<EnWord>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PlWord>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PartOfSpeech>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<EnWord>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<PartOfSpeech>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<Language>().HasIndex(e => e.Name).IsUnique();

            //modelBuilder.Entity<PlWord>().HasIndex(e => e.Language);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.LastInput);
            //modelBuilder.Entity<EnWord>().HasIndex(e => e.Language);
            modelBuilder.Entity<EnWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<EnWord>().HasIndex(e => e.LastInput);



        }
    }
}

