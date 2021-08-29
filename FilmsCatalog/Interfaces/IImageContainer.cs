using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Interfaces
{
    public interface IImageContainer
    {
        public IFormFile Image { get; set; }

        public string ImageFileName { get; set; }
    }
}
