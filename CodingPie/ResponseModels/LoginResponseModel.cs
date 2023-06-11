namespace CodingPie.ResponseModels
{
    public class LoginResponseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
