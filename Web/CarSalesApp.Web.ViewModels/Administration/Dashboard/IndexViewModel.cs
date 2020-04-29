using CarSalesApp.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        [Display(Name ="Users")]
        public IEnumerable<AllUsersViewModel> CurrentUsers { get; set; }

    }
}
