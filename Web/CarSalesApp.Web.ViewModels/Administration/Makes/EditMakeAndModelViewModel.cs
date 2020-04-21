using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Administration.Makes
{
    public class EditMakeAndModelViewModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public virtual Make Make { get; set; }
    }
}
