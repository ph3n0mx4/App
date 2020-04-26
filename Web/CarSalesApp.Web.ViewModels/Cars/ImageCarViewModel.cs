using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class ImageCarViewModel : IMapFrom<Image>
    {
        public string Url { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
