using System.Runtime.Serialization;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class PlSentence : Sentence
	{
		public EnSentence enSentence { get; set; }
		public EsSentence esSentence { get; set; }

	}
}
