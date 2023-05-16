using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class EnWord : Word, IValue
	{

		public HashSet<PlWord> plWords = new();

		public EnWord(string value, PartOfSpeech prt = null, HashSet<Sentence> sentenceSet = null, HashSet<Tag> tagSet = null) : base(value, prt, sentenceSet, tagSet)
		{
		}
	}
}


