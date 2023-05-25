using System.ComponentModel.DataAnnotations;
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
		[Required]
        public string Name { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
		public DateTime LastEdit { get; set; } = DateTime.Now;
		public List<Translation> TranslationSet { get; set; } = new();
		[NotMapped]
        public Dictionary<int, int> ProgressDictionary { get; set; } = new();/* dictionary show progress - how many is in these sheet Translation with
                                                                              * exact progress, for example  Translation with progress1, 0 Translation with 5 etc. */
        [NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}

	}


}