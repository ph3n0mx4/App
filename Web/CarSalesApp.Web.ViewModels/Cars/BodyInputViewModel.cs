using AutoMapper;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class BodyInputViewModel : IMapFrom<Body> //: IHaveCustomMappings
    {
        public string Title => this.Category.ToString() + " " + this.Seats + "seats " + this.Doors.ToString() + "doors";
        public int Id { get; set; }

        public string Category { get; set; }

        public int Seats { get; set; }

        public string Doors { get; set; }

    }
}
