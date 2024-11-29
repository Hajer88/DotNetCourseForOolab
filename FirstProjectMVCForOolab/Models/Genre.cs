using System;
namespace FirstProjectMVCForOolab.Models
{
	public class Genre
	{
		public Genre()
		{
		}
		public int GenreId { get; set; }

		public string genre { get; set; }

		public virtual IEnumerable<Movie>? movies { get; set; }


	}
}

