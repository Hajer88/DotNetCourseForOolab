using System;
using System.ComponentModel.DataAnnotations;

namespace FirstProjectMVCForOolab.Models
{
	public class Movie
	{
		public Movie()
		{
		}
		[Key]
		public int Id { get; set; }
		[Required]
		[Display(Name ="Name of Movie")]
		[MaxLength(10, ErrorMessage ="MaxLength Exceeded")]
		public string Name { get; set; }
        public int? GenreId { get; set; }
		public virtual Genre? genre { get; set; }
		public virtual ICollection<Customer>? customers { get; set; }
	}
}

