using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities
{
	[DataContract]
	public class Sentence: EntityBase, IIdentifiableEntity
	{ 
        [DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Value { get; set; }

		[DataMember]
		public DateTime LastInput { get; set; }
		[DataMember]
		public int Progress { get; set; }
		[DataMember]
		public List<Tag> Tags { get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
		[DataMember]
        public List<Sheet> SheetSet { get; set; }

    }
}
