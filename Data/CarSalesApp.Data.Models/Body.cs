namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;
    using System.Collections.Generic;

    public class Body : BaseDeletableModel<int>
    {
        public Body()
        {
            this.Cars = new HashSet<Car>();
        }

        public CategoryType Category { get; set; }

        public int Seats { get; set; }

        public DoorType Doors { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
