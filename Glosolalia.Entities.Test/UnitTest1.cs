using Glosolalia.Business.Entities;
using Glosolalia.Business.Entities.Sentences;
using Glosolalia.Business.Entities.Words;

namespace Glosolalia.Entities.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void ManyToManyRelationManualAddingTest()
		{
			var plWord = new PlWord("loki");
			var plSentence = new PlSentence() { Value = "sfsfs fsfsdf fsdsf" };
			plWord.AddSentnence(plSentence);
			Assert.IsTrue(plWord.GetAllSentences().Count == 1);
			Assert.IsTrue(plSentence.GetAllWords().Count == 1);


		}
	}
}