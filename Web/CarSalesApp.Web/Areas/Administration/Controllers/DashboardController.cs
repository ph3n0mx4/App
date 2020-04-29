namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    using CarSalesApp.Common;
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
            foreach (var user in currentUsers)
            {
                user.IsAdmin = await this.userService.IsAdmin(user.Username, GlobalConstants.AdministratorRoleName);
            }

            var viewModel = new IndexViewModel
            {
                CurrentUsers = currentUsers,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(IndexViewModel input)
        {
            var isAdmin = await this.userService.IsAdmin(input.Username, GlobalConstants.AdministratorRoleName);
            if (isAdmin)
            {
                await this.userService.RemoveUserFromRole(input.Username, GlobalConstants.AdministratorRoleName);
            }
            else
            {
                await this.userService.AddUserToRole(input.Username, GlobalConstants.AdministratorRoleName);
            }
            
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
