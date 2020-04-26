using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class FeatureViewModel : IMapFrom<Feature>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual FeatureType Type { get; set; }
    }
}
