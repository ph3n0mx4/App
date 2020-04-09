﻿using CarSalesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CarSalesApp.Data.Models.Enums;
using Microsoft.AspNetCore.Http;

namespace CarSalesApp.Web.ViewModels.Cars
{
    public class CreateAdCarInputFormViewModel
    {
        public int MakeId { get; set; }

        public IEnumerable<MakeInputViewModel> Makes { get; set; }

        public int ModelId { get; set; }

        public IEnumerable<ModelInputViewModel> Models { get; set; }

        public int DriveId { get; set; }

        public IEnumerable<DriveInputViewModel> Drives { get; set; }

        public int BodyId { get; set; }

        public IEnumerable<BodyInputViewModel> Bodies { get; set; }

        public MonthsOfYear Month { get; set; }

        public int Year { get; set; }

        public ICollection<IFormFile> Files { get; set; }

        public int FuelId { get; set; }

        public ColorType Color { get; set; }
    }
}
