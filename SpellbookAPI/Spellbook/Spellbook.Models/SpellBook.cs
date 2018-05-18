using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Spellbook.Models
{
    public class Spellbook
    {
        [Key]
        public int SpellbookId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<SpellbookSpells> Spells { get; set; }
    }
}
