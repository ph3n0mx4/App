using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarSalesApp.Data.Models.Enums;
using Microsoft.AspNetCore.Http;
using CarSalesApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CreateAdCarInputFormViewModel : IMapFrom<Car> //, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Make")]
        public int MakeId { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }

        [Required]
        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public IEnumerable<ModelInputViewModel> Models { get; set; }

        [Required]
        [Display(Name = "Drive")]
        public int DriveId { get; set; }

        public IEnumerable<DriveInputViewModel> Drives { get; set; }

        [Required]
        [Display(Name = "Body")]
        public int BodyId { get; set; }
        
        public IEnumerable<BodyInputViewModel> Bodies { get; set; }

        [Required]
        public MonthsOfYear Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Display(Name = "Other Images")]
        public IEnumerable<IFormFile> Images { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Required]
        public ColorType Color { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        [Range(0, 2000)]
        public decimal Price { get; set; }

        [Display(Name = "Main Image")]
        public IFormFile MainImage { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Mark at least one")]
        [Display(Name = "Equipment")]
        public ICollection<int> InputFeatures { get; set; }

        public IEnumerable<FeatureViewModel> Safety { get; set; }

        public IEnumerable<FeatureViewModel> Entartaiment { get; set; }

        public IEnumerable<FeatureViewModel> Comfort { get; set; }

        public IEnumerable<FeatureViewModel> Extras { get; set; }


    }
}
