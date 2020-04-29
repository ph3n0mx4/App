using CarSalesApp.Web.ViewModels.Administration.Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IUserService
    {
        Task AddUserToRole(string username, string roleName);

        Task RemoveUserFromRole(string username, string roleName);

        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();

        Task<bool> IsAdmin (string username, string roleName);
    }
}
