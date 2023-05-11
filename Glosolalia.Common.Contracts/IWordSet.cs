namespace Glosolalia.Common.Contracts
{
	public interface IWordSet<TSentenceSet>
	/* NOTE NOTE used to properly handeld many-to many and prevent for orphaned relations 
	 * may be misleading, but this interface schoulb be implemented for ex. by 
* sentences, cause one Sentences may be in many words*/
	{
		public void AddWord(TSentenceSet word);
		public IReadOnlySet<TSentenceSet> GetAllWords();
		public void RemoveWord(TSentenceSet word);
	}

}
