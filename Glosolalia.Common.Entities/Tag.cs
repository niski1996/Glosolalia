﻿using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
    [DataContract]
    public class Tag: EntityBase, IIdentifiableEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public HashSet<Translation> TranslationSet { get; set; }
		public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }

	}


}