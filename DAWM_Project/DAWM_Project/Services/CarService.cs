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
    }
}
