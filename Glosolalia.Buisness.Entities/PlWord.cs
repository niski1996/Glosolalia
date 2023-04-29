using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    [Table("PlWords")]
    public class PlWord : Word
    {
        [DataMember]
        public List<EnWordPlWord> EnTranslation { get; set; }
    }


}