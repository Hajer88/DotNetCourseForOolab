using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProjectMVCForOolab.Models
{
	public class Customer
	{
		public Customer()
		{
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int? MembershipTypeId { get; set; }

		
		public virtual MembershipType? membershiptype { get; set; }
		//Virtual
		public virtual ICollection<Movie>? movies { get; set; }
	}
}

