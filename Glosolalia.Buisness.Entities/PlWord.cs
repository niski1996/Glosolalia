using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities
{
    [DataContract]
    [Table("PlWords")]
    public class PlWord : Word,IValue
    {
        public PlWord()
        {
            
        }
        public PlWord(string value) : base(value)
        {
        }
        /*Todo whole block of this list may be done better. maybe move initialization
         * of list to the constructor, but may be needed client class*/

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


		[NotMapped]
		private List<EsWord> _esWords;

		[DataMember]
		public List<EsWord> EsWords
		{
			get
			{
				if (_enWords is null)
				{
					_esWords = new List<EsWord>();
				}
				return _esWords;
			}
			set
			{
				_esWords = value;
			}
		}


	}


}