using System.Runtime.Serialization;
using Core.Common.Contracts;
using Core.Common.Core;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
    public abstract class Word : EntityBase, IIdentifiableEntity

    {
        public Word(string value, PartOfSpeech prt = null, HashSet<Sentence> sentenceSet = null, HashSet<Tag> tagSet = null)
        {
            Value = value;
            LastInput = DateTime.Now;
            Progress = 0;
            PartOfSpeech = prt;

            if (!(sentenceSet is null)) sentenceSet = sentenceSet;

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
        public HashSet<Sentence> sentenceSet = new();

    }
}