using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    public class EnWord : Word
    {
        public EnWord()
        { }
        [DataMember]
        public List<PlWord> PlWords { get; set; }
    }
}


