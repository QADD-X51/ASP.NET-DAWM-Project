using DAWM_Project.Data.Repositories;

namespace DAWM_Project.Data
{
    public class UnitOfWork
    {

        private readonly AppDbContext _dbContext;

        public UserRepository Users { get; set; }
        public CarRepository Cars { get; set; }

        public UnitOfWork
        (
            AppDbContext dbContext,
            UserRepository userRepository,
            CarRepository carRepository
        )
        {
            _dbContext = dbContext;
            Users = userRepository;
            Cars = carRepository;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
