namespace CarSalesApp.Web.ViewModels.Administration.Engines
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class EditEngineViewModel : IMapFrom<Drive>
    {
        public int Id { get; set; }

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
        [Display(Name = "Gears")]
        public int Gear { get; set; }

        [Required]
        [Display(Name = "Year from")]
        public int YearFrom { get; set; }

        [Required]
        [Display(Name = "Year to")]
        public int YearTo { get; set; }
    }
}
