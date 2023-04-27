using System.Runtime.Serialization;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class EnWordPlWord
    {
        [DataMember]
        public int IdPlWord { get; set; }
        [DataMember]
        public int IdEnWord { get; set; }
    }


}