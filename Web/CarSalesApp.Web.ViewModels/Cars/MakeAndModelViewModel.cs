using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class MakeAndModelViewModel
    {
        public string Name { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}
