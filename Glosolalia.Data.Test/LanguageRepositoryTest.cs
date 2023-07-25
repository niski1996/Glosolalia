//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Glosolalia.Common.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Glosolalia.Data.Test
//{
//    [TestClass]
//    public class LanguageRepositoryTest
//    {

//        private DbContextOptionsBuilder<GlosolaliaContext> builder = new();
//        [TestInitialize]
//        public void Initialize()
//        {
//            bool flagInMemory = true;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
//            flagInMemory = false;// flaga do ręcznej zamiany ktora sprawia że testy bedąin-memory albo in database
//            if (flagInMemory)
//            {
//                this.builder.UseInMemoryDatabase("SharedDatabase");
//            }
//            else
//            {
//                using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
//                {
//                    context.Database.EnsureDeleted();
//                    context.Database.EnsureCreated();
//                }
//            }
//        }


//        [TestMethod]
//        public void GetOneLanguageTest()
//        {
//            var ln = new Language() { Name = "Polish", Wor };
//            var lnRpo = new LanguageRepository();
//            ln = lnRpo.Add(ln);
//            var wrd1 = new Word(Guid.NewGuid().ToString(), ln.Id);
//            var wrdRpo = new WordRepository();
//            wrdRpo.Add(wrd1);
//            var testln = lnRpo.Get(ln.Id);
//            Assert.AreEqual(testln.WordSet.Count(), 0);


//        }
//        [TestMethod]
//        public void GetOneLanguageWithWordsTest()
//        {
//            var ln = new Language() { Name = "Polish", WordSet = new() };
//            var lnRpo = new LanguageRepository();
//            ln = lnRpo.Add(ln);
//            var wrd1 = new Word(Guid.NewGuid().ToString(), ln.Id);
//            var wrdRpo = new WordRepository();
//            wrdRpo.Add(wrd1);
//            Language testln;
//            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
//            {
//                testln=context.LanguageSet.Include(e=>e.WordSet).Where(e => e.Id == ln.Id).FirstOrDefault();
//            }

//            Assert.AreEqual(testln.WordSet.Count(), 1);


//        }
//    }
//}
