namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Drive : BaseDeletableModel<int>
    {
        public Drive()
        {
            this.Cars = new HashSet<Car>();
        }

        public FuelType Fuel { get; set; }

        public int Displacement { get; set; }

        public int Power { get; set; }

        public GearType GearType { get; set; }

        public int Gear { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public DateTime YearFrom { get; set; }

        public DateTime YearTo { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
