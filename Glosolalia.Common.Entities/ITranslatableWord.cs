namespace Glosolalia.Common.Entities
{
    public interface ITranslatableWord //HACK should be in Glosolalia.common.contract, but circular dependency
	{
		public List<PlWord> PlWords { get; }
		public void TranslationAding(PlWord plWord);
	}
}
