namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Cars;

    using System.Collections.Generic;

    public class DetailsMakeViewModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ModelInputViewModel> Models { get; set; }
    }
}
