using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    abstract public class Word : EntityBase, IIdentifiableEntity
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int? PartOfSpeechId { get; set; }
        [DataMember]
        public PartOfSpeech? PartOfSpeech { get; set; }
        [DataMember]
        public DateTime LastInput { get; set; }
        [DataMember]
        public int Progress { get; set; }
        [DataMember]
        public List<Tag> Tags { get; set; }
        [DataMember]
        public List<Sheet> SheetSet { get; set; }
        [NotMapped]
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }


    }
}