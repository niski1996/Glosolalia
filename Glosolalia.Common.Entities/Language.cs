using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class Language:IIdentifiableEntity
	{
        public Language()
		{
			WordSet = new();
		}
        public Language(string name):this()
        {
			Name = name;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Word> WordSet { get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
	}


}