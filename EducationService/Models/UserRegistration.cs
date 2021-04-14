using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace EducationService.Models
{
	public class UserRegistration
	{
		public string Username { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public string Password { get; set; }

	}
}
