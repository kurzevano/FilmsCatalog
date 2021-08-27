using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsCatalog.Models
{
	public class Film
	{
		public int Id { get; set; }

        public string Name { get; set; }

		public string Description { get; set; }

		public DateTime Year { get; set; }

		public string Director { get; set; }

		public string PosterFileName { get; set; }

		public string UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User CreateUser { get; set; }
	}
}
