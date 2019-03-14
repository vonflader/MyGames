using AutoMapper;
using MyGames.Api.Entities;
using MyGames.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Game, GameDto>()
                .ForMember(dest => dest.GameAge,
                opt => opt.MapFrom(
                    src => src.ReleaseDate.GetCurrentAge())
                    );

            CreateMap<GameCreateDto, Game>();
        }
    }
}
