using System.Security.Principal;

namespace CodingPie.ViewModels
{
    public class CreatePieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class LoginViewModel
    {
        
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
