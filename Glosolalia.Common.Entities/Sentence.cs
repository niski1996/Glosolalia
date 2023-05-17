using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{

	public abstract class Sentence : EntityBase, IIdentifiableEntity

	{


		public int Id { get; set; }

		public string Value { get; set; }


		public DateTime LastInput { get; set; }

		public int Progress { get; set; }

		public List<Tag> Tags { get; set; }
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
		public HashSet<Word> WordSet = new();
	} 
	

}
