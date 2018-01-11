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
    public class DetailsModel : PageModel
    {
        private readonly OrchardDBContext _context;

        public DetailsModel(OrchardDBContext context)
        {
            _context = context;
        }

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
    }
}
