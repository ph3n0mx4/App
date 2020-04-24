using AutoMapper;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System.Globalization;

namespace CarSalesApp.Web.ViewModels.Home
{
    public class IndexCarViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; } //make+model

        public string GeneralImg { get; set; }

        public string Power { get; set; }

        public string Description { get; set; }

        public string CreatedOn { get; set; }

        public string ModifiedOn { get; set; }

        public string MainImage { get; set; }

        public string FirstRegistration { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Car, IndexCarViewModel>()
                .ForMember(
                m => m.FirstRegistration,
                opt => opt.MapFrom(x => x.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture)));
        }
    }
}