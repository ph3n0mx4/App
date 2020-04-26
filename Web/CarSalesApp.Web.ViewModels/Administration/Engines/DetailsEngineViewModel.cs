using AutoMapper;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Administration.Engines
{
    public class DetailsEngineViewModel : IMapFrom<Drive>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Model name")]
        public string ModelName { get; set; }

        [Required]
        [Display(Name = "Make name")]
        public string ModelMakeName { get; set; }

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
        public string GearType { get; set; }

        [Required]
        [Range(0, 11)]
        public int Gear { get; set; }

        [Required]
        [Display(Name = "Year from")]
        public int YearFrom { get; set; }

        [Required]
        [Display(Name = "Year to")]
        public int YearTo { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Drive, DetailsEngineViewModel>()
                .ForMember(
                    x => x.YearFrom,
                    x => x.MapFrom(z => z.YearFrom.Year))
                .ForMember(
                    x => x.YearTo,
                    x => x.MapFrom(z => z.YearTo.Year));
        }
    }
}
