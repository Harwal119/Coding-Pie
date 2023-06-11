using CodingPie.ResponseModels;

namespace CodingPie.Models
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService()
        {
            _repo = new UserRepository();
        }

        public LoginResponseModel Login(string email, string passWord)
        {
            var user = _repo.Login(email,passWord);

            if (user != null)
            {
                return new LoginResponseModel
                {
                    Email = user.Email,
                    Name = user.Name,
                    Message = "User Logged in successfully",
                    Status = true
                };

            }
            return new LoginResponseModel
            {
                Message = "Invalid email or password",
                Status = false
            };

           
        }
    }
}