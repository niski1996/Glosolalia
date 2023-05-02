using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    public class PartOfSpeech:EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        [NotMapped]
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }


}