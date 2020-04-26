using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System.Collections.Generic;

namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    public class AllMakesViewModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
