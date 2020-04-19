using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CarAdViewModel : IMapFrom<Car>
    {
        public string GeneralImg { get; set; }
        //hp to kW -> hp/1.36=kW
    }
}
