using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class Translation: EntityBase, IIdentifiableEntity
	{
        public Translation()
        {

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public Word TranslatableFrom { get; set; }//NOTE tu powinien być interfejs ale EF sie darł że źle
		public Word TranslatableTo { get; set; } //NFrom i to powinny moc byx dowolnie zamieniane, nie powinny miiec znaczenia dla programu

		public int Progress { get; set; } = 0;
		public int? PartOfSpeechId { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public List<Tag> Tags { get; set; } = new();
		public DateTime LastInput { get; set; } = DateTime.Now;
		public List<Sheet> SheetSet { get; set; } = new();
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
	}


}