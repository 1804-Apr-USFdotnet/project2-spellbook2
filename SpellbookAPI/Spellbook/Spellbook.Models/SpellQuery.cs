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
    }
}
