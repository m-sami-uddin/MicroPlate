using AutoMapper;
using MicroPlate.JwtAuthenticationManager.Data;
using MicroPlate.JwtAuthenticationManager.Models;
using MicroPlate.JwtAuthenticationManager.Models.Login;
using MicroPlate.JwtAuthenticationManager.Models.Register;

namespace MicroPlate.JwtAuthenticationManager.Repository
{
    public interface IUserRepository
    {
        public LoginResponseDto? Login(LoginRequestDto loginRequestDto);
        public bool Register(RegisterRequestDto registerRequestDto);
    }
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationContext _authenticationContext;
        private readonly IJwtTokenHandler _jwtTokenHandler;
        private readonly IMapper _mapper;

        public UserRepository(AuthenticationContext authenticationContext, IJwtTokenHandler jwtTokenHandler, IMapper mapper)
        {
            _authenticationContext = authenticationContext;
            _jwtTokenHandler = jwtTokenHandler;
            _mapper = mapper;
            var users = new List<UserAccount>
                {
                new UserAccount
                {
                    UserName="user",
                    Password="user",
                    Role=UserRole.User
                },
                    new UserAccount
                {
                    UserName="admin",
                    Password="admin",
                    Role=UserRole.Admin
                }
            };
            _authenticationContext.Users.AddRange(users);
            _authenticationContext.SaveChanges();
        }


        public LoginResponseDto? Login(LoginRequestDto loginRequestDto)
        {
            var user = _authenticationContext.Users.FirstOrDefault(x => x.UserName == loginRequestDto.UserName && x.Password == loginRequestDto.Password);
            if (user is null) return null;
            return _jwtTokenHandler.GenerateJwtToken(user);
        }

        public bool Register(RegisterRequestDto registerRequestDto)
        {
            var user = _mapper.Map<RegisterRequestDto, UserAccount>(registerRequestDto);
            _authenticationContext.Users.Add(user);
            return _authenticationContext.SaveChanges() > 0;
        }
    }
}
