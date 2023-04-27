using System.Runtime.Serialization;
using Glosolalia.Buisness.Entities.Glosolalia.Buisness.Entities.Abstraction;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class PlWord : Word
    {
        [DataMember]
        public List<EnWordPlWord> EnTranslation { get; set; }
    }


}