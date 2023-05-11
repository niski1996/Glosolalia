using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Glosolalia.Common.Entities
{
    public class PartOfSpeech:EntityBase, IIdentifiableEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
    }


}