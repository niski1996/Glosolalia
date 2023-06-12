//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Glosolalia.Common.Entities;
//using Glosolalia.Data.Repository_Interface;

//namespace Glosolalia.Data.Data_MockRepositories
//{
//    public class MockSheetRepository : ISheetRepository
//    {
		

//		public Sheet Add(Sheet entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Sheet Add(Sheet entity, GlosolaliaContext context)
//        {
//            throw new NotImplementedException();
//        }

//        public Sheet Get(int id, GlosolaliaContext context = null)
//        {
//            throw new NotImplementedException();
//        }



//        //public Sheet Get(int id, GlosolaliaContext context)
//        //{

//        //    IEnumerable<Translation> tmp = new MockTranslationRepository().GetAll();
//        //    return (new Sheet("jonasz")
//        //    {
//        //        Id = 1
//        //        ,
//        //        TranslationSet = tmp.ToList()
//        //    });
//        //}


//        //public IEnumerable<Sheet> GetAll(bool translationIncluded, GlosolaliaContext? context = null)
//        //{
//        //    return (new List<Sheet> {
//        //    new Sheet("jonasz"){
//        //    Id=1}
//        //    ,new Sheet("zachariasz"){Id=3,TranslationSet = new MockTranslationRepository().GetAll().ToList()}
//        //    ,new Sheet("rut"){Id=7 }});
//        //}

//        public IEnumerable<Sheet> GetAll(GlosolaliaContext? context = null)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Sheet> GetAll(bool WordIncluded, bool AllIncluded, GlosolaliaContext? context = null)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Translation> GetWords(int sheetId)
//        {
//            return (new MockTranslationRepository().GetAll());
//        }

//        public void Remove(Sheet entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(Sheet entity, GlosolaliaContext? context = null)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(int id, GlosolaliaContext? context = null)
//        {
//            throw new NotImplementedException();
//        }

//        public Sheet Update(Sheet entity, GlosolaliaContext? context = null)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
