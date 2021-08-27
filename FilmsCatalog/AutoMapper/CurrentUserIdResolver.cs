using AutoMapper;
using FilmsCatalog.Models;
using FilmsCatalog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.AutoMapper
{
    public class UserIdResolver : IValueResolver<FilmViewModel, Film, string>
    {
        private readonly SignInManager<User> _signInManager;
        public UserIdResolver(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public string Resolve(FilmViewModel source, Film destination, string destMember, ResolutionContext context)
        {
            return _signInManager.UserManager.GetUserId(System.Security.Claims.ClaimsPrincipal.Current);
        }
    }
}
