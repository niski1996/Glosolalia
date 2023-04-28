using System.Runtime.Serialization;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class PlWord : Word
    {
        [DataMember]
        public List<EnWordPlWord> EnTranslation { get; set; }
    }


}