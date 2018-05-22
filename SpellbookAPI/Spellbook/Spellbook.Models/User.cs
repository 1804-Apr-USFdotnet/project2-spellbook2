using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spellbook.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }

		[Required]
		public string Name { get; set; }

		public int? Phone { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
