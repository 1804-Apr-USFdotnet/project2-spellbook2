using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Tests {

    public class TestSpellRepository : ARepository<TestSpellbookDbContext, Spell> { }

    public class TestSpellListRepository : ARepository<TestSpellbookDbContext, SpellList> { }

    public class TestCharacterRepository : ARepository<TestSpellbookDbContext, Character> { }

}