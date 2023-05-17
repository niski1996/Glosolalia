using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class Translation: EntityBase, IIdentifiableEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public HashSet<Language> LanguageSet { get; set; }
		public HashSet<Word> TranslatableSet { get; set; } // NOTE  warto zrobić HashSet of itransable, ale to później
		public int Progress { get; set; }
		public int? PartOfSpeechId { get; set; }
		public PartOfSpeech? PartOfSpeech { get; set; }
		public HashSet<Tag> Tags { get; set; }
		public DateTime LastInput { get; set; }
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
	}
	[DataContract]
	public class Sheet
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
		public HashSet<Translation> TranslationSet{ get; set; }

}
	public interface ITransable
	{
		public string Value { get; set; }
		public Language Language { get; set; }

	}

	[DataContract]
	public class Language
	{
		public string Name { get; set; }
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public HashSet<Translation> TranslationSet { get; set; }
		public HashSet<Word> WordSet { get; set; }
	}


	[DataContract]
	public class Word : EntityBase, IIdentifiableEntity, ITransable

	{
        public Word()
        {
            
        }
        public Word(string value)
		{
			Value = value;

		}
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Value { get; set; }
		public HashSet<Translation> TranslationSet { get; set; }


		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}

		public Language Language { get; set; }
        public int LanguageId { get; set; }

    }


}