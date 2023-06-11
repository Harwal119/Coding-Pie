namespace CodingPie.Models
{
    public class UserRepository : IUserRepository
    {
         static List<User> Users = new List<User>{
            new User{Name = "Ade" , Email = "ade@email.com" , PassWord = "Ade"},
            new User{Name = "Bola" , Email = "bola@email.com" , PassWord = "Bola"},
        };
        public User Login(string email, string passWord)
        {
            return Users.SingleOrDefault(a => a.Email == email && a.PassWord == passWord);
        }
    }
}