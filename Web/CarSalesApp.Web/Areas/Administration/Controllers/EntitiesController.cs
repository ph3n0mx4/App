namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Data;
    using CarSalesApp.Web.ViewModels.Cars;
    using CarSalesApp.Web.ViewModels.Administration.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSalesApp.Services.Data.CarEntity;

    public class EntitiesController : AdministrationController
    {
        public IActionResult AddEntities()
        {
            return this.View();
        }
    }
}
