using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Words;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
	public class EsSentence : Sentence, ITranslatableSentence, IValue
    {
		[DataMember]
		public int PlSenttenceId { get; set; }
        private PlSentence _plSentence;
		[DataMember]
		public PlSentence PlSentence
        {
            get { return _plSentence; }
            set
            {
                _plSentence = value;
                _plSentence.EsSentence = this;
            }
        }
		[DataMember]
		public int PlSEstenceId { get; set; }

        private List<EsWord> _esWordSet;
		[DataMember]
		public List<EsWord> snWordSet
        {
            get { return _esWordSet; }
            set { _esWordSet = value; }
        }
    }
}
