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
	public class EnSentence : Sentence
    {
		public PlSentence plSentence { get; set; }

	}
}
