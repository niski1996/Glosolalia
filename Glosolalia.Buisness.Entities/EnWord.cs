using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    [Table("EnWords")]
    public class EnWord : Word
    {
        public EnWord()
        {
            
        }
        [DataMember]
        public List<EnWordPlWord> PlTrans77lation { get; set; }  


        [DataMember]
        public List<EnWordPlWord> PlTranslation { get; set; }
    }


}