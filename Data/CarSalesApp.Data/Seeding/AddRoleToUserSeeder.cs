using System;
using System.Threading.Tasks;

namespace CarSalesApp.Data.Seeding
{
    public class AddRoleToUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //var role = await roleManager.FindByNameAsync(GlobalConstants.AdministratorRoleName);
            //var user = await userManager.FindByNameAsync(GlobalConstants.UserNameAdmin);

            //var exist = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            //if (exist)
            //{
            //    return;
            //}

            //await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            //{
            //    RoleId = role.Id,
            //    UserId = user.Id,
            //});

            //await dbContext.SaveChangesAsync();
        }
    }
}
