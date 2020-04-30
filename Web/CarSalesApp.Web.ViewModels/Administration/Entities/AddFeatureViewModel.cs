namespace CarSalesApp.Web.ViewModels.Administration.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Cars;

    public class AddFeatureViewModel : IMapFrom<Feature>
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Feature { get; set; }

        public ICollection<FeatureTypeInputViewModel> Types { get; set; }
    }
}
