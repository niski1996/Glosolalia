using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosolalia.Domain
{
    public class PlWord:Word
    {
        public PlWord(string val, Language lang) : base(val, lang)
        {
        }

        public List<EnWordPlWord> EnTranslation { get; set; }
    }
}
