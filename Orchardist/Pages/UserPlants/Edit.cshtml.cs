using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages.UserPlants
{
    public class EditModel : PageModel
    {
        private readonly OrchardDBContext _context;

        public EditModel(OrchardDBContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Attach(UserPlantList).State = EntityState.Modified;
      _context.UserPlantList.Update(UserPlantList);
      try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPlantListExists(UserPlantList.ID))
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

        private bool UserPlantListExists(int id)
        {
            return _context.UserPlantList.Any(e => e.ID == id);
        }
    }
}
