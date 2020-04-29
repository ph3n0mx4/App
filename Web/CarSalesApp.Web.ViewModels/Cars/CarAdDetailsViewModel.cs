using AutoMapper;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CarAdDetailsViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public bool IsUserAuthorOrAdmin { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string MainImage { get; set; }//

        [Display(Name = "Make")]
        public int MakeId { get; set; }//

        public virtual Make Make { get; set; }//

        [Display(Name = "Model")]
        public int ModelId { get; set; }//

        public virtual Model Model { get; set; }//

        [Display(Name = "Body")]
        public int BodyId { get; set; }

        public virtual Body Body { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Drive")]
        public int DriveId { get; set; }

        public virtual Drive Drive { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        [Display(Name = "First Registration")]
        public DateTime FirstRegistration { get; set; }

        public string Title => this.Make.Name + " " + this.Model.Name;

        public string PowerDescription => $"{this.Drive.Power} hp ({Math.Round(this.Drive.Power / 1.36)} kw)";

        public string FirstRegistrationMonthYear
            => this.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture);

        public string Doors => this.Body.Doors.ToString();

        public string Category => this.Body.Category.ToString();

        public string Seats => this.Body.Seats.ToString();

        public string ModifiedOn { get; set; }

        public string CreatedOn { get; set; }

        public virtual ICollection<ImageCarViewModel> Images { get; set; }

        public ICollection<CarFeatureViewModel> CarsFeatures { get; set; }

        public ICollection<FeatureViewModel> Safety { get; set; }

        public ICollection<FeatureViewModel> Entartaiment { get; set; }

        public IEnumerable<FeatureViewModel> Comfort { get; set; }

        public ICollection<FeatureViewModel> Extras { get; set; }


        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, CarAdDetailsViewModel>()
                .ForMember(
                    x => x.CreatedOn,
                    x => x.MapFrom(z => z.CreatedOn.ToString("HH:mm dd/MM/yyyy")))
                .ForMember(
                    x => x.ModifiedOn,
                    x => x.MapFrom(z => z.ModifiedOn.HasValue ? z.ModifiedOn.Value.ToString("HH:mm dd/MM/yyyy") : null));
            //.ForMember(
            //    x => x.CarFeatures,
            //    x => x.MapFrom(z => z.CarsFeatures));
        }
    }
}
