namespace CarSalesApp.Services.Data.CarEntity
{
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task<int> AddAsync(int carId, string url);
    }
}
