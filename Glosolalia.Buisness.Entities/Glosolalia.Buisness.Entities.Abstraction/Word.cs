using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    abstract public class Word : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public Language Language { get; set; }
        [DataMember]
        public PartOfSpeech? PartOfSpeech { get; set; }
        [DataMember]
        public DateTime LastInput { get; set; }
        [DataMember]
        public int Progress { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }


    }


}