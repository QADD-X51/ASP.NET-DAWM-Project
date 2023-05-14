using DAWM_Project.Data;
using DAWM_Project.Data.Entity;
using DAWM_Project.Services.Dtos;

namespace DAWM_Project.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private AuthorizationService authService { get; set; }
        public UserService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            _unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public void RegisterUser(UserAddDto payload)
        {
            if (payload == null) return;

            var hashedPassword = authService.HashPassword(payload.Password);

            var newUser = new User
            {
                Username = payload.Username,
                Password = hashedPassword,
                Email = payload.Email,
                Phone = payload.Phone
            };

            _unitOfWork.Users.Insert(newUser);
            _unitOfWork.SaveChanges();
        }

        public string Validate(UserLoginDto payload)
        {
            var user = _unitOfWork.Users.GetByUsername(payload.Username);

            var passwordFine = authService.VerifyHashedPassword(user.Password, payload.Password);

            if (passwordFine)
            {
                var role = GetRole(user);

                return authService.GetToken(user, role);
            }
            else
            {
                return null;
            }

        }

        public string GetRole(User user)
        {

            if (user.Email == "andreidei0406@admin.ro")
            {
                return "Admin";
            }
            else
            {
                return "User";
            }
        }

    }
}
