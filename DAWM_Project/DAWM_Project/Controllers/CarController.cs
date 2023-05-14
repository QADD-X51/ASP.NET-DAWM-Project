using DAWM_Project.Data.Entity;
using DAWM_Project.Services;
using DAWM_Project.Services.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Net.Http.Headers;
using Azure.Core;

namespace DAWM_Project.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
        private readonly string _securityKey;
        private CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpPost("/add")]
        public IActionResult Add(CarAddDto payload, int userId)
        {
            var result = _carService.AddCar(payload, userId);

            return Ok(result);
        }

        [HttpPut("/sell")]
        public IActionResult Sell(int carId)
        {
            var result = _carService.SellCar(carId);

            if (result == null)
            {
                return BadRequest("Car does not exist");
            }

            return Ok(result);
        }



        [HttpGet("/getAll")]
        public IActionResult GetAll()
        {
            var rez = _carService.GetAll();

            return Ok(rez);
        }
        [HttpGet("/getAllOfUser")]
        public IActionResult GetAllOfUser(int userId)
        {
            var rez = _carService.GetUserCars(userId);

            return Ok(rez);
        }
        [HttpGet("/getFilteredCars")]
        public IActionResult GetFilteredCars(string? maker = "all", string? modelName = "all",
            int? minYear = 0, int? maxYear = 10000, int? minPower = 0, int? maxPower = 2000,
            int? minEngineCapacity = 0, int? maxEngineCapacity = 30000,
            int? minMileage = 0, int? maxMileage = 1000000,
            float? minPrice = 0, float? maxPrice = 10000000,
            bool? negociable = null)
        {
            var rez = _carService.GetFilteredCars(maker, modelName, minYear, maxYear, minPower, maxPower, minEngineCapacity,
                maxEngineCapacity, minMileage, maxMileage, minPrice, maxPrice, negociable);

            return Ok(rez);
        }

    }
}

