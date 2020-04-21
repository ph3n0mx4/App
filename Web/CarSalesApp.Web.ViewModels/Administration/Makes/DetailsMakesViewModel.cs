using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    public class DetailsMakesViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }
    }
}
