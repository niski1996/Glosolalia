using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
    [DataContract]
    public class EnWord : Word<EnSentence>, ITranslatableWord, IValue
    {
        public EnWord(string value) : base(value)
        {
        }
        [NotMapped]
        private List<PlWord> _plWords;
        [DataMember]
        public List<PlWord> PlWords
        {
            get
            {
                if (_plWords is null)
                {
                    _plWords = new List<PlWord>();
                }
                return _plWords;
            }
        }
        public void TranslationAding(PlWord plWord)
        {
            _plWords.Add(plWord);
            //plWord.EnWords.Add(this);//should automatically add relations and avoid one side relations
        }

        [DataMember]
        public string Value { get; set; }
    }
}


