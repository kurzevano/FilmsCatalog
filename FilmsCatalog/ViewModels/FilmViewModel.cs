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

        [Display(Name = "Название")]

        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Год выауска")]
        public DateTime Year { get; set; }

        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        [Display(Name = "Постер")]
        public byte[] Poster { get; set; }
    }
}
