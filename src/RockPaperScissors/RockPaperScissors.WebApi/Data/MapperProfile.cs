using AutoMapper;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Game, GameDto>()
            .ForMember(d => d.Users, opt => opt.MapFrom(s => s.UsersInGame.Select(u => u.UserName).ToArray()));

        CreateMap<Turn, TurnDto>();
    }
}