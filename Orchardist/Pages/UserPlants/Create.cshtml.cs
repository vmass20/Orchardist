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
  public class CreateModel : PageModel
  {
    private readonly OrchardDBContext _context;

    public CreateModel(OrchardDBContext context)
    {
      _context = context;
    }

    [BindProperty]
    public UserPlantList UserPlantList { get; set; }
    //[BindProperty]
    //public GlobalPlantList GlobalPlantList { get; set; }
    GlobalPlantList globalPlantList = new GlobalPlantList();

    UserPlantList userPlantList = new UserPlantList();
    public async Task<IActionResult> OnGetAsync(int? id)
    {

      if (id == null)
      {
        return NotFound();
      }

      globalPlantList = await _context.GlobalPlantList.SingleOrDefaultAsync(m => m.ID == id);

      userPlantList.FruitVariety = globalPlantList.FruitVariety;
      userPlantList.Name = globalPlantList.Name;
      userPlantList.Origin = globalPlantList.Origin;
      userPlantList.YearDeveloped = globalPlantList.YearDeveloped;
      userPlantList.Comments = globalPlantList.Comments;
      userPlantList.Use = globalPlantList.Use;
      UserPlantList = userPlantList;

      if (userPlantList == null)
      {
        return NotFound();
      }
      return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
      //    return Page();
      }

      _context.Attach(UserPlantList).State = EntityState.Added;
      _context.UserPlantList.Add(UserPlantList);
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