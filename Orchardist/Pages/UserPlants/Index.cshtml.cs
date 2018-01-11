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
    public class IndexModel : PageModel
    {
        private readonly OrchardDBContext _context;

        public IndexModel(OrchardDBContext context)
        {
            _context = context;
        }

        public IList<UserPlantList> UserPlantList { get;set; }

        public async Task OnGetAsync()
        {
            UserPlantList = await _context.UserPlantList.ToListAsync();
        }
    }
}
