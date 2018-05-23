using Spellbook.Models;
using Spellbook.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;

namespace Spellbook.Services
{
    public partial class SpellbookService
    {
        private readonly SpellListRepository _spellLists = new SpellListRepository();
        private readonly SpellListSpellsRepository _spellListsSpells = new SpellListSpellsRepository();

        public SpellList GetSpellListBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}

