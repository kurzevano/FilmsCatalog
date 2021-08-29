using FilmsCatalog.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.FileManager
{
    public class WwwRootImagesPathResolver : IFilePathResolver
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WwwRootImagesPathResolver(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
            Directory = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
        }

        public string Directory { get; private set; }
    }
}
