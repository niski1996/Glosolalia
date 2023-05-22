using Glosolalia.Common.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Glosolalia.WEB.ViewModel
{
	public class FlashCardsViewModel
	{
        public FlashCardsViewModel()
        {
            
        }
        public FlashCardsViewModel(IEnumerable<Translation> transList)
        {
            TransList = transList.ToList();
        }

        [BindProperty]
        public List<Translation>TransList { get; set; }
		public int ActualTargetIndex { get; set; }//Aktualny index na którym jest iteracja
        public bool AreFlashcardsLeft { get
			{

				return (ActualTargetIndex < (TransList.Count() - 1));
			}
		}
    }
}
