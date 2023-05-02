using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    [Table("PlWords")]
    public class PlWord : Word
    {
        [DataMember]
        public List<EnWord> EnWords { get; set; }


    }


}