using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Business.Entities
{
    public interface ITranslatableSentence
	{
		public PlSentence PlSentence { get; set; }
	}
}