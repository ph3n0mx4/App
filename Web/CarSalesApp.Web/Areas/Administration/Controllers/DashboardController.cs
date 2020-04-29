namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    using CarSalesApp.Services.Data;
    using CarSalesApp.Services.Data.CarEntity;
    using CarSalesApp.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public DashboardController(ISettingsService settingsService, IUserService userService)
        {
            this.settingsService = settingsService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()    
        {
            var currentUsers = await this.userService.GetAllUsersAsync();
            var viewModel = new IndexViewModel
            {
                SettingsCount = this.settingsService.GetCount(),
                CurrentUsers = currentUsers,
            };
            return this.View(viewModel);
        }
    }
}
