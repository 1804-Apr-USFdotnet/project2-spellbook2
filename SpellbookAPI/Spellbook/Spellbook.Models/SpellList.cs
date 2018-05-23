using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spellbook.Models
{
    public class SpellList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpellListId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Spell> Spells { get; set; }
    }
}
