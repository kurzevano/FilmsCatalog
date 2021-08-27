using AutoMapper;
using FilmsCatalog.Models;
using FilmsCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FilmForTableViewModel, Film>();

            CreateMap<Film, FilmForTableViewModel>()
                .ForMember(dest => dest.CanEdit, source => source.MapFrom<CanEditFilmResolver>());

            CreateMap<Film, FilmViewModel>();
            CreateMap<FilmViewModel, Film>()
                .ForMember(dest => dest.UserId, source => source.MapFrom<UserIdResolver>());
        }
    }
}
