using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Entites
{
    public class AddMakeAndModelViewModel : IMapFrom<Make>
    {
        public int MakeId { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
