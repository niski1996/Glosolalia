using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	public class PlWord : Word, IValue
	{
		public HashSet<EsWord> enWords = new();
		public HashSet<EnWord> esWords = new();

		public PlWord(string value, PartOfSpeech prt = null, HashSet<Sentence> sentenceSet = null, HashSet<Tag> tagSet = null) : base(value, prt, sentenceSet, tagSet)
		{
		}


	}
}