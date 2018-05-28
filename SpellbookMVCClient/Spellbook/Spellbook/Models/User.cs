using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spellbook.Models
{
	public class User
	{
		[Required]
		[RegularExpression(@"^[a-zA-Z0-9]",ErrorMessage = "No special characters or spaces.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }
		public int? Phone { get; set; }
		public string Email { get; set; }
	}
}