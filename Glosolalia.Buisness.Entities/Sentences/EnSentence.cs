using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Business.Entities.Words;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
	public class EnSentence : Sentence
	{
        public PlSentence plTranslation { get; set; }
        public int plTranslationId { get; set; }
        public List<EnWord> EnWordSet { get; set; }

    }
}
