using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Administration.Dashboard;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
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
            await this.userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync()
        {
            return await this.userRepository.All().To<AllUsersViewModel>().ToListAsync();
        }
    }
}
