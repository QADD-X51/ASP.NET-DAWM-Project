using DAWM_Project.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAWM_Project.Data.Repositories
{
    public class CarRepository : RepositoryBase<Car>
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Car> _dbSet;

        public CarRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Car>();
        }

        public List<Car> GetAllOfUser(int userId)
        {
            return _dbSet.Where(c => c.UserId == userId).ToList();
        }
    }
}
