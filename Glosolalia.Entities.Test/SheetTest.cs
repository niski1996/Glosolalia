//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;
//using Glosolalia.Common.Entities;

//namespace Glosolalia.Entities.Test
//{
//    [TestClass]
//    internal class SheetTest
//    {
//        private List<Language> languages=null!;

//        [TestInitialize]
//        public void Initialize()
//        {
//            languages = new List<Language> { new Language() { Name="polski", Id=1},
//            new Language() { Name="chinski", Id=2}
//            };

//        }
//        [TestMethod]
//        public void AddingWithOneWord()// do wyjebania, nie pownno sie dać stworzyćtakiej translacji
//        {
//            Word wrd1 = new Word(Guid.NewGuid().ToString(), languages[0]);
//            Word wrd2 = new Word(Guid.NewGuid().ToString(), languages[0]);
//            Word wrd3 = new Word(Guid.NewGuid().ToString(), languages[0]);

//            Translation tr1 = new Translation("kuas");


//        }
//        [TestMethod]
//        public void AddingWithThreeWord()
//        {
//            var tranRepo = new TranslationRepository();
//            var name = Guid.NewGuid().ToString();
//            Word wrd1 = new Word(name, 1);

//            Translation tr1 = new Translation()
//            {
//                WordSet = new() { new Word(name, 1) }
//            };


//            using (GlosolaliaContext context = new GlosolaliaContext(builder.Options))
//            {
//                tranRepo.Add(tr1, context);
//                context.SaveChanges();
//                Assert.ThrowsException<NotImplementedException>(() => { return 0; });
//                ;

//            };
//        }
//    }
//}
