using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
