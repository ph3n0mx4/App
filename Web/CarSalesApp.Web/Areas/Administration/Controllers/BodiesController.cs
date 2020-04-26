using CarSalesApp.Services.Data;
using CarSalesApp.Web.ViewModels.Administration.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    public class BodiesController : AdministrationController
    {
        private readonly IBodyCarService bodyCarService;

        public BodiesController(IBodyCarService bodyCarService)
        {
            this.bodyCarService = bodyCarService;
        }

        public IActionResult AddBody()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBody(AddBodyViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.bodyCarService.AddAsync(input.Category, input.Seats, input.Doors);
            return this.Redirect("/");
        }
    }
}
