using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Glosolalia.Common.Entities
{


	[DataContract]
	public class Word : EntityBase, IIdentifiableEntity, ITransable

	{
        public Word()
        {
			TranslationSet = new();

		}
        public Word(string value, int languageId):this()
		{
			Value = value;
			LanguageId = languageId;

		}
        public Word(string value, Language language) : this(value,language.Id) {}


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Value { get; set; }
		public List<Translation> TranslationSet { get; set; }


		public Language Language { get; set; }
        public int LanguageId { get; set; }

    }


}