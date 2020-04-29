using CarSalesApp.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSalesApp.Web.ViewModels.Administration.Dashboard
{
    public class IndexViewModel
    {
        [Display(Name ="Users")]
        public IEnumerable<AllUsersViewModel> CurrentUsers { get; set; }

        public int SettingsCount { get; set; }
    }
}
