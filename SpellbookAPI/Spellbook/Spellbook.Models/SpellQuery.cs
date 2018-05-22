using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.Models
{

    public class SpellQuery
    {
        public string school { get; set; }
        public string classes { get; set; }
        public string levels { get; set; }

        public Boolean isValid()
        {
            return true;
        }

        public void isNull()
        {
            //classes = classes ?? "Bard,Cleric,Druid,Paladin,Ranger,Sorcerer,Warlock,Wizard";
            school = school ??  "Abjuration,Conjuration,Divination,Enchantment,Evocation,Illusion,Necromancy,Transmutation";
            levels = levels ?? "0,1,2,3,4,5,6,7,8,9";
        }
    }
}
