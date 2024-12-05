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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnConfiguring(modelBuilder);
			/*modelBuilder.Entity<Movie>()
				.Property(c => c.Name)
				.HasColumnName("Movie")
				.HasMaxLength(20)
				.IsRequired();

			/*modelBuilder.Entity<Movie>()
				.HasOne(c => c.genre)
				.WithMany(t => t.movies)
				.Map(m => m.MapKey("Genre"));*/
		}
	}
}

