using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Administration.Entities
{
    public class AddDriveViewModel : IMapFrom<Drive>
    {
        [Required]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Required]
        [Display(Name = "Displacement")]
        [Range(0, 9999)]
        public int Displacement { get; set; }

        [Required]
        [Display(Name = "Horsepower")]
        [Range(0, 2000)]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Gear Type")]
        public int GearType { get; set; }

        [Required]
        [Range(0, 11)]
        public int Gear { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Required]
        [Display(Name = "Year from")]
        public int YearFrom { get; set; }

        [Required]
        [Display(Name = "Year to")]
        public int YearTo { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
