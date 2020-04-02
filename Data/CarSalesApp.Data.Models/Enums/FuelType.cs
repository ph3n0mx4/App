using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarSalesApp.Data.Models.Enums
{
    public enum FuelType
    {
        Petrol = 1,
        Diesel = 2,
        Electric = 3,
        LPG = 4,
        CNG = 5,
        [Description("Hybrid - Electric & Petrol")]
        HybridPetrol = 6,
        [Description("Hybrid - Electric & Diesel")]
        HybridDiesel = 7,
        Other = 8,
    }
}
