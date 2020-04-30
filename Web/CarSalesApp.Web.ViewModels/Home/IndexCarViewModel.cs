namespace CarSalesApp.Web.ViewModels.Home
{
    using System.Globalization;

    using AutoMapper;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class IndexCarViewModel : IMapFrom<Car>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; } //make+model

        public int DriveId { get; set; }

        public virtual Drive Drive { get; set; }

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
                opt => opt.MapFrom(x => x.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture)))
                .ForMember(
                m => m.Description,
                opt => opt.MapFrom(x => x.Description.Substring(0, 20) + "..."))
                .ForMember(
                    x => x.CreatedOn,
                    x => x.MapFrom(z => z.CreatedOn.ToString("HH:mm dd/MM/yyyy")))
                .ForMember(
                    x => x.ModifiedOn,
                    x => x.MapFrom(z => z.ModifiedOn.HasValue ? z.ModifiedOn.Value.ToString("HH:mm dd/MM/yyyy") : null))
                .ForMember(
                    x => x.Title,
                    x => x.MapFrom(z => z.Make.Name + " " + z.Model.Name));
        }
    }
}
