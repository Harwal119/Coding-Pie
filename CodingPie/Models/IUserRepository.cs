namespace CodingPie.Models
{
    public interface IUserRepository
    {
        User Login(string email, string passWord);

    }
}