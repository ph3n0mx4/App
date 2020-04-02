namespace CarSalesApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;

    public class Drive : BaseDeletableModel<int>
    {
        public Drive()
        {
            this.Cars = new HashSet<Car>();
        }

        public FuelType Fuel { get; set; }

        public int CC { get; set; }

        public int Power { get; set; }

        public GearType GearType { get; set; }

        public int Gear { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
