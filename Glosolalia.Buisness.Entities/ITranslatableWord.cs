using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities
{
    public interface ITranslatableWord //HACK should be in Glosolalia.common.contract, but circular dependency
	{
		public List<PlWord> PlWords { get; }
		public void TranslationAding(PlWord plWord);
	}
}
