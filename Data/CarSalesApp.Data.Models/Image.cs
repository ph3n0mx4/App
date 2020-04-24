using CarSalesApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Data.Models
{
    public class Image : BaseDeletableModel<int>
    {
        public string Url { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
