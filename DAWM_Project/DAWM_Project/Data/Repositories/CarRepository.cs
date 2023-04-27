using DAWM_Project.Data.Entity;

namespace DAWM_Project.Data.Repositories
{
    public class CarRepository : RepositoryBase<Car>
    {
        private readonly AppDbContext _dbContext;

        public CarRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
