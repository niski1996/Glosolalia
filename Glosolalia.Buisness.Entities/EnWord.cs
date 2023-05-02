using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    public class EnWord : Word
    {
        public EnWord()
        { }

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
                    _plWords= new List<PlWord>();
                }
                return _plWords;
            }
            set
            {
                _plWords = value;
            }
        }
    }
}


