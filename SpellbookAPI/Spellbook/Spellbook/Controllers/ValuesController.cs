using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using Spellbook.DataContext;
using Spellbook.Models;

using System.Diagnostics;

namespace Spellbook.Controllers
{
	public class ValuesController : ApiController
	{
		private readonly spellbookDbContext _context = new spellbookDbContext();


		// GET api/values
		public IEnumerable<Spell> Get()
		{
			var x = _context.Spells.ToList();

			// go through every recrod
			foreach (var i in x)
			{
				// get classes for record
				var record = i.Classes;

				// split record to list of strings
				var list = record.Split(',');

				// remove special characters
				for (int j = 0; j < list.Length; j++)
				{
					list[j] = Regex.Replace(list[j], "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
				}

				// get int value
				int output = 0;
				foreach (var k in list)
				{
					switch (k)
					{
						case "Bard":
							output += 1;
							break;
						case "Cleric":
							output += 2;
							break;
						case "Druid":
							output += 4;
							break;
						case "Paladin":
							output += 8;
							break;
						case "Ranger":
							output += 16;
							break;
						case "Sorcerer":
							output += 32;
							break;
						case "Warlock":
							output += 64;
							break;
						case "Wizard":
							output += 128;
							break;
						default:
							break;
						
					}
				}
				// set ClassesAsInt 
				i.ClassesAsInt = output;
				output = 0;

			}
			_context.SaveChanges();
			return _context.Spells;
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
