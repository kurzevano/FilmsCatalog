using FilmsCatalog.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly IFilePathResolver _filePathResolver;

        public FileManager(IFilePathResolver filePathResolver)
        {
            this._filePathResolver = filePathResolver;
        }

        public string Upload(IImageContainer imageContainer)
        {
            if (imageContainer.Image == null)
            {
                return imageContainer.ImageFileName;
            }

            var newFileName = string.Empty;
            newFileName = Guid.NewGuid().ToString() + "-" + imageContainer.Image.FileName;
            string filePath = Path.Combine(_filePathResolver.Directory, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageContainer.Image.CopyTo(fileStream);
            }

            return newFileName;
        }

        public void Delete(IImageContainer imageContainer)
        {
            if (imageContainer.ImageFileName != null)
            {
                var oldFileName = Path.Combine(_filePathResolver.Directory, imageContainer.ImageFileName);
                if (System.IO.File.Exists(oldFileName))
                {
                    System.IO.File.Delete(oldFileName);
                }
            }
        }
    }
}
