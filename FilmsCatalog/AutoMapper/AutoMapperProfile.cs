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
            CreateMap<Film, FilmForTableViewModel>();
            CreateMap<FilmForTableViewModel, Film>();

            CreateMap<Film, FilmViewModel>();
            CreateMap<FilmViewModel, Film>();
        }
    }
}
