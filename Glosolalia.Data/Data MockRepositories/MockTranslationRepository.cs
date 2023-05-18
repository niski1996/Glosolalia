

using Glosolalia.Common.Entities;

namespace Glosolalia.Data.Data_MockRepositories
{

	public class MockTranslationRepository : ITranslationRepository
	{
		public Translation Add(Translation entity)
		{
			throw new NotImplementedException();
		}

		public Translation Get(int id)
		{
			return (new Translation()
			{
				Id = 1,
				TranslatableSet = new() {
					new Word("trial",1)
					,new Word("triallo",2)
				}

			});
		}

		public IEnumerable<Translation> GetAll()
		{
			return (new List<Translation>() {
							new Translation()
							{
								Id = 1,
								TranslatableSet = new() {
					new Word("trial",1)
					,new Word("triallo",2)
				} }
							,new Translation()
							{
								Id = 1,
								TranslatableSet = new() {
					new Word("kutas",1)
					,new Word("dicco",2)
				}, }});

								

							
		}

		public void Remove(Translation entity)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}

		public Translation Update(Translation entity)
		{
			throw new NotImplementedException();
		}
	}
}
