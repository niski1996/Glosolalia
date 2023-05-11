namespace Glosolalia.Common.Contracts
{
	public interface ISentenceSet<TWordSet>
	/* NOTE used to properly handeld many-to many and prevent for orphaned relations
	 * may be misleading, but this interface schoulb be implemented for ex. by 
* wordss, cause one word may be in many sentences*/
	{
		public void AddSentence(TWordSet sentence);
		public IReadOnlySet<TWordSet> GetAllSenences();
		public void RemoveSentence(TWordSet sentence);
	}


}
