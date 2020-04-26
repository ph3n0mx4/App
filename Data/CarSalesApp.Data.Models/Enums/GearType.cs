using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Data.Models.Enums
{
    public enum GearType
    {
        [Display(Name = "Manual")]
        Manual = 1,
        [Display(Name = "Automatic")]
        Automatic = 2,
        [Display(Name = "Semi-automatic")]
        [Description("Semi-automatic")]
        SemiAutomatic = 3,
    }
}
