using CarSalesApp.Data.Common.Models;
using System;

namespace CarSalesApp.Data.Models
{
    public class CarFeature : IAuditInfo, IDeletableEntity
    {
        public int CarId { get; set; }

        public Car Car { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
