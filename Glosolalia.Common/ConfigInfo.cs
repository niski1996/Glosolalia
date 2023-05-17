using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Contracts;

namespace Glosolalia.Common
{
	public class ConfigInfo
	{
		public Type EntityType { get; set; }

		public int Column { get; set; }//only applied to Excel parser
		public int StartRow { get; set; }//only applied to Excel parser
	}
}
