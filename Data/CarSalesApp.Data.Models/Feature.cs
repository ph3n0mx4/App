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
            this.CarsFeatures = new HashSet<CarFeature>();
        }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public virtual FeatureType FeatureType { get; set; }

        public ICollection<CarFeature> CarsFeatures { get; set; }
    }
}
