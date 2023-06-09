using Glosolalia.Common.Entities;
using Glosolalia.Data.Data_MockRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Glosolalia.WEB.Razor.Pages.Sheets
{
    public class AllSheetsModel : PageModel
    {
        public IEnumerable<Sheet> SheetList { get; set; }
        public void OnGet()
        {
            this.SheetList = new MockSheetRepository().GetAll();
        }
    }
}
