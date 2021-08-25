using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.ViewModels
{
    /// <summary>
    /// Вью-модель фильма для отображения в таблице
    /// </summary>
    public class FilmForTableViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]

        public string Name { get; set; }

        [Display(Name = "Год выпуска")]
        public DateTime Year { get; set; }

        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        public bool CanEdit { get; set; }
    }
}
