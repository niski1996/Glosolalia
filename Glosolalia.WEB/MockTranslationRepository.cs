using Glosolalia.Common.Entities;
using Glosolalia.Data;

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
			Id=1,

		});
	}

	public IEnumerable<Translation> GetAll()
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

	public Translation Update(Translation entity)
	{
		throw new NotImplementedException();
	}
}