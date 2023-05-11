﻿using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;
using Glosolalia.Common.Entities.Sentences;

namespace Glosolalia.Common.Entities
{
    [DataContract]
    public class Tag: EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

	}


}