using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosolalia.Domain
{
    public class Language
    {
        public string Name { get; set; }
        public Language(string lang)
        {
            Name = lang;
        }
    }
}
