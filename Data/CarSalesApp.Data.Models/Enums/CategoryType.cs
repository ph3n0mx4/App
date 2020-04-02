using System.ComponentModel;

namespace CarSalesApp.Data.Models.Enums
{
    public enum CategoryType
    {
        [Description("Saloon Car")]
        Saloon = 1,
        [Description("Estate Car")]
        Estate = 2,
    }
}
