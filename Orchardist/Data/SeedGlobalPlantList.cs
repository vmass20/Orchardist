using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orchardist.Data
{
  public class SeedGlobalPlantList
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new OrchardDBContext(
          serviceProvider.GetRequiredService<DbContextOptions<OrchardDBContext>>()))
      {
        // Look for any movies.
        if (context.GlobalPlantList.Any())
        {
          return;   // DB has been seeded
        }
        //var globalPlantlist = new GlobalPlantList[]
        //{
        //    //new GlobalPlantList
        //    //{
        //    //  FruitVariety = "Apple",
        //    //  Name = "Cripps Pink 'Pink Lady'",
        //    //  Origin = "Australia",
        //    //  Parentage = "Golden Delicious x Lady Williams",
        //    //  Use = "Eating",
        //    //  YearDeveloped = "1970s",
        //    //  Comments = "Crisp, very sweet and slightly tart. Light red, pink and light yellow-green striped skin."

        //    //},

        //    //new GlobalPlantList
        //    //{
        //    //  FruitVariety = "Apple",
        //    //  Name = "HoneyCrisp",
        //    //  Origin = "Minnesota, US",
        //    //  Parentage = "Keepsake x MN1627",
        //    //},
        //    //new GlobalPlantList
        //    //{
        //    //  FruitVariety = "Peach",
        //    //  Name = "Red Haven",
        //    //  Origin = "Wisconsin, US",
        //    //  Parentage = "Red x White",
        //    //}
        //};
        //context.GlobalPlantList.AddRange(globalPlantlist);
        //context.SaveChanges();
      }
    }
  }
}
    