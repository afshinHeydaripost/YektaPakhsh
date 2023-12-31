using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;


namespace Repository.Identity
{
    public class ApplicationUser : IdentityUser
    {

		[MaxLength(250)]
		public string firstName { get; set; }

		[MaxLength(250)]
		public string LastName { get; set; }
		[MaxLength(20)]
		public string NationalCode { get; set; }
		public DateTime? Birthday { get; set; }

		[MaxLength(2000)]
		public string Address { get; set; }

		[MaxLength(2000)]
		public string ProfilePicture { get; set; }

	}
}
