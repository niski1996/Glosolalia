using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Data_MockRepositories;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data.Test.SheetRepositoryTest
{

    [TestClass]
    public class SheetRepositoryGettingTest
    {
        private DbContextOptionsBuilder<GlosolaliaContext> builder = new();
        private List<Language> languages = new List<Language>();
        [TestInitialize]
        public void Initialize()
        {
            bool flagInMemory = true;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
            flagInMemory = false;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
            if (flagInMemory)
            {
                builder.UseInMemoryDatabase("SharedDatabase");
            }
            else
            {
                using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    List<Language> li = new() {new Language() { Name = "Spanish"},
                    new Language() { Name = "Polish" },
                    new Language() { Name = "English",} };
                    context.LanguageSet.AddRange(li);
                    context.SaveChanges();
                    languages = context.LanguageSet.ToList();

                }
            }
        }
        [TestMethod]
        public void GetBaseOne()
        {
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name, languages[0].Id, languages[1].Id, new List<Translation> { tr1 });
            Sheet testSh;
            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                testSh = sheetRepo.Get(sh1.Id);
            }
            Assert.AreEqual(testSh.TranslationSet.Count(), 0);

        }
        [TestMethod]
        public void GetOneWithTranslation()
        {
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name, languages[0].Id, languages[1].Id, new List<Translation> { tr1 });
            Sheet testSh;
            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                testSh = sheetRepo.Get(sh1.Id);
            }
            throw new NotImplementedException();
            Assert.AreEqual(testSh.TranslationSet.Count(), 0);

        }

        [TestMethod]
        public void GetBaseMany()
        {
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            Translation tr2 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name, languages[0].Id, languages[1].Id, new List<Translation> { tr1, tr2 });
            List<Sheet> testSh;
            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                testSh = sheetRepo.GetAll().ToList();
            }
            Assert.AreEqual(testSh.Count, 1);
            Assert.AreEqual(testSh[0].TranslationSet.Count(), 0);

        }
        [TestMethod]
        public void GetBaseManyParameter()
        {
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            Translation tr2 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name, languages[0].Id, languages[1].Id, new List<Translation> { tr1, tr2 });
            List<Sheet> testSh;
            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                testSh = sheetRepo.GetAll(true, false).ToList();
            }
            Assert.AreEqual(testSh.Count, 1);
            Assert.AreEqual(testSh[0].TranslationSet.Count(), 0);

        }
        [TestMethod]
        public void GetCalculatedMany()
        {
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            Translation tr2 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), languages[1].Id), new Word(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id) }
            };
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name, languages[0].Id, languages[1].Id, new List<Translation> { tr1, tr2 });
            List<Sheet> testSh;
            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                testSh = sheetRepo.GetAll(true, false).ToList();
            }
            Assert.AreEqual(testSh.Count, 1);
            Assert.AreEqual(testSh[0].TranslationSet.Count(), 2);

        }

    }
}
