

using Glosolalia.Common.Entities;
using Glosolalia.Data.Repository_Interface;

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
				WordSet =new() { new Word("tr", 1), new Word("triallo", 2) }
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
                                WordSet =new() { new Word("tr", 1), new Word("triallo", 2) }
                                }
							,new Translation()
							{
								Id = 2,
                                WordSet =new() { new Word("trll", 1), new Word("triallo", 2) }
                                }
							,new Translation()
							{
								Id = 3,
                                WordSet =new() { new Word("aatr", 1), new Word("triallo", 2) }
                            }
							,new Translation()
							{
								Id = 4,
                                WordSet =new() { new Word("vvtr", 1), new Word("triallo", 2) }
                            }
							,new Translation()
							{
								Id = 10,
                                WordSet =new() { new Word("twwr", 1), new Word("triallo", 2) }
                            }
							,new Translation()
							{
								Id = 199,
                                WordSet =new() { new Word("rrtr", 1), new Word("triallo", 2) }
                                },
								});




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
