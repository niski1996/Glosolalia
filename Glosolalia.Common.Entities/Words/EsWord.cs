using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities.Words
{
    public class EsWord : Word<EsSentence>, ITranslatableWord, IValue
    {
        public EsWord()
        { }

        public EsWord(string value) : base(value)
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
            plWord.EsWords.Add(this);//should automatically add relations and avoid one side relations
        }

        [DataMember]
        public string Value { get; set; }
    }
}