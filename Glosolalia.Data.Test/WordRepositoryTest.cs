using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data.Test
{

    [TestClass]
    public class WordRepositoryTest
    {
        private DbContextOptionsBuilder<GlosolaliaContext> builder = new();
        [TestInitialize]
        public void Initialize()
        {
            bool flagInMemory = true;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
            flagInMemory = false;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
            if (flagInMemory)
            {
                this.builder.UseInMemoryDatabase("SharedDatabase");
            }
            else
            {
                using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    List<Language> li = new() {new Language() { Name = "Spanish", WordSet = new() },
                    new Language() { Name = "Polish", WordSet = new() },
                    new Language() { Name = "English", WordSet = new()} };
                    context.LanguageSet.AddRange(li);
                    context.SaveChanges();

                }
            }
        }
        [TestMethod]
        public void SameWordMultiLanguageAllowed()
        {
            var wordRepo = new WordRepository();

            var exeVal = Guid.NewGuid().ToString();


            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                var initWords = context.Words.Count();
                wordRepo.Add(new Word(exeVal, 1), context);
                wordRepo.Add(new Word(exeVal, 2), context);
                context.SaveChanges();
                Assert.AreEqual(initWords+2, context.Words.Count());
            }

        }
        [TestMethod]
        public void SameWord()
            /*oczekuje że nie zostanie dodane, ale nie powinno wykórwić błędów, bo to się mija z
             * celem, nie potrzebuje obsrywać każdej sesji milionem bledów, a jesli to choć troche zautoamtyzuje
             * to ich bedzie w cholere i nic mi do tego */
           
        {
            var wordRepo = new WordRepository();

            var exeVal = Guid.NewGuid().ToString();


            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                var initWords = context.Words.Count();
                wordRepo.Add(new Word(exeVal, 1), context);
                context.SaveChanges();
                wordRepo.Add(new Word(exeVal, 1), context);
                context.SaveChanges();
                Assert.AreEqual(initWords + 1, context.Words.Count());
            }

        }

    }
}
