using DAWM_Project.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAWM_Project.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByCredentials(string username, string password)
        {
            var rezult = _dbContext.Users.ToList()
                .FirstOrDefault(e => e.Username == username && e.Password == password, null);

            return rezult;
        }

        public User GetByUsername(string username)
        {
            var rezult = _dbContext.Users.ToList()
                .FirstOrDefault(e => e.Username == username, null);

            return rezult;
        }

        public bool UsernameTaken(string username)
        {
            var rezult = _dbContext.Users.ToList()
                .FirstOrDefault(e => e.Username == username);

            return !(rezult == null);
        }
    }
}
