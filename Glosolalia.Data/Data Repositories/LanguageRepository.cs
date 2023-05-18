using System.ComponentModel.Composition;

using Glosolalia.Common.Entities;

namespace Glosolalia.Data
{
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class LanguageRepository : DataRepositoryBase<Language>
	{
	}

}
