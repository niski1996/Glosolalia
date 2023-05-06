using System.IO.Pipelines;
using Glosolalia.Business.Entities;

namespace Glosolalia.WEB.ViewModels
{
    public class EnWordListViewModel
    {
        public IEnumerable<EnWord> EnWordSet { get; }

        public EnWordListViewModel(IEnumerable<EnWord> enWords)
        {
            EnWordSet = enWords;
        }
    }
}
