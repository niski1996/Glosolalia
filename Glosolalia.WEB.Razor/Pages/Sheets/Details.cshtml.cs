using Glosolalia.Common.Entities;
using Glosolalia.Data.Data_MockRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Glosolalia.WEB.Razor.Pages.Sheets
{
    public class DetailsModel : PageModel
    {
        public Sheet ActualSheet;
        public void OnGet()
        {
            ActualSheet = new MockSheetRepository().Get(int.Parse(RouteData.Values["id"].ToString()));//HACH mo¿na ³adniej ale mi sie nie chce

		}
    }
}
