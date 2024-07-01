using CarManagementApp.Core.Services;
using CarManagementApp.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementApp.Api.Controllers;

//public class CarsController(ICarService carService) : ApiBaseController
public class CarsController(ICarService carService) : ApiBaseController

{
    private readonly ICarService carService = carService;


    /// <summary>
    /// Get paged of cars
    /// </summary>
    /// <returns></returns>
    [HttpGet("get-list-cars")]
    public async Task<IActionResult> GetCarList([FromQuery] PagingRequest filter)
    {
        var list = await carService.GetCarListAsync(filter);
        return Ok(list);
    }

    /// <summary>
    /// Get paged of cars
    /// </summary>
    /// <returns></returns>
    [HttpGet("generate-random-list-cars")]
    public async Task<IActionResult> GenerateRandomCarList(int count)
    {
        var result = await carService.GenerateRandomCarAsync(count);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Code.ToString());
    }
}



//using CarManagementApp.Core.Services;
//using CarManagementApp.Domain.Common;
//using Microsoft.AspNetCore.Mvc;

//namespace CarManagementApp.Api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class CarsController : ApiBaseController
//    {
//        private readonly ICarService carService;

//        public CarsController(ICarService carService) : base()
//        {
//            this.carService = carService;
//        }

//        /// <summary>
//        /// Get paged list of cars
//        /// </summary>
//        /// <param name="filter">Paging filter</param>
//        /// <returns>List of cars</returns>
//        [HttpGet("get-list-cars")]
//        public async Task<IActionResult> GetCarList([FromQuery] PagingRequest filter)
//        {
//            var list = await carService.GetCarListAsync(filter);
//            return Ok(list);
//        }

//        /// <summary>
//        /// Generate a random list of cars
//        /// </summary>
//        /// <param name="count">Number of cars to generate</param>
//        /// <returns>List of randomly generated cars</returns>
//        [HttpGet("generate-random-list-cars")]
//        public async Task<IActionResult> GenerateRandomCarList(int count)
//        {
//            var result = await carService.GenerateRandomCarAsync(count);
//            if (result.Success)
//            {
//                return Ok(result.Data);
//            }
//            return BadRequest(result.Code.ToString());
//        }
//    }
//}
