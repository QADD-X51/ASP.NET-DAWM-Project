using DAWM_Project.Data;
using DAWM_Project.Data.Entity;
using DAWM_Project.Services.Dtos;

namespace DAWM_Project.Services
{
    public class CarService
    {
        private readonly UnitOfWork _unitOfWork;

        public CarService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CarAddDto AddCar(CarAddDto car, int userId)
        {
            var newCar = new Car {
                Maker = car.Maker,
                ModelName = car.ModelName,
                ModelYear = car.ModelYear,
                Weight = car.Weight,
                EngineCapacity = car.EngineCapacity,
                EngineType = car.EngineType,
                Power = car.Power,
                Drivetrain = car.Drivetrain,
                Mileage = car.Mileage,
                Price = car.Price,
                Negotiable = car.Negotiable,
                Description = car.Description,
                Sold = false,
                UserId = userId
            };

            _unitOfWork.Cars.Insert(newCar);
            _unitOfWork.SaveChanges();

            return car;
        }

        public Car SellCar(int carId)
        {
            Car target;
            try
            {
                target = _unitOfWork.Cars.GetById(carId);
            }
            catch
            {
                return null;
            }

            target.Sold = true;

            _unitOfWork.Cars.Update(target);
            _unitOfWork.SaveChanges();

            return target;
        }

        public List<Car> GetUserCars(int userId)
        {
            return _unitOfWork.Cars.GetAllOfUser(userId);
        }

        public List<Car> GetAll()
        {
            return _unitOfWork.Cars.GetAll();
        }

        public List<Car> GetFilteredCars(string? maker= "", string? modelName = "",
            int? minYear = 0, int? maxYear = 10000, int? minPower = 0, int? maxPower = 2000,
            int? minEngineCapacity = 0, int? maxEngineCapacity = 30000,
            int? minMileage = 0, int? maxMileage = 1000000,
            float? minPrice = 0, float? maxPrice = 10000000,
            bool? negociable = null)
        {
            var rez = GetAll();

            var rezFiltered = new List<Car>();

            foreach (var car in rez)
            {
                if (!car.Sold)
                {
                    if ((car.Maker == maker || maker == "") && (car.ModelName == modelName || modelName == "" || car.ModelName.ToLower().Contains(modelName.ToLower())) && (car.ModelYear >= minYear && car.ModelYear <= maxYear)
            && (car.Power >= minPower && car.Power <= maxPower) && (car.EngineCapacity >= minEngineCapacity && car.EngineCapacity <= maxEngineCapacity)
            && (car.Mileage >= minMileage && car.Mileage <= maxMileage) && (car.Price >= minPrice && car.Price <= maxPrice) && (car.Negotiable == negociable || negociable == null))
                    {
                        rezFiltered.Add(car);
                    }
                }
            }
            return rezFiltered;
        }
    }
}
