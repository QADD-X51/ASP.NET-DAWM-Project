using DAWM_Project.Data;
using DAWM_Project.Data.Entity;
using DAWM_Project.Services.Dtos;

namespace DAWM_Project.Services
{
    public class UserService
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserAddDto RegisterUser(UserAddDto payload)
        {
            if (payload == null) return null;

            var newUser = new User
            {
                Username = payload.Username,
                Password = payload.Password,
                Email = payload.Email,
                Phone = payload.Phone
            };

            if (_unitOfWork.Users.UsernameTaken(newUser.Username))
                return null;

            _unitOfWork.Users.Insert(newUser);
            _unitOfWork.SaveChanges();

            return payload;
        }

        public User LoginUser(UserLoginDto payload)
        {
            if (payload == null) return null;

            var exists = _unitOfWork.Users.GetUserByCredentials(payload.Username, payload.Password);

            return exists;
        }

    }
}
