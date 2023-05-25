

using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data.Data_MockRepositories
{

	public class MockTranslationRepository : ITranslationRepository
	{
		public Translation Add(Translation entity)
		{
			throw new NotImplementedException();
		}

        public Translation Add(Translation entity, GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }

        public Translation Get(int id)
		{
			return (new Translation()
			{
				Id = 1,
				TranslatableFrom = new Word("tr", 1),
				TranslatableTo = new Word("triallo", 2)
			});
		}

        public Translation Get(int id, GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Translation> GetAll()
		{
			return (new List<Translation>() {
							new Translation()
							{
								Id = 1,
								TranslatableFrom = new Word("kot", 1),
								TranslatableTo = new Word("cat", 2) }
							,new Translation()
							{
								Id = 2,
								TranslatableFrom = new Word("dom", 1),
								TranslatableTo = new Word("house", 2) }
							,new Translation()
							{
								Id = 3,
								TranslatableFrom = new Word("droga", 1),
								TranslatableTo = new Word("road", 2) }
							,new Translation()
							{
								Id = 4,
								TranslatableFrom = new Word("krzesło", 1),
								TranslatableTo = new Word("chair", 2) }
							,new Translation()
							{
								Id = 10,
								TranslatableFrom = new Word("mysz", 1),
								TranslatableTo = new Word("mouse", 2) }
							,new Translation()
							{
								Id = 199,
								TranslatableFrom = new Word("pies", 1),
								TranslatableTo = new Word("dog", 2)}, });




		}

        public IEnumerable<Translation> GetAll(GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }

        public void Remove(Translation entity)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

        public void Remove(Translation entity, GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }

        public Translation Update(Translation entity)
		{
			throw new NotImplementedException();
		}

        public Translation Update(Translation entity, GlosolaliaContext context)
        {
            throw new NotImplementedException();
        }
    }
}
