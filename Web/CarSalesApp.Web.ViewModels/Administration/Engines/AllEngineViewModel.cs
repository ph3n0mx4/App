using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;

namespace CarSalesApp.Web.ViewModels.Administration.Engines
{
    public class AllEngineViewModel : IMapFrom<Drive>
    {
        public int Id { get; set; }

        public int MyProperty { get; set; }

        public FuelType Fuel { get; set; }

        public int Displacement { get; set; }

        public int Power { get; set; }

        public GearType GearType { get; set; }

        public int Gear { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public DateTime YearFrom { get; set; }

        public DateTime YearTo { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }

        public IEnumerable<DriveInputViewModel> Drives { get; set; }
    }
}
