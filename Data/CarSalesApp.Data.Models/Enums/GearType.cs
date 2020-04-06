using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarSalesApp.Data.Models.Enums
{
    public enum GearType
    {
        Manual = 1,
        Automatic = 2,
        [Description("Semi-automatic")]
        SemiAutomatic = 3,
    }
}
