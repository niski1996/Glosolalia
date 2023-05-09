using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities.Sentences
{
	[DataContract]
	public class PlSentence : Sentence<PlWord>
	{


		//public HashSet<PlWord> PlwordSet
		//{
		//	get { return _plWordSet; }
		//	set { _plWordSet = value; }
		//}

		//[DataMember]
		//public HashSet<PlWord> WordSet { get; set; }
		//[DataMember]
		//public EsSentence EsSentence { get; set; 
		//[DataMember]
		//protected HashSet<PlWord> WordSet
		//{
		//	get { return _WordSet; }
		//	set { _WordSet = value; }
		//}


	}
}
