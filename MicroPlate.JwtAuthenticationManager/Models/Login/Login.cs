namespace MicroPlate.JwtAuthenticationManager.Models.Login
{
    public record LoginRequestDto
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
    public record LoginResponseDto
    {
        public string UserName { get; init; }
        public int ExpiresIn { get; init; }
        public string AccessToken { get; init; }
    }
}
