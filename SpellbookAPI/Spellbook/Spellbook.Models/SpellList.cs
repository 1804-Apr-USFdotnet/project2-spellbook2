using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spellbook.Models
{
    public class SpellList
    {
        [Key]
        public int SpellListId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SpellListSpells> Spells { get; set; }
    }
}
