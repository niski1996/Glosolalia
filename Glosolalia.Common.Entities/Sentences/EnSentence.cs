using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common.Entities
{
	[DataContract]
	public class EnSentence : Sentence<EnWord>//, ITranslatableSentence, IValue
    {
		//[DataMember]
		//      public int PlSenttenceId { get; set; }
		private PlSentence _plSentence;
		[DataMember]
		public PlSentence PlSentence
		{
			get { return _plSentence; }
			set { _plSentence = value; }
		}
		[DataMember]
		public int PlSentenceId { get; set; }
		[DataMember]
		private List<EnWord> _enWordSet;
		[DataMember]

		public List<EnWord> EnWordSet
        {
            get { return _enWordSet; }
            set { _enWordSet = value; }
        }


    }
}
