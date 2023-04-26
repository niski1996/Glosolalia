using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosolalia.Domain
{
    public class EnWord:Word
    {
        public EnWord(string val, Language lang) : base(val, lang)
        {
        }

        public List<EnWordPlWord> PlTranslation { get; set; }
    }
}
