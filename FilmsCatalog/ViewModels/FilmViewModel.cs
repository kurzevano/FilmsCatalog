using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels
{
    public class FilmViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Название*")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Описание*")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Год выпуска*")]
        public DateTime Year { get; set; }

        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        [Display(Name = "Постер")]
        public string PosterFileName { get; set; }

        [Display(Name = "Постер")]
        public IFormFile PosterImage { get; set; }
    }
}
