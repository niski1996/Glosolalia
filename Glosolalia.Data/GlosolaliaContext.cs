using System.ComponentModel;
using Core.Common.Contracts;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Glosolalia.Common.Entities;
using Microsoft.Extensions.Options;

namespace Glosolalia.Data
{
	public class GlosolaliaContext : DbContext
	{
		private StreamWriter _logStream; 
		public DbSet<Translation> TranslationSet { get; set; }
		public DbSet<Sheet> SheetSet { get; set; }
		public DbSet<Word> Words { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			IConfigurationRoot configuration = new ConfigurationBuilder()
		.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
		.AddJsonFile("appsettings.json")
		.Build();

			string loggerPath = configuration.GetSection("Logging:SQLLogger").Value ?? "";
			if (_logStream is null)
			{
				_logStream = new StreamWriter(loggerPath, append: true);
			}
			optionsBuilder.LogTo(_logStream.WriteLine,
				new[] {DbLoggerCategory.Database.Command.Name});//NOTE log only db query and stuff like that, there are others categorry, but make log massive


			string connectionString = configuration.GetConnectionString("GlosolaliaDBDeveloper");//Todo try config in json, config in xml have problems to read constrings in tests

			optionsBuilder.UseSqlServer(connectionString);


			//optionsBuilder.LogTo()


			//string connectionString = configuration.GetConnectionString("GlosolaliaDBDeveloper");//Todo try config in json, config in xml have problems to read constrings in tests

			//optionsBuilder.UseSqlServer(connectionString);
			//optionsBuilder.UseSqlServer(
			//"server = 127.0.0.1,1433; Database = Glosolalia; Trusted_Connection = True; Encrypt=False"
			//);
		}


		public override void Dispose()
		{
			base.Dispose();
			_logStream.Dispose();
		}

		public override async ValueTask DisposeAsync()
		{
			await base.DisposeAsync();
			await _logStream.DisposeAsync();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();
			modelBuilder.Entity<Translation>().Navigation(e => e.TranslatableSet).AutoInclude();

			//         modelBuilder.Entity<EnWord>().HasIndex(e => e.Value).IsUnique();
			//         modelBuilder.Entity<PlWord>().HasIndex(e => e.Value).IsUnique();
			//         modelBuilder.Entity<EsWord>().HasIndex(e => e.Value).IsUnique();
			//         modelBuilder.Entity<EnWord>().HasIndex(e => e.Progress);
			//         modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
			//         modelBuilder.Entity<PlWord>().HasIndex(e => e.Progress);
			//         modelBuilder.Entity<EnWord>().HasIndex(e => e.LastInput);
			//         modelBuilder.Entity<PlWord>().HasIndex(e => e.LastInput);
			//         modelBuilder.Entity<EsWord>().HasIndex(e => e.LastInput);

			//modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			//modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			//modelBuilder.Entity<EsSentence>().HasIndex(e => e.Value).IsUnique();
			//modelBuilder.Entity<EsSentence>().HasIndex(e => e.Progress);
			//modelBuilder.Entity<EnSentence>().HasIndex(e => e.Progress);
			//modelBuilder.Entity<PlSentence>().HasIndex(e => e.Progress);
			//modelBuilder.Entity<EsSentence>().HasIndex(e => e.LastInput);
			//modelBuilder.Entity<EnSentence>().HasIndex(e => e.LastInput);
			//modelBuilder.Entity<PlSentence>().HasIndex(e => e.LastInput);

			//         modelBuilder.Entity<PlWord>().Ignore(e => e.SheetSet);
			//         modelBuilder.Entity<PlSentence>().Ignore(e => e.SheetSet);


			//modelBuilder.Entity<Tag>().HasIndex(e => e.Value).IsUnique();
			//modelBuilder.Entity<Sheet>().HasIndex(e => e.Name).IsUnique();
			//modelBuilder.Entity<PartOfSpeech>().HasIndex(e => e.Value).IsUnique();


		}
    }
}

