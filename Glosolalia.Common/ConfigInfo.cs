using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosolalia.Common.Contracts;

namespace parserExddcel
{
	public class ConfigInfo
	{
		private Type _entityType;

		public Type EntityType
		{
			get { return _entityType; }
			set
			{
				if (typeof(IValue).IsAssignableFrom(value))
				{
					_entityType = value;
				}
				else
				{
					throw new ArgumentException($"Type '{value.Name}' does not implement interface 'IParsableGloso'");
				}
			}
		}

		public int Column { get; set; }//only applied to Excel parser
		public int StartRow { get; set; }//only applied to Excel parser
	}
}
