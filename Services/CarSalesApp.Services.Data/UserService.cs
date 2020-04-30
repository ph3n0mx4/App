namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository, UserManager<ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task AddUserToRole(string username, string roleName)
        {
            var user = await this.userRepository.All().SingleOrDefaultAsync(x => x.UserName == username);
            if (!(await this.IsAdmin(username, roleName)))
            {
                await this.userManager.AddToRoleAsync(user, roleName);
            }
        }

        public async Task RemoveUserFromRole(string username, string roleName)
        {
            var user = await this.userRepository.All().SingleOrDefaultAsync(x => x.UserName == username);
            if (await this.IsAdmin(username, roleName))
            {
                await this.userManager.RemoveFromRoleAsync(user, roleName);
            }
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            return await this.userRepository.All().To<AllUsersViewModel>().ToListAsync();
        }

        public async Task<bool> IsAdmin(string username, string roleName)
        {
            var user = await this.userRepository.All().SingleOrDefaultAsync(x => x.UserName == username);
            var gg = await this.userManager.IsInRoleAsync(user, roleName);
            return gg;
        }
    }
}
