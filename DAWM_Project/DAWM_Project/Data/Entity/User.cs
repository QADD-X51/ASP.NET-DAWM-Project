namespace DAWM_Project.Data.Entity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<Car> Cars { get; set; }
    }
}
