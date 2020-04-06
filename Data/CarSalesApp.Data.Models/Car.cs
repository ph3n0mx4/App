namespace CarSalesApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CarSalesApp.Data.Common.Models;
    using CarSalesApp.Data.Models.Enums;

    public class Car : BaseDeletableModel<int>
    {
        public string Title { get; set; }

        public int? MakeId { get; set; }

        public virtual Make Make { get; set; }

        public int? ModelId { get; set; }

        public virtual Model Model { get; set; }

        public int? BodyId { get; set; }

        public virtual Body Body { get; set; }

        public decimal Price { get; set; }

        public int? DriveId { get; set; }

        public virtual Drive Drive { get; set; }

        public int? FeatureId { get; set; }

        public virtual Feature Feature { get; set; }

        public string GeneralImg { get; set; }

        public ColorType Color { get; set; }

        public DateTime FirstRegistration { get; set; }
    }
}
