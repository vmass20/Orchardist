using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages
{
    public class IndexModel : PageModel
  {
    private readonly Orchardist.Data.OrchardDBContext _context;

    public IndexModel(Orchardist.Data.OrchardDBContext context)
    {
      _context = context;
    }
    [BindProperty]
    public IList<GlobalPlantList> GlobalPlantList { get; set; }
    public IList<UserPlantList> UserPlantList { get; set; }
    public async Task OnGetAsync()
    {
      GlobalPlantList = await _context.GlobalPlantList.ToListAsync();
      UserPlantList = await _context.UserPlantList.ToListAsync();
    }

  }
}
