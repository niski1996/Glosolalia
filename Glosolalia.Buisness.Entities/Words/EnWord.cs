using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Words
{
    [DataContract]
    public class EnWord : Word
    {
        public List<PlWord> PlWordSet { get; set; }
        public List<EnSentence> EnSentenceSet { get; set; }

    }
}


