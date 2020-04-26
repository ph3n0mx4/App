namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using System.Collections.Generic;

    public class Make : BaseDeletableModel<int>
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
