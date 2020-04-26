using CarSalesApp.Data.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public interface ICarService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task<int> AddAsync(int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, int fuelId, ColorType color, ICollection<int> inputFeatures, IEnumerable<string> inputImages, int mileage, decimal price, string inputMainImage, string description);
    }
}
