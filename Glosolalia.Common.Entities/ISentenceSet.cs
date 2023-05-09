using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosolalia.Business.Entities
{
	public interface ISentenceSet
	{
		public void _addSentence(IWordSet sentence);
	}
}
