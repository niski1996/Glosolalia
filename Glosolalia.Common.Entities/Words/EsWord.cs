using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
    public class EsWord : Word, IValue
    {
		public HashSet<PlWord> plWords = new();

		public EsWord(string value, PartOfSpeech prt = null, HashSet<Sentence> sentenceSet = null, HashSet<Tag> tagSet = null) : base(value, prt, sentenceSet, tagSet)
		{
		}
	}
}