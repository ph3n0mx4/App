namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Cars;

    public class AddMakeAndModelViewModel : IMapFrom<Make>
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
