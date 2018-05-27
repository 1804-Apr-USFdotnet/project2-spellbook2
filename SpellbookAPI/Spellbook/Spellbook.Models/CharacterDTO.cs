namespace Spellbook.Models
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public SpellListDTO Spellbook { get; set; }
    }
}
