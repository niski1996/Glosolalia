using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Words;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
    public class EsSentence : Sentence
    {
        public PlSentence plTranslation { get; set; }
		public int plTranslationId { get; set; }
		public List<EsWord> EsWordSet { get; set; }

    }
}
