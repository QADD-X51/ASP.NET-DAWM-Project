using DAWM_Project.Data.Entity;
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

        [HttpGet("/getFilteredCars")]
        public IActionResult GetFilteredCars(string maker="all", string modelName="all", 
            int minYear=0, int maxYear=10000, int minPower=0, int maxPower=2000,
            int minEngineCapacity=0, int maxEngineCapacity=6000,
            int minMileage=0, int maxMileage=1000000,
            float minPrice=0, float maxPrice=10000000,
            bool? negociable = null)
        {
            var rez = _carService.GetAll();

            var rezFiltered = new List<Car>();

            foreach(var car in rez)
            {
                if((car.Maker == maker || maker =="all" || maker =="") && (car.ModelName == modelName || modelName == "all" || modelName == "" || car.ModelName.ToLower().Contains(modelName.ToLower())) && (car.ModelYear >= minYear && car.ModelYear <= maxYear) 
                    && (car.Power >= minPower && car.Power <= maxPower) && (car.EngineCapacity >= minEngineCapacity && car.EngineCapacity <= maxEngineCapacity)
                    && (car.Mileage >= minMileage && car.Mileage <= maxMileage) && (car.Price >= minPrice && car.Price <= maxPrice) && (car.Negotiable == negociable || negociable == null))
                {
                    rezFiltered.Add(car);
                }
            } 

            return Ok(rezFiltered);
        }
    }
}
