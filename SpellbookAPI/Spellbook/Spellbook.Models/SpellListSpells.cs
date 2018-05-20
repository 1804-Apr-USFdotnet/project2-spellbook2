namespace Spellbook.Models
{
    public class SpellListSpells
    {
        public int SpellListId { get; set; }
        public SpellList SpellList { get; set; }

        public int SpellId { get; set; }
        public Spell Spell { get; set; }
    }
}
