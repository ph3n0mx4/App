namespace CarSalesApp.Web.ViewModels.Administration.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
