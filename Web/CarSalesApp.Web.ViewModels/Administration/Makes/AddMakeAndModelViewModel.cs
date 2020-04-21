using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    public class AddMakeAndModelViewModel : IMapFrom<Make>
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
