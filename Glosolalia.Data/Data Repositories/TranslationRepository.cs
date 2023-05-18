using System.ComponentModel.Composition;

using Glosolalia.Common.Entities;
using Glosolalia.Data.Contracts.Repository_Interface;

namespace Glosolalia.Data
{
	[Export(typeof(ITranslationRepository))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class TranslationRepository : DataRepositoryBase<Translation>, ITranslationRepository { }


}
