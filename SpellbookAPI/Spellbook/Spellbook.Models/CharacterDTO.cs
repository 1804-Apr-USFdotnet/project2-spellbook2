using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.Models
{
    public class CharacterDTO
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public SpellList Spellbook { get; set; }
    }
}
