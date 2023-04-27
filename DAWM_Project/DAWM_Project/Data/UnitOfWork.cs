namespace DAWM_Project.Data
{
    public class UnitOfWork
    {

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext
            //StudentsRepository studentsRepository
        )
        {
            _dbContext = dbContext;
            //Students = studentsRepository;
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
