using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
	public class PlSentence : Sentence
	{
        public List<PlWord> PlWordSet { get; set; }
        public EnSentence EnTranslation { get; set; }
        public EsSentence EsTranslation { get; set; }

    }
}
