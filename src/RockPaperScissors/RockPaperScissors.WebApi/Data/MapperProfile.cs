using AutoMapper;
using RockPaperScissors.WebApi.Data.Models;
using RockPaperScissors.WebApi.Dto;

namespace RockPaperScissors.WebApi.Data;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Game, GameDto>();
    }
}