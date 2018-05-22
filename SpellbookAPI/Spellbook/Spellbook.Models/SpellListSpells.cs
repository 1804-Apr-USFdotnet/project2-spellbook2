using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spellbook.Models
{
    public class SpellListSpells
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpellListSpellsId { get; set; }

        public int SpellListId { get; set; }
        public virtual SpellList SpellList { get; set; }

        public int SpellId { get; set; }
        public virtual Spell Spell { get; set; }
    }
}
