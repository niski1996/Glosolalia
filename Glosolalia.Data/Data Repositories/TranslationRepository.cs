using System.ComponentModel.Composition;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data
{
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class TranslationRepository : DataRepositoryBase<Translation> { }


}
