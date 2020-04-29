namespace CarSalesApp.Data.Models
{
    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Images = new HashSet<Image>();
            this.CarsFeatures = new HashSet<CarFeature>();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int ModelId { get; set; }

        public virtual Model Model { get; set; }

        public int BodyId { get; set; }

        public virtual Body Body { get; set; }

        public decimal Price { get; set; }

        public int DriveId { get; set; }

        public virtual Drive Drive { get; set; }

        public string MainImage { get; set; }

        public int Mileage { get; set; }

        public ColorType Color { get; set; }

        public string Description { get; set; }

        public DateTime FirstRegistration { get; set; }

        public virtual ICollection<CarFeature> CarsFeatures { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
