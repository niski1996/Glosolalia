using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosolalia.Business.Entities
{
	public interface ITranslatable //HACK should be in Glosolalia.common.contract, but circular dependency
	{
		public List<PlWord> PlWords { get; }
		public void TranslationAding(PlWord plWord);
	}
}
