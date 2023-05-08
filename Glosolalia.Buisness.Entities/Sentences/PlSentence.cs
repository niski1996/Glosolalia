using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
	public class PlSentence : Sentence
	{
		[DataMember]
		public EnSentence EnSentence { get; set; }
		[DataMember]
		public EsSentence EsSentence { get; set; }
		[DataMember]
		private List<PlWord> _plWordSet;
		[DataMember]
		public List<PlWord> PlWordSet
		{
			get { return _plWordSet; }
			set { _plWordSet = value; }
		}
	}
}
