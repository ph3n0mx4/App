namespace CarSalesApp.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Data.Models.Enums;
    using CarSalesApp.Services.Mapping;

    public class EditCarAdViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

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
        public virtual ICollection<ImageCarViewModel> Images { get; set; }

        [Required]
        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Required]
        public ColorType Color { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        [Range(0, 999999)]
        public decimal Price { get; set; }

        [Display(Name = "Main Image")]
        public string MainImage { get; set; }

        [MinLength(10)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Mark at least one")]
        [Display(Name = "Equipment")]

        public ICollection<int> InputFeatures { get; set; }

        public ICollection<FeatureViewModel> CarFeatures { get; set; }

        public IEnumerable<FeatureViewModel> Safety { get; set; }

        public IEnumerable<FeatureViewModel> Entartaiment { get; set; }

        public IEnumerable<FeatureViewModel> Comfort { get; set; }

        public IEnumerable<FeatureViewModel> Extras { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, EditCarAdViewModel>()
                .ForMember(
                    x => x.FuelId,
                    x => x.MapFrom(z => (int)z.Drive.Fuel))
                .ForMember(
                    x => x.Month,
                    x => x.MapFrom(z => (MonthsOfYear)z.FirstRegistration.Month))
                .ForMember(
                    x => x.Year,
                    x => x.MapFrom(z => z.FirstRegistration.Year));
            ////.ForMember(
            //    x => x.CarFeatures,
            //    x => x.MapFrom(z => z.CarsFeatures));
        }
    }
}
