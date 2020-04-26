using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class FeatureTypeInputViewModel : IMapFrom<FeatureType>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
