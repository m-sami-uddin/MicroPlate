namespace MicroPlate.JwtAuthenticationManager.Models.Register
{
    public class RegisterRequestDto
    {
        public string UserName { get; init; }
        public string Password { get; init; }
        public UserRole Role { get; init; }
    }
}
