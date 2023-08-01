using AutoMapper;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;
using RockPaperScissors.WebApi.Mediatr.Commands.JoinUserToGameRequest;

namespace RockPaperScissors.WebApi.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    { CreateMap<Turn, TurnDto>();

        CreateMap<UserInGame, JoinUserToGameResponse>();
    }
}