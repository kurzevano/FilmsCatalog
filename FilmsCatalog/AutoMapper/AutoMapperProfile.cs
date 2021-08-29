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

            CreateMap<Film, FilmViewModel>()
                .ForMember(dest => dest.ImageFileName, source => source.MapFrom(film => film.PosterFileName));

            CreateMap<FilmViewModel, Film>()
                .ForMember(dest => dest.PosterFileName, source => source.MapFrom(film => film.ImageFileName)); ;
        }
    }
}
