using System;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Administration.Entities
{
    public class AddBodyViewModel
    {
        [Required]
        public int Category { get; set; }

        [Required]
        [Range(2, 9)]
        public int Seats { get; set; }

        [Required]
        public int Doors { get; set; }
    }
}
