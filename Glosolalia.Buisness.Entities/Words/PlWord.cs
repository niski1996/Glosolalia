using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Words
{
    [DataContract]
    public class PlWord : Word
	{

        public List<EnWord> EnWords { get; set; }
        public List<EsWord> EsWords {get;set;}
        public List<PlSentence> SentenceSet { get; set; }

	}


}