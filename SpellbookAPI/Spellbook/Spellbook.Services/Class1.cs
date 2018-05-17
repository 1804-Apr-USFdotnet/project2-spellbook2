using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.Models;

using Spellbook.DataContext;


namespace Spellbook.Services
{
	public class Class1
	{
		spellbookDbContext _context = new spellbookDbContext();
		public void ClassAsIntGen()
		{
			IEnumerable<Spell> x = _context.Spells;
			
			foreach(var i in x)
			{
				Console.WriteLine(i.);
			}
			Console.ReadLine();
		}
	}

	public class start
	{
		public static void Main()
		{
			var x = new Class1();
			x.ClassAsIntGen();
		}
	}
}
