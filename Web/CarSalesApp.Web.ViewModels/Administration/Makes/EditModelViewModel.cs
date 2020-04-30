namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    using System.ComponentModel.DataAnnotations;

    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;

    public class EditModelViewModel : IMapFrom<Model>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string MakeName { get; set; }
    }
}
