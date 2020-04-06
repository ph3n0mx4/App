using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarSalesApp.Data;

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

        [HttpGet("getmodels")]
        public ActionResult<SelectList> GetModels(int makeId)
        {
            var models = new SelectList(this.db.Models.Where(c => c.MakeId == makeId).ToList(), "Id", "Name");

            return models;
        }
    }
}
