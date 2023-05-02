using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    [Table("PlWords")]
    public class PlWord : Word
    {
        public PlWord()
        {
            
        }
        public PlWord(string value) : base(value)
        {
        }
        [NotMapped]
        private List<EnWord> _enWords;

        [DataMember]
        public List<EnWord> EnWords 
        { 
            get
            {
                if (_enWords is null)
                {
                    _enWords = new List<EnWord>();
                }
                return _enWords;
            }
            set
            {
                _enWords = value;
            }
        }

    }


}