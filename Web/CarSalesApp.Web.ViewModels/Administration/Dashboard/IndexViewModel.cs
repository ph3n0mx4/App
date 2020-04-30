namespace CarSalesApp.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsAdmin { get; set; }

        [Display(Name ="Users")]
        public IEnumerable<AllUsersViewModel> CurrentUsers { get; set; }
    }
}
