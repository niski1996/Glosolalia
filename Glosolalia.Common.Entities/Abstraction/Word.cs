using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
    public abstract class Word<TWordSet> :
        EntityBase, IIdentifiableEntity, ISentenceSet<TWordSet>
        where TWordSet : IWordSet<ISentenceSet<TWordSet>>

    {
        public Word(string value, PartOfSpeech prt = null, HashSet<TWordSet> sentenceSet = null, HashSet<Tag> tagSet = null)
        {
            Value = value;
            LastInput = DateTime.Now;
            Progress = 0;
            PartOfSpeech = prt;

            if (!(_SentenceSet is null)) _SentenceSet = sentenceSet;

            if (tagSet is null) Tags = new();
            else Tags = tagSet;
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int? PartOfSpeechId { get; set; }
        public PartOfSpeech? PartOfSpeech { get; set; }
        public DateTime LastInput { get; set; }
        public int Progress { get; set; }
        public HashSet<Tag> Tags { get; set; }
        public int EntityId
        {
            get { return Id; }
            set { Id = value; }
        }
        private HashSet<TWordSet> _SentenceSet = new();

        public void AddSentence(TWordSet sentence)
        {
            _SentenceSet.Add(sentence);
            if (!sentence.GetAllWords().Contains(this))
            {
                sentence.AddWord(this);
            }
        }

        public IReadOnlySet<TWordSet> GetAllSenences()
        {
            IReadOnlySet<TWordSet> readOnly = _SentenceSet;

            return readOnly;
        }

        public void RemoveSentence(TWordSet sentence)
        {
			_SentenceSet.Remove(sentence);
			if (sentence.GetAllWords().Contains(this))
			{
				sentence.RemoveWord(this);
			}
		}
    }
}