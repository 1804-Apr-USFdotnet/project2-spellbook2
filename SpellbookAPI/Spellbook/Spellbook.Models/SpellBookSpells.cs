namespace Spellbook.Models
{
    public class SpellbookSpells
    {
        public int SpellbookId { get; set; }
        public Spellbook Spellbook { get; set; }

        public int SpellId { get; set; }
        public Spell Spell { get; set; }
    }
}
