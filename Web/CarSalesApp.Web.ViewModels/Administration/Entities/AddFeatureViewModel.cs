using AutoMapper.Features;
using CarSalesApp.Data.Models;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarSalesApp.Web.ViewModels.Administration.Entities
{
    public class AddFeatureViewModel : IMapFrom<Feature>
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Feature { get; set; }

        public ICollection<FeatureTypeInputViewModel> Types { get; set; }
    }
}
