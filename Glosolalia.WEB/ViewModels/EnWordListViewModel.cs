using System.IO.Pipelines;
using Glosolalia.Business.Entities;

namespace Glosolalia.WEB.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<EnWord> EnWordSet { get; }

        public PieListViewModel(IEnumerable<EnWord> enWords)
        {
            EnWordSet = enWords;
        }
    }
}
