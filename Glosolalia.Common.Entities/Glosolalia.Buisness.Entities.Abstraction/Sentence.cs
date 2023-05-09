using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities
{
	[DataContract]
	public class Sentence<T>: EntityBase, IIdentifiableEntity, IWordSet where T:ISentenceSet
	{
        public Sentence()
        {
            
        }

        [DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Value { get; set; }

		[DataMember]
		public DateTime LastInput { get; set; }
		[DataMember]
		public int Progress { get; set; }
		[DataMember]
		public List<Tag> Tags { get; set; }
		[NotMapped]
		public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
		[DataMember]
		public HashSet<T> _WordSet { get; set; }/*thist construction help to avoid on-side-orphaned relations.
                                                           * when A has relation with B, B must have relation with A*/

		public virtual HashSet<T> GetAllWords()
		{
			return _WordSet;
		}

		public virtual void _addWord(ISentenceSet Word)//NOTE  to prevent looping.don't create feedback from PlWord
		{
			_WordSet.Add((T)Word);//REFACTOR not sure about this implementation, maybe can do better
		}
		public virtual void AddSentnence(T Word)
		{
			_WordSet.Add(Word);
			Word._addSentence(this);

		}




	}
}
