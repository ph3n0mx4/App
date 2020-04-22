using AutoMapper;
using AutoMapper.Configuration;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using EnumsNET;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class DriveInputViewModel : IMapFrom<Drive>//, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Displacement { get; set; }

        public int Power { get; set; }

        public GearType GearType { get; set; }

        public int Gear { get; set; }

        public string Title => this.Displacement + "cc, " + this.Power + "hp, " + this.GearType.ToString() + " (" + this.Gear + ")";

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Drive, DriveInputViewModel>()
        //        .ForMember(
        //            x => x.CC,
        //            x => x.MapFrom(z => z.CC));
        //}
    }
}
