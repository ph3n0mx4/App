using System;
using System.Linq;
using System.Threading.Tasks;
using CarSalesApp.Common;
using CarSalesApp.Data.Models;

namespace CarSalesApp.Data.Seeding
{
    public class FeaturesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Features.Any())
            {
                return;
            }

            var safety = dbContext.FeatureTypes.FirstOrDefault(x => x.Name == GlobalConstants.FeatureTypeNameSafety);//safety
            var extras = dbContext.FeatureTypes.FirstOrDefault(x => x.Name == GlobalConstants.FeatureTypeNameExtras);//extras
            var comfort = dbContext.FeatureTypes.FirstOrDefault(x => x.Name == GlobalConstants.FeatureTypeNameComfort);//comfort
            var entertainment = dbContext.FeatureTypes.FirstOrDefault(x => x.Name == GlobalConstants.FeatureTypeNameEntertainment);//entertainment

            await dbContext.Features.AddRangeAsync(
                new Feature { Name = "Air conditioning", FeatureType = comfort },
                new Feature { Name = "Power windows", FeatureType = comfort },
                new Feature { Name = "Radio", FeatureType = entertainment },
                new Feature { Name = "ABS", FeatureType = safety });

            await dbContext.Features.AddRangeAsync(
                new Feature { Name = "Air suspension", FeatureType = comfort },
                new Feature { Name = "Armrest", FeatureType = comfort },
                new Feature { Name = "Automatic climate control", FeatureType = comfort },
                new Feature { Name = "Electrically adjustable seats", FeatureType = comfort },
                new Feature { Name = "Electrical side mirrors", FeatureType = comfort },
                new Feature { Name = "Electric tailgate", FeatureType = comfort },
                new Feature { Name = "Heated steering wheel", FeatureType = comfort },
                new Feature { Name = "Keyless central door lock", FeatureType = comfort },
                new Feature { Name = "Leather steering wheel", FeatureType = comfort },
                new Feature { Name = "Light sensor", FeatureType = comfort },
                new Feature { Name = "Lumbar support", FeatureType = comfort },
                new Feature { Name = "Massage seats", FeatureType = comfort },
                new Feature { Name = "Multi-function steering wheel", FeatureType = comfort },
                new Feature { Name = "Navigation system", FeatureType = comfort },
                new Feature { Name = "Panorama roof", FeatureType = comfort },
                new Feature { Name = "Park Distance Control", FeatureType = comfort },
                new Feature { Name = "Parking assist system camera", FeatureType = comfort },
                new Feature { Name = "Parking assist system sensors front", FeatureType = comfort },
                new Feature { Name = "Parking assist system sensors rear", FeatureType = comfort },
                new Feature { Name = "Rain sensor", FeatureType = comfort },
                new Feature { Name = "Seat heating", FeatureType = comfort },
                new Feature { Name = "Seat ventilation", FeatureType = comfort },
                new Feature { Name = "Sunroof", FeatureType = comfort },
                new Feature { Name = "Bluetooth", FeatureType = entertainment },
                new Feature { Name = "CD player", FeatureType = entertainment },
                new Feature { Name = "Digital radio", FeatureType = entertainment },
                new Feature { Name = "Hands-free equipment", FeatureType = entertainment },
                new Feature { Name = "On-board computer", FeatureType = entertainment },
                new Feature { Name = "Sound system", FeatureType = entertainment },
                new Feature { Name = "Television", FeatureType = entertainment },
                new Feature { Name = "USB", FeatureType = entertainment },
                new Feature { Name = "Alloy wheels", FeatureType = extras },
                new Feature { Name = "Shift paddles", FeatureType = extras },
                new Feature { Name = "Sport package", FeatureType = extras },
                new Feature { Name = "Sport seats", FeatureType = extras },
                new Feature { Name = "Sport suspension", FeatureType = extras },
                new Feature { Name = "Voice Control", FeatureType = extras },
                new Feature { Name = "Adaptive Cruise Control", FeatureType = safety },
                new Feature { Name = "Adaptive headlights", FeatureType = safety },
                new Feature { Name = "Alarm system", FeatureType = safety },
                new Feature { Name = "Blind spot monitor", FeatureType = safety },
                new Feature { Name = "Central door lock", FeatureType = safety },
                new Feature { Name = "Daytime running lights", FeatureType = safety },
                new Feature { Name = "Driver drowsiness detection", FeatureType = safety },
                new Feature { Name = "Driver-side airbag", FeatureType = safety },
                new Feature { Name = "Electronic stability control", FeatureType = safety },
                new Feature { Name = "Emergency brake assistant", FeatureType = safety },
                new Feature { Name = "Fog lights", FeatureType = safety },
                new Feature { Name = "Immobilizer", FeatureType = safety },
                new Feature { Name = "Isofix", FeatureType = safety },
                new Feature { Name = "Lane departure warning system", FeatureType = safety },
                new Feature { Name = "LED Daytime Running Lights", FeatureType = safety },
                new Feature { Name = "Night view assist", FeatureType = safety },
                new Feature { Name = "Power steering", FeatureType = safety },
                new Feature { Name = "Side airbag", FeatureType = safety },
                new Feature { Name = "Tire pressure monitoring system", FeatureType = safety },
                new Feature { Name = "Traction control", FeatureType = safety },
                new Feature { Name = "Traffic sign recognition", FeatureType = safety },
                new Feature { Name = "Xenon headlights", FeatureType = safety });
        }
    }
}