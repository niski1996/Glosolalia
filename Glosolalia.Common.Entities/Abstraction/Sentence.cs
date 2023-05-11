using System.ComponentModel.DataAnnotations.Schema;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{

	public abstract class Sentence<TSentenceSet> : 
		EntityBase, IIdentifiableEntity, IWordSet<TSentenceSet>
		where TSentenceSet:ISentenceSet<IWordSet<TSentenceSet>>
		//NOTE has to be like that otherwise generic fedback add doest't work

	{


		public int Id { get; set; }

		public string Value { get; set; }


		public DateTime LastInput { get; set; }

		public int Progress { get; set; }

		public List<Tag> Tags { get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
		#region MTM words handling

		private HashSet<TSentenceSet> _WordSet = new();/*thist construction help to avoid on-side-orphaned relations.
                                                           * when A has relation with B, B must have relation with A*/



		public void AddWord(TSentenceSet word)
		{
			_WordSet.Add(word);
			if (!word.GetAllSenences().Contains(this))
			{
				word.AddSentence(this);
			}

		}

		public IReadOnlySet<TSentenceSet> GetAllWords()
		{
			IReadOnlySet<TSentenceSet> readOnly = _WordSet;
			return readOnly;
		}

		public void RemoveWord(TSentenceSet word)
		{
			_WordSet.Remove(word);
			if (word.GetAllSenences().Contains(this))
			{
				word.RemoveSentence(this);
			}

		}
		#endregion
	}

}
