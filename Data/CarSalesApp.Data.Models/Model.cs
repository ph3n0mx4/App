namespace CarSalesApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CarSalesApp.Data.Common.Models;

    public class Model : BaseDeletableModel<int>
    {
        public Model()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Drive> Drives { get; set; }
    }
}
