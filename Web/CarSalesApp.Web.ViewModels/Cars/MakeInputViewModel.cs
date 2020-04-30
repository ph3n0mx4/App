namespace CarSalesApp.Web.ViewModels.Cars
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class MakeInputViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
