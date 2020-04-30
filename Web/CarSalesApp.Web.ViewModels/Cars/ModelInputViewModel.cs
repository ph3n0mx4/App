namespace CarSalesApp.Web.ViewModels.Cars
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class ModelInputViewModel : IMapFrom<Model>
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int ModelId { get; set; }

        public virtual Make Make { get; set; }
    }
}
