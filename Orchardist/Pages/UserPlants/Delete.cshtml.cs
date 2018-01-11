using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages.UserPlants
{
    public class DeleteModel : PageModel
    {
        private readonly OrchardDBContext _context;

        public DeleteModel(OrchardDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserPlantList UserPlantList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPlantList = await _context.UserPlantList.SingleOrDefaultAsync(m => m.ID == id);

            if (UserPlantList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPlantList = await _context.UserPlantList.FindAsync(id);

            if (UserPlantList != null)
            {
                _context.UserPlantList.Remove(UserPlantList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
