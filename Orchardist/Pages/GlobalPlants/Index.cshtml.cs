using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Orchardist.Data;

namespace Orchardist.Pages.GlobalPlants
{
  public class IndexModel : PageModel
  {
    private readonly Orchardist.Data.OrchardDBContext _context;

    public IndexModel(Orchardist.Data.OrchardDBContext context)
    {
      _context = context;
    }
    public string NameSort { get; set; }
    public string DateSort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }
    [BindProperty]
    public IList<GlobalPlantList> GlobalPlantList { get; set; }
    public IList<UserPlantList> UserPlantList { get; set; }
    //public string PlantVariety { get; set; }
    public SelectList PlantVariety;
    public bool checkedItem;
    public string FruitVariety { get; set; }
    public PaginatedList<GlobalPlantList> PaginatedList { get; set; }
    public async Task OnGetAsync(int? id, string searchString, string sortOrder, string currentFilter, string FruitVariety, int? pageIndex)
    {
      //Use LINQ to get list
      IQueryable<string> plantQuery = from m in _context.GlobalPlantList
                                      orderby m.FruitVariety
                                      select m.FruitVariety;

      //var plants = from p in _context.GlobalPlantList
      //             select p;
      //  DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      if (searchString != null)
      {
        pageIndex = 1;
      }
      PlantVariety = new SelectList(await plantQuery.Distinct().ToListAsync());
      //GlobalPlantList = await plants.ToListAsync();

      CurrentSort = sortOrder;
      NameSort = String.IsNullOrEmpty(sortOrder) ? "name" : "";
      // DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      if (searchString != null)
      {
        pageIndex = 1;
      }
      else
      {
        searchString = currentFilter;
      }

      CurrentFilter = searchString;

      IQueryable<GlobalPlantList> pagedList = from s in _context.GlobalPlantList
                                              select s;

      if (!String.IsNullOrEmpty(searchString))
      {

        pagedList = pagedList.Where(s => s.Name.Contains(searchString));
      }
      if (!String.IsNullOrEmpty(FruitVariety))
      {
        pagedList = pagedList.Where(x => x.FruitVariety == FruitVariety && x.Name.Contains(searchString));
      }
      if (!String.IsNullOrEmpty(searchString))
      {
        pagedList = pagedList.Where(s => s.Name.Contains(searchString));
      }


      int pageSize = 25;
      PaginatedList = await PaginatedList<GlobalPlantList>.CreateAsync(
        pagedList.AsNoTracking(), pageIndex ?? 1, pageSize);
      GlobalPlantList = PaginatedList.ToList();
    }
  }
  //public static class CommonUtilities
  //{
  //  //public static List<string> GetCheckboxSelectedValue(FormCollection frm, string checkboxname, string value)
  //  //{
  //  //  List<string> retls = new List<string>();
  //  //  var fileIds = frm[value].ToString().Split(',');
  //  //  var selectedIndices = frm[checkboxname].ToString().Replace("true,false", "true").Split(',').Select((item, index) =>
  //  //      new {
  //  //        item = item,
  //  //        index = index
  //  //      }).Where(row => row.item == "true")
  //  //      .Select(row => row.index).ToArray();
  //  //  if (selectedIndices.Count() > 0)
  //  //  {
  //  //    retls.AddRange(selectedIndices.Select(index => fileIds[index]));
  //  //  }
  //  //  return retls;
  //  //}
  //}
}

