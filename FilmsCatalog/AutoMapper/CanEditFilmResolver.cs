using AutoMapper;
using FilmsCatalog.Data;
using FilmsCatalog.Models;
using FilmsCatalog.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.AutoMapper
{
    public class CanEditFilmResolver : IValueResolver<Film, FilmForTableViewModel, bool>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CanEditFilmResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Resolve(Film source, FilmForTableViewModel destination, bool destMember, ResolutionContext context)
        {
            var userId_claim = _httpContextAccessor?.HttpContext.User
               .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            return userId_claim?.Value == source.UserId;
        }
    }
}
