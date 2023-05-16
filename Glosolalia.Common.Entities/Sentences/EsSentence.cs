using System.Runtime.Serialization;

using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
    public class EsSentence : Sentence
    {
		public PlSentence plSentence { get; set; }

	}
}
