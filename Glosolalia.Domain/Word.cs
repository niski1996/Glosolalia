using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.entities;

namespace Glosolalia.Domain
{
    abstract public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public PartOfSpeech PartOfSpeech { get; set; }
        public DateTime LastInput { get; set; }
        public int Progress { get; set; }


    }
}
