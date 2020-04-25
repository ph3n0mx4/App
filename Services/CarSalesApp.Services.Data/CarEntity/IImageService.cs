using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public interface IImageService
    {
        Task<int> AddAsync(int carId, string url);
    }
}
