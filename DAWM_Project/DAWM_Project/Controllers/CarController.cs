using DAWM_Project.Services;
using DAWM_Project.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DAWM_Project.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : Controller
    {
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

            if(result == null)
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
    }
}
