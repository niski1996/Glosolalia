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
		public List<Word> WordSet { get; set; } = new ();//Tzeba sprawdzać czy są dokładnie 2, property zalnie sie tym która translacja jest jaka
		public int Progress { get; set; } = 0;
		public int? PartOfSpeechId { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public List<Tag> Tags { get; set; } = new();
		public DateTime LastInput { get; set; } = DateTime.Now;
		public List<Sheet> SheetSet { get; set; } = new();
	}


}