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
    public class SheetRepositoryAddingTest
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
                    List<Language> li = new() {new Language() { Name = "Spanish" },
                    new Language() { Name = "Polish",  },
                    new Language() { Name = "English", } };
                    context.LanguageSet.AddRange(li);
                    context.SaveChanges();
                    languages = context.LanguageSet.ToList();

                }
            }
        }
        #region Adding_test
        [TestMethod]
        public void BaseSheetAdding()
        {

            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet("jonasz", languages[0].Id, languages[1].Id)
            {
                Id = 3
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sheetRepo.Add(sh1, context);
                Assert.AreEqual(EntityState.Added, context.Entry(sh1).State);
            }

        }
        [TestMethod]
        public void DuplicateSheetAdding()
        {
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet("jonasz", languages[0].Id, languages[1].Id)
            {
                //Id = 3
            };
            Sheet sh4 = new Sheet("jonasz", languages[0].Id, languages[1].Id)
            {
                //Id = 4
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sheetRepo.Add(sh1, context);
                context.SaveChanges();
                Assert.ThrowsException<DbUpdateException>(() =>
                {
                    sheetRepo.Add(sh4, context);
                    context.SaveChanges();
                });
            }

        }
        [TestMethod]
        public void SheetWithTranslationsAllNewAdding()
        {
            var sheetRepo = new SheetRepository();
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8).Substring(0, 8), 1), new Word(Guid.NewGuid().ToString().Substring(0, 8), 2) }
            };
            Sheet sh1 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {
                //Id = 3,
                TranslationSet = new() { tr1 },
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                int sh = context.SheetSet.Count();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                sheetRepo.Add(sh1, context);
                context.SaveChanges();
                int sh2 = context.SheetSet.Count();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(sh + 1, sh2);
                Assert.AreEqual(wr + 2, wr2);
                Assert.AreEqual(tr + 1, tr2);

            }

        }
        [TestMethod]
        public void SheetWithTranslationsAllNewOneTranslationDoubleMeaningAdding()
        {
            var name = Guid.NewGuid().ToString().Substring(0, 8);
            var sheetRepo = new SheetRepository();
            Translation trs1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8), 1), new Word(name, 2) }
            };
            Translation trs2 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8), 1), new Word(name, 2) }
            };
            Sheet sh1 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {
                //Id = 3,
                TranslationSet = new() { trs1, trs2 },
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                int sh = context.SheetSet.Count();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                sheetRepo.Add(sh1, context);
                context.SaveChanges();
                int sh2 = context.SheetSet.Count();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(sh + 1, sh2);
                Assert.AreEqual(wr + 3, wr2);
                Assert.AreEqual(tr + 2, tr2);

            }

        }
        [TestMethod]
        public void SheetWithTranslationsExistingAdding()
        {
            var sheetRepo = new SheetRepository();
            var trRepo = new TranslationRepository();
            var n1 = Guid.NewGuid().ToString().Substring(0, 8);
            var n2 = Guid.NewGuid().ToString().Substring(0, 8);
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(n1, 1), new Word(n2, 2) }
            };

            Sheet sh1 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {
                TranslationSet = new() { tr1 },
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                trRepo.Add(tr1, context);
                context.SaveChanges();
                int sh = context.SheetSet.Count();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                sheetRepo.Add(sh1, context);
                context.SaveChanges();
                int sh2 = context.SheetSet.Count();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(sh + 1, sh2);
                Assert.AreEqual(wr, wr2);
                Assert.AreEqual(tr, tr2);

            }
        }
        [TestMethod]
        public void addingTwoIdenticalSheetsAdding()
        {
            var sheetRepo = new SheetRepository();
            var trRepo = new TranslationRepository();
            var n1 = Guid.NewGuid().ToString().Substring(0, 8);
            var n2 = Guid.NewGuid().ToString().Substring(0, 8);
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(n1, 1), new Word(n2, 2) }
            };
            Translation tr2 = new Translation()
            {
                WordSet = new() { new Word(n1, 1), new Word(n2, 2) }
            };


            Sheet sh1 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {
                TranslationSet = new() { tr1 },
            };
            Sheet sh2 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {
                TranslationSet = new() { tr2 },
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {

                int sh = context.SheetSet.Count();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                trRepo.Add(tr1, context);
                context.SaveChanges();
                sheetRepo.Add(sh1, context);
                context.SaveChanges();
                sheetRepo.Add(sh2, context);
                context.SaveChanges();
                int shi2 = context.SheetSet.Count();
                int wr2 = context.Words.Count();
                int tra2 = context.TranslationSet.Count();
                Assert.AreEqual(sh, shi2 - 2);
                Assert.AreEqual(wr, wr2 - 2);
                Assert.AreEqual(tr, tra2 - 1);

            }
        }
        #endregion
        #region deleting
        [TestMethod]
        public void SheetDeleting()
        {
            var sheetRepo = new SheetRepository();
            Translation tr1 = new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString().Substring(0, 8), 1), new Word(Guid.NewGuid().ToString().Substring(0, 8), 2) }
            };
            Sheet sh1 = new Sheet(Guid.NewGuid().ToString().Substring(0, 8), languages[0].Id, languages[1].Id)
            {

                TranslationSet = new() { tr1 },
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                int sh = context.SheetSet.Count();
                int wr = context.Words.Count();
                int tr = context.TranslationSet.Count();
                sheetRepo.Remove(sh1.Id);
                context.SaveChanges();
                int sh2 = context.SheetSet.Count();
                int wr2 = context.Words.Count();
                int tr2 = context.TranslationSet.Count();
                Assert.AreEqual(sh - 1, sh2);
                Assert.AreEqual(wr, wr2);
                Assert.AreEqual(tr, tr2);

            }

        }
        #endregion


    }
}
