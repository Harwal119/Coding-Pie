using System.ComponentModel.DataAnnotations;

namespace CodingPie.Models
{
    public class Pie
    {
       // [Required] 
        public int Id { get; set; }

        //[StringLength(10)]
        //[DataType(DataType.EmailAddress)]
        //[MinLength(5), MaxLength(10)]
        public string Name { get; set; }
        //[Display(Name="My Pie Description")]
        // [Compare("Name", ErrorMessage ="Name and description should match please!")]
        // [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
        // ErrorMessage = "Please enter a valid email address")]
        public string Description { get; set; }
        public bool IsAvailable { get; set; } 
        //[Range(50, 100, ErrorMessage ="Price has to be between #50 and #100")]
        public decimal Price { get; set; }

        public string PiePicturePath { get; set; }
       

        //public IServiceCollection Services { get; set; }
    }
}
