namespace CarSalesApp.Web.ViewModels.Cars
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class CarFeatureViewModel : IMapFrom<CarFeature>
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }
    }
}
