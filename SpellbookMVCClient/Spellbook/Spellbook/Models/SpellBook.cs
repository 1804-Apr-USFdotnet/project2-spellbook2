using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spellbook.Models
{
    public class SpellList
    {
        public int SpellListId { get; set; }

        public string Name { get; set; }

        public List<Spell> Spells { get; set; }
    }
}