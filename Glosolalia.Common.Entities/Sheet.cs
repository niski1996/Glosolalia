using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class Sheet : IIdentifiableEntity
	{
        public Sheet()
        {
			TranslationSet = new();
		}
        public Sheet(string name):this()
        {
			Name = name;
			
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
		public List<Translation> TranslationSet{ get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}

	}


}