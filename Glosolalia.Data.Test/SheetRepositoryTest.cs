using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Entities;
using Glosolalia.Data.Data_MockRepositories;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Data.Test
{

    [TestClass]
    public class SheetRepositoryTest
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
        #region Adding_test
        [TestMethod]
        public void BaseSheetAdding()
        {
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet("jonasz")
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
            Sheet sh1 = new Sheet("jonasz")
            {
                //Id = 3
            };
            Sheet sh4 = new Sheet("jonasz")
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
            Translation tr1 =new Translation()
            {
                WordSet = new() { new Word(Guid.NewGuid().ToString(), 1), new Word(Guid.NewGuid().ToString(), 2) }
            };
            Sheet sh1 = new Sheet(Guid.NewGuid().ToString())
            {
                //Id = 3,
                TranslationSet = new() { tr1},
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
                Assert.AreEqual(sh+1,sh2);
                Assert.AreEqual(wr + 2, wr2);
                Assert.AreEqual(tr+1, tr2);

            }

        }
        #endregion
        #region getting_test
        [TestMethod]
        public void BaseSheetGetting()
        {
            var name = Guid.NewGuid().ToString();
            var sheetRepo = new SheetRepository();
            Sheet sh1 = new Sheet(name)
            {
                //Id = 3
            };

            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
            {
                sh1 = sheetRepo.Add(sh1, context);
                context.SaveChanges();
                var tmp = sheetRepo.Get(sh1.Id);
            }

        }
        #endregion


    }
}
