using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class MakeInputViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
