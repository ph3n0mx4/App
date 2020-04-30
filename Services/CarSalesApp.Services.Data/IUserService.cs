namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CarSalesApp.Web.ViewModels.Administration.Dashboard;

    public interface IUserService
    {
        Task AddUserToRole(string username, string roleName);

        Task RemoveUserFromRole(string username, string roleName);

        Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();

        Task<bool> IsAdmin(string username, string roleName);
    }
}
