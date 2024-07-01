using CarManagementApp.Domain.Common;
using CarManagementApp.Domain.Models;

namespace CarManagementApp.Core.Services
{
    public interface ICarService
    {
        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="car"><see cref="CarModel"/> </param>
        /// <returns></returns>
        Task<Result<CarModel>> AddCarAsync(CarModel car);

        /// <summary>
        /// Get paged of cars
        /// </summary>
        /// <param name="filter"><see cref="PagingRequest"/> </param>
        /// <returns></returns>
        Task<Paging<CarModel>> GetCarListAsync(PagingRequest? filter = null);

        /// <summary>
        /// Get car by id
        /// </summary>
        /// <param name="id"> Car's id </param>
        /// <returns></returns>
        Task<CarModel> GetCarByIdAsync(int id);

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="car"><see cref="CarModel"/> </param>
        /// <returns></returns>
        Task<Result<CarModel>> UpdateCarAsync(int id, CarModel car);

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="id"> Car's id </param>
        /// <returns></returns>
        Task<Result<bool>> DeleteCarAsync(int id);

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="count"> Car's count </param>
        /// <returns></returns>
        Task<Result<List<CarModel>>> GenerateRandomCarAsync(int count);
    }
}
