using System.ComponentModel;
using Core.Common.Contracts;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Glosolalia.Common.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Glosolalia.Data
{
	public class GlosolaliaContext : DbContext
	{
        public GlosolaliaContext()
        {
            
        }
        public GlosolaliaContext(DbContextOptions<GlosolaliaContext> options)
			: base(options)
        {
            
        }
        private StreamWriter _logStream { get; set; }
		public DbSet<Translation> TranslationSet { get; set; }
		public DbSet<Sheet> SheetSet { get; set; }
		public DbSet<Word> Words { get; set; }
		public DbSet<Language> LanguageSet { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<PartOfSpeech> PartsOfSpeech { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{


				IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

				//string loggerPath = configuration.GetSection("Logging:SQLLogger").Value ?? "";
				//if (_logStream is null)
				//{
				//	_logStream = new StreamWriter(loggerPath, append: true);
				//}
				//optionsBuilder.LogTo(_logStream.WriteLine,
				//	new[] { DbLoggerCategory.Database.Command.Name }// log only db query and stuff like that, there are others categorry, but make log massive
				//	, LogLevel.Information).
				//	EnableSensitiveDataLogging();//show parametres field in loggs


				string connectionString = configuration.GetConnectionString("GlosolaliaDBDeveloper");//Todo try config in json, config in xml have problems to read constrings in tests

				optionsBuilder.UseSqlServer(connectionString);
			}


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
			//_logStream.Dispose();
		}

		//public override async ValueTask DisposeAsync()
		//{
		//	await base.DisposeAsync();
		//	await _logStream.DisposeAsync();
		//}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();
			//modelBuilder.Entity<Translation>().Navigation(e => e.TranslatableFrom).AutoInclude();
			modelBuilder.Entity<Translation>().Navigation(e => e.WordSet).AutoInclude();
            modelBuilder.Entity<Sheet>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Language>().HasIndex(e => e.Name).IsUnique();
            modelBuilder.Entity<Word>().HasIndex(e => new {e.LanguageId,e.Value}).IsUnique();




        }
   //     public override int SaveChanges()
   //     {
   //         try
   //         {
   //             return base.SaveChanges();
   //         }
   //         catch (DbUpdateException ex) when (IsDuplicateIndexException(ex))
   //         {
   //             // Obsłuż wyjątek duplikatu indeksu
   //             // Możesz na przykład zalogować błąd lub podjąć inne działania

   //             return 0; // Zwróć odpowiedni kod błędu lub zrzuć wyjątek
   //         }
			//catch(Exception ex)
			//{
			//	return 1;
			//}
   //     }

        private bool IsDuplicateIndexException(DbUpdateException ex)
        {
            // Sprawdź, czy wyjątek jest wynikiem duplikatu indeksu
            // W zależności od dostawcy bazy danych, konkretna logika może się różnić
            // Możesz na przykład sprawdzić, czy wyjątek zawiera określony kod błędu SQL

            // Przykładowa logika dla dostawcy SQL Server
            return ex.InnerException is SqlException sqlException && sqlException.Number == 2601;
        }
    }
}

