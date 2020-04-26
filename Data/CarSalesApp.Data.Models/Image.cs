using CarSalesApp.Data.Common.Models;

namespace CarSalesApp.Data.Models
{
    public class Image : BaseDeletableModel<int>
    {
        public string Url { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
