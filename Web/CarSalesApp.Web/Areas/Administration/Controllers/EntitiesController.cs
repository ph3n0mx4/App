namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class EntitiesController : AdministrationController
    {
        public IActionResult AddEntities()
        {
            return this.View();
        }
    }
}
