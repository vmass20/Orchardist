using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages.GlobalPlants
{
    public class EditModel : PageModel
    {
        private readonly Orchardist.Data.OrchardDBContext _context;

        public EditModel(Orchardist.Data.OrchardDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GlobalPlantList GlobalPlantList { get; set; }
        public UserPlantList UserPlantList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GlobalPlantList = await _context.GlobalPlantList.SingleOrDefaultAsync(m => m.ID == id);

            if (GlobalPlantList == null)
            {
                return NotFound();
            }

            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GlobalPlantList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GlobalPlantListExists(GlobalPlantList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GlobalPlantListExists(int id)
        {
            return _context.GlobalPlantList.Any(e => e.ID == id);
        }
    }
}
