using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities
{
	[DataContract]
	public class Sheet:IIdentifiableEntity
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EnWord> EnWordSet{ get; set; }
        public List<EsWord> EsWordSet{ get; set; }
        public List<EnSentence> EnSentenceSet { get; set; }
        public List<EsSentence> EsSentenceSet { get; set; }
        public int EntityId
		{
			get { return Id; }
			set { Id = value; }
		}
	}
}
