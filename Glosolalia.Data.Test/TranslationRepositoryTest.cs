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
    public class TranslationRepositoryTest
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
        public void AreWordsIncluded()
        {
            var tranRepo = new TranslationRepository();

            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString(), 1), new Word(Guid.NewGuid().ToString(), 2) }
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                tr1=tranRepo.Add(tr1, context);
                context.SaveChanges();
                var tr2 = tranRepo.Get(tr1.Id);
                Assert.AreEqual(tr2.WordSet.Count(),2);
            }

        }
        [TestMethod]
        public void AddingAllNewIncluded()
        {
            var tranRepo = new TranslationRepository();

            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString(), 1), new Word(Guid.NewGuid().ToString(), 2) }
            };


            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                tranRepo.Add(tr1, context);
                context.SaveChanges();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(wr + 2, wr2);
                Assert.AreEqual(tr + 1, tr2);

            };
        }

        [TestMethod]
        public void AddingWithExistingWordIncluded()
        {
            var tranRepo = new TranslationRepository();
            var name = Guid.NewGuid().ToString();
            Word tmp = new Word(name, 1);

            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(name, 1), new Word(Guid.NewGuid().ToString(), 2) }
            };


            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                context.Words.Add(tmp);
                context.SaveChanges();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                tranRepo.Add(tr1, context);
                context.SaveChanges();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(wr + 1, wr2);
                Assert.AreEqual(tr + 1, tr2);

            };
        }




    }
}
