namespace CarSalesApp.Web.ViewModels.Cars
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class FeatureViewModel : IMapFrom<Feature>
    {
        public int Id { get; set; }

        public bool Checked { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual FeatureType Type { get; set; }
    }
}
