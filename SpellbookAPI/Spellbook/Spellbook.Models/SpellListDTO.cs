using System.Collections.Generic;

namespace Spellbook.Models
{
    public class SpellListDTO
    {
        public int SpellListId { get; set; }

        public string Name { get; set; }

        public virtual List<SpellDTO> Spells { get; set; }
    }
}
