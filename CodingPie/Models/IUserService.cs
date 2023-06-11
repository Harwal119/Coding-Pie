using CodingPie.ResponseModels;

namespace CodingPie.Models
{
    public interface IUserService
    {
        LoginResponseModel Login(string email , string passWord);
    }
}