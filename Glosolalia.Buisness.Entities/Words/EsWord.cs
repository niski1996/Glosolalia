using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Business.Entities.Words
{
    public class EsWord : Word
    {
        public List<PlWord> PlWordSet { get; set; }
        public List<EsSentence> SentenceSet { get; set; }
    }
}