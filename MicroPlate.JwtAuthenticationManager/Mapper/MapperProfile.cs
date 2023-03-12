using AutoMapper;
using MicroPlate.JwtAuthenticationManager.Models;
using MicroPlate.JwtAuthenticationManager.Models.Login;
using MicroPlate.JwtAuthenticationManager.Models.Register;

namespace MicroPlate.JwtAuthenticationManager.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterRequestDto, UserAccount>();
            CreateMap<UserAccount, LoginResponseDto>();
        }
    }
}
