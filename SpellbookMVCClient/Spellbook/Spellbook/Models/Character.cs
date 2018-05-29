namespace Spellbook.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public SpellList Spellbook { get; set; }
    }
}