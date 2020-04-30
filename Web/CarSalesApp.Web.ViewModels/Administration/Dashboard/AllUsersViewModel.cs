namespace CarSalesApp.Web.ViewModels.Administration.Dashboard
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using System.Collections.Generic;

    public class AllUsersViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
