using AutoMapper;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CarAdDetailsViewModel : IMapFrom<Car> //, IHaveCustomMappings
    {
        public string MainImage { get; set; }//

        public int MakeId { get; set; }//

        public virtual Make Make { get; set; }//

        public int ModelId { get; set; }//

        public virtual Model Model { get; set; }//

        public int BodyId { get; set; }

        public virtual Body Body { get; set; }

        public decimal Price { get; set; }

        public int DriveId { get; set; }

        public virtual Drive Drive { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        [Display(Name = "First Registration")]
        public DateTime FirstRegistration { get; set; }//

        public virtual ICollection<ImageCarViewModel> Images { get; set; }

        public virtual ICollection<CarFeature> CarsFeatures { get; set; }

        public string Title => this.Make.Name + " " + this.Model.Name;

        public string PowerDescription => $"{this.Drive.Power} hp ({Math.Round(this.Drive.Power / 1.36)} kw)";

        public string FirstRegistrationMonthYear
            => this.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture);

        public string Doors => this.Body.Doors.ToString();

        public string Category => this.Body.Category.ToString();

        public string Seats => this.Body.Seats.ToString();

        public ICollection<FeatureViewModel> Safety { get; set; }

        public ICollection<FeatureViewModel> Entartaiment { get; set; }

        public ICollection<FeatureViewModel> Comfort { get; set; }

        public ICollection<FeatureViewModel> Extras { get; set; }


        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Car, CarAdDetailsViewModel>()
        //        .ForMember(
        //            x => x.CC,
        //            x => x.MapFrom(z => z.CC));
        //}
    }
}
