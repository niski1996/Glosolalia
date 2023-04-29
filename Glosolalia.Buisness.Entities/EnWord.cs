using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class EnWord : Word
    {
        public EnWord()
        { }
        [DataMember]
        public List<EnWordPlWord> PlTranslation { get; set; }
    }
}


