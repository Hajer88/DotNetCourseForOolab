using System;
using Microsoft.EntityFrameworkCore;

namespace FirstProjectMVCForOolab.Models
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			:base(options)
		{

		}
		public DbSet<Movie> movies { get; set; }
		public DbSet <Customer>  customers{ get; set; }
		public DbSet<MembershipType> membershipTypes { get; set; }
		public DbSet<Genre> genres { get; set; }


	}
}

