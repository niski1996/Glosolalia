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
			TranslatableSet = new();
			Progress = 0;
			Tags = new();
			LastInput = DateTime.Now;

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public List<Word> TranslatableSet { get; set; } //NOTE tu powinien być interfejs ale EF sie darł że źle
		public int Progress { get; set; }
		public int? PartOfSpeechId { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public List<Tag> Tags { get; set; }
		public DateTime LastInput { get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
	}


}