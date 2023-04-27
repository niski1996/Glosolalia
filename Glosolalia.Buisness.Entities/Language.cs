﻿using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class Language : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }


}