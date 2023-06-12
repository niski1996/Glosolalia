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
        public Translation(List<Sheet> sheetSet,PartOfSpeech? PartOfSpeech= null, List < Tag >? tags=null)
        {
			if (sheetSet.Count()!=2)
			{
				throw new ApplicationException("translation must contain exacly 2 words");
			}
        }
		public int Id { get; set; }
		public List<Word> WordSet { get; set; } = new ();//Tzeba sprawdzać czy są dokładnie 2, property zalnie sie tym która translacja jest jaka, potem taka konstrukcja bedzie wygodniejsza przy wyswietlaniu fiszek
		public int Progress { get; set; } = 0;
		public int? PartOfSpeechId { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public List<Tag> Tags { get; set; } = new();
		public DateTime LastInput { get; set; } = DateTime.Now;
		public List<Sheet> SheetSet { get; set; } = new();
	}


}