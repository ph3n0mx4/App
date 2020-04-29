namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using System.Collections.Generic;

    public class Feature : BaseDeletableModel<int>
    {
        public Feature()
        {
            this.CarsFeatures = new HashSet<CarFeature>();
        }

        public string Name { get; set; }

        public bool Checked { get; set; }

        public int TypeId { get; set; }

        public virtual FeatureType FeatureType { get; set; }

        public ICollection<CarFeature> CarsFeatures { get; set; }
    }
}
