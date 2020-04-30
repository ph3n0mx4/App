using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Data.Models.Enums
{
    public enum CategoryType
    {
        [Display(Name = "Saloon/Sedan Car")]
        [Description("Saloon/Sedan Car")]
        Saloon = 1,
        [Description("Estate/Wagon Car")]
        [Display(Name = "Estate/Wagon Car")]
        Estate = 2,
        [Display(Name = "Hatchback Car")]
        [Description("Hatchback Car")]
        Hatchback = 3,
        [Display(Name = "Coupe Car")]
        [Description("Coupe Car")]
        Coupe = 4,
    }
}
