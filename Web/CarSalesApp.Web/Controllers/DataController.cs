using CarSalesApp.Data;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace CarSalesApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public DataController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("getModels")]
        public ActionResult<SelectList> GetModels(int makeId)
        {
            var models = new SelectList(this.db.Models.Where(c => c.MakeId == makeId).OrderBy(m => m.Name).ToList(), "Id", "Name");

            return models;
        }

        [HttpGet("getDrives")]
        public ActionResult<SelectList> GetDrives(int fuelId, int modelId)
        {
            var currentFuel = (FuelType)Enum.ToObject(typeof(FuelType), fuelId);
            var drives = new SelectList(this.db.Drives.Where(c => c.Fuel == currentFuel && c.ModelId == modelId).To<DriveInputViewModel>().ToList(), "Id", "Title");

            return drives;
        }
    }
}
