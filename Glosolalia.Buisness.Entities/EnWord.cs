using System.Runtime.Serialization;
using Glosolalia.Buisness.Entities.Glosolalia.Buisness.Entities.Abstraction;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class EnWord : Word
    {
        [DataMember]
        public List<EnWordPlWord> PlTranslation { get; set; }
    }


}