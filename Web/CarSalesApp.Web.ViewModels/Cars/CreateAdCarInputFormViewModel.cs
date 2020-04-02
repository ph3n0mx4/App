using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CreateAdCarInputFormViewModel
    {
        public IEnumerable<MakeAndModelViewModel> falseMakes { get; set; }
        public string Name { get; set; }

        public int MakeId { get; set; }

        public IEnumerable<Make> Makes { get; set; }

        public int ModelId { get; set; }

        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<Drive> Drives { get; set; }

        public IEnumerable<BodyInputViewModel> Bodies { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Body { get; set; }
    }
}
