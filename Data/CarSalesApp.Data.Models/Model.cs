namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using System.Collections.Generic;

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
