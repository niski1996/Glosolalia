using System.ComponentModel;
using Core.Common.Contracts;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Glosolalia.Business.Entities;
using Microsoft.Extensions.Configuration;

namespace Glosolalia.Data
{
    public class GlosolaliaContext : DbContext
    {
        public DbSet<PlWord> PlWords { get; set; }
        public DbSet<EnWord> EnWords { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

			IConfigurationRoot configuration = new ConfigurationBuilder()
		.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		.AddJsonFile("appsettings.json")
		.Build();

			string connectionString = configuration.GetConnectionString("GlosolaliaDB");//Todo try config in json, config in xml have problems to read constrings in tests

			optionsBuilder.UseSqlServer(connectionString);
			//optionsBuilder.UseSqlServer(
			//    "server = 127.0.0.1,1433; Database = Glosolalia; Trusted_Connection = True; Encrypt=False"
			//    );
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
            modelBuilder.Entity<EnWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
            modelBuilder.Entity<EnWord>().HasIndex(e => e.LastInput);
            modelBuilder.Entity<PlWord>().HasIndex(e => e.LastInput);

            modelBuilder.Entity<Tag>().HasIndex(e => e.Value).IsUnique();


        }
    }
}

