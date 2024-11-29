using System;
namespace FirstProjectMVCForOolab.Models
{
	public class MembershipType
	{
		public MembershipType()
		{
		}
		public int Id { get; set; }
		public int  signUpFee { get; set; }
		public int DurationInMonth  { get; set; }
		public ICollection<Customer>? customers { get; set; }
	}
}

