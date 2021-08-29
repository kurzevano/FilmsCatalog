using FilmsCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.FileManager
{
    public interface IFileManager
    {
        string Upload(IImageContainer imageContainer);

        void Delete(IImageContainer imageContainer);
    }
}
