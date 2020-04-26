using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
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
