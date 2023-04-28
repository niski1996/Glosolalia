using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Buisness.Entities
{
    [DataContract]
    public class Language : EntityBase, IIdentifiableEntity
    {
        public Language()
        {
            
        }
        public Language(string name)
        {
            Name = name;
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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