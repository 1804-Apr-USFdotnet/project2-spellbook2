using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.Models
{
    class Spell
    {
        id int IDENTITY PRIMARY KEY,
            name VARCHAR(8000) NOT NULL,
            school VARCHAR(8000) NOT NULL,
            level INTEGER NOT NULL,
        ritual BIT,
            casting_time VARCHAR(8000) NOT NULL,
            source VARCHAR(8000) NOT NULL,
            range VARCHAR(8000) NOT NULL,
            classes VARCHAR(8000) NOT NULL,
            components VARCHAR(8000),
        duration VARCHAR(8000) NOT NULL,
            at_higher_level VARCHAR(8000) NOT NULL,
            concentration BIT,
        slug VARCHAR(8000) NOT NULL,
            page INTEGER NULL,
            description VARCHAR(8000) NOT NULL
    }
}
