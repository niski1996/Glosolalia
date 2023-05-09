using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    abstract public class Word<T> : EntityBase, IIdentifiableEntity,ISentenceSet where T:IWordSet
	{
        public Word()
        {
            
        }
        public Word(string value)
        {
            Value = value;
            LastInput = DateTime.Now;
            Progress = 0;
        }
        public Word(string value, PartOfSpeech prt) :
            this(value)
        {
            PartOfSpeech = prt;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int? PartOfSpeechId { get; set; }
        [DataMember]
        public PartOfSpeech? PartOfSpeech { get; set; }
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
        public HashSet<T> _SentenceSet { get; set; }/*thist construction help to avoid on-side-orphaned relations.
                                                           * when A has relation with B, B must have relation with A*/

		public HashSet<T> GetAllSentences()
		{
			return _SentenceSet;
		}

		public void _addSentence(IWordSet sentence)//NOTE  to prevent looping.don't create feedback from PlSentence, prefer internal, but interface have problems
		{
            _SentenceSet.Add((T)sentence);//REFACTOR not sure about this implementation, maybe can do better
		}
		public void AddSentnence(T sentence)
		{
			_SentenceSet.Add(sentence);
            sentence._addWord(this);

		}

	}


}