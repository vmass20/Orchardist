using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orchardist.Data
{
    public class UserPlantList 
    {
    public  int ID { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public  string Name { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public  string FruitVariety { get; set; }

    [StringLength(200)]
    [Required]
    public  string Origin { get; set; }

    public string Use { get; set; }

    [Display(Name = "Year Developed")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public string YearDeveloped { get; set; }

    public string Comments { get; set; }

    [Display(Name = "Date Planted")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DatePlanted { get; set; }

    [Display(Name = "Tree Count")]
    public int TreeCount { get; set; }

    // [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    [Required]
    [StringLength(200)]
    public string Parentage { get; set; }
  }
}
