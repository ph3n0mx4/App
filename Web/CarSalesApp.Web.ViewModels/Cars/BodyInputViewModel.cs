using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using EnumsNET;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class BodyInputViewModel : IMapFrom<Body> //: IHaveCustomMappings
    {
        public string Title => this.Category.AsString(EnumFormat.Description) + ", " + this.Seats + " seats, " + this.Doors.AsString(EnumFormat.Description) + "doors";

        //public string Title => this.Category.ToString() + " " + this.Seats + "seats " + this.Doors.ToString() + "doors";
        public int Id { get; set; }

        public CategoryType Category { get; set; }

        public int Seats { get; set; }

        public DoorType Doors { get; set; }

    }
}
