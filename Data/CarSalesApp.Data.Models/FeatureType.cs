﻿using CarSalesApp.Data.Common.Models;
using System.Collections.Generic;

namespace CarSalesApp.Data.Models
{
    public class FeatureType : BaseDeletableModel<int>
    {
        public FeatureType()
        {
            this.Features = new HashSet<Feature>();
        }

        public string Name { get; set; }

        public virtual ICollection<Feature> Features { get; set; }
    }
}
