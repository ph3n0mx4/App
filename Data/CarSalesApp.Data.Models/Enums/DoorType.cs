using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarSalesApp.Data.Models.Enums
{
    public enum DoorType
    {
        [Description("2/3")]
        TwoThree = 1,
        [Description("4/5")]
        FourFive = 2,
        [Description("6/7")]
        SixSeven = 3,
    }
}
