using Glosolalia.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Glosolalia.WEB.Razor.Pages.Sheets
{
    public class AddSheetModel : PageModel
    {
        [BindProperty]
        public Sheet NewSheet { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //Add to db
                var sheetName = NewSheet.Name;
                return RedirectToPage("AllSheets");
            }
            return Page();

        }
    }
}
