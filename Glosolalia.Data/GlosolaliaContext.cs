using System.ComponentModel;
using System.Configuration;
using Core.Common.Contracts;
using System.Runtime.Serialization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Glosolalia.Business.Entities;
using Glosolalia.Business.Entities.Words;
using Glosolalia.Business.Entities.Sentences;

namespace Glosolalia.Data
{
    public class GlosolaliaContext : DbContext
    {
        public DbSet<Sheet> SheetSet { get; set; }
		public DbSet<PlWord> PlWords { get; set; }
        public DbSet<EnWord> EnWords { get; set; }
        public DbSet<EsWord> EsWords { get; set; }
        public DbSet<EsSentence> EsSentenceSet { get; set; }
        public DbSet<PlSentence> PlSentenceSet { get; set; }
        public DbSet<EnSentence> EnSentenceSet { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        //    ConnectionStringSettings settings =
        //ConfigurationManager.ConnectionStrings["GlosolaliaDB"];
        //    optionsBuilder.UseSqlServer(
        //        settings.ConnectionString
        //        );            
            optionsBuilder.UseSqlServer(
                "server = 127.0.0.1,1433; Database = Glosolalia; Trusted_Connection = True; Encrypt=False"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Word>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<EnWord>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<EsWord>().HasIndex(e => e.Value).IsUnique();
            modelBuilder.Entity<EnWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<EnWord>().HasIndex(e => e.LastInput);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.LastInput);
            modelBuilder.Entity<EsWord>().HasIndex(e => e.LastInput);

			modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			modelBuilder.Entity<EsSentence>().HasIndex(e => e.Progress);
			modelBuilder.Entity<EnSentence>().HasIndex(e => e.Progress);
			modelBuilder.Entity<PlSentence>().HasIndex(e => e.Progress);
			modelBuilder.Entity<EsSentence>().HasIndex(e => e.LastInput);
			modelBuilder.Entity<EnSentence>().HasIndex(e => e.LastInput);
			modelBuilder.Entity<PlSentence>().HasIndex(e => e.LastInput);

            modelBuilder.Entity<PlWord>().Ignore(e => e.SheetSet);
            modelBuilder.Entity<PlSentence>().Ignore(e => e.SheetSet);


			modelBuilder.Entity<Tag>().HasIndex(e => e.Value).IsUnique();
			modelBuilder.Entity<Sheet>().HasIndex(e => e.Name).IsUnique();
			modelBuilder.Entity<PartOfSpeech>().HasIndex(e => e.Value).IsUnique();


        }
    }
}

