namespace CarSalesApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;

    public class Feature : BaseDeletableModel<int>
    {
        public Feature()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Name { get; set; }

        public FeatureType Type { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
