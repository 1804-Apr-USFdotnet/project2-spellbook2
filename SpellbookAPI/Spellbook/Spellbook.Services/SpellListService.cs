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

        public SpellListDTO GetSpellListBy(int id) {
            var spellbook = _spellLists.FindBy(sl => sl.SpellListId == id).Single();

            return Mapper.Map<SpellListDTO>(spellbook);
        }

        public List<SpellListDTO> GetAllSpellList() {
            var spellbooks = _spellLists.GetAll().ToList();

            return Mapper.Map<List<SpellListDTO>>(spellbooks);
        }


    }
}

