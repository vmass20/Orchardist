using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Orchardist.Data;

namespace Orchardist.Pages.GlobalPlants
{
    public class CreateModel : PageModel
    {
        private readonly Orchardist.Data.OrchardDBContext _context;

        public CreateModel(Orchardist.Data.OrchardDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GlobalPlantList GlobalPlantList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GlobalPlantList.Add(GlobalPlantList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}