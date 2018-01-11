using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages.GlobalPlants
{
    public class DetailsModel : PageModel
    {
        private readonly Orchardist.Data.OrchardDBContext _context;

        public DetailsModel(Orchardist.Data.OrchardDBContext context)
        {
            _context = context;
        }

        public GlobalPlantList GlobalPlantList { get; set; }

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
    }
}
