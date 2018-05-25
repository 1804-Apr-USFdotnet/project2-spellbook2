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
        public SpellListDTO GetSpellListBy(int id) {
            var spellbook = _spellLists.FindBy(sl => sl.SpellListId == id).Single();

            SpellListDTO spellList = new SpellListDTO() {
                Name = spellbook.Name,
                SpellIds = spellbook.Spells.Select(sp => sp.SpellId).ToList()
            };

            return spellList;
        }

        public void AddSpellList(SpellListDTO spellList) {
            //automapper couldn't handle this one
            SpellList newSpellList = new SpellList() {
                SpellListId = spellList.SpellListId,
                Name = spellList.Name
            };

            var spells = _spells.GetAll().Where(sp => spellList.SpellIds.Contains(sp.SpellId)).ToList();

            newSpellList.Spells = spells;

            // todo
            //newSpellList.Spells = GetAllSpells();

            _spellLists.Add(newSpellList);

            _spellLists.Save();
        }

        public void EditSpellList(SpellListDTO spellList) {
            var spellBook = _spellLists.FindBy(sl => sl.SpellListId == spellList.SpellListId).Single();

            var spells = _spells.GetAll().Where(sp => spellList.SpellIds.Contains(sp.SpellId)).ToList();

            spellBook.Name = spellList.Name;
            spellBook.Spells = spells;

            _spellLists.Save();
        }

        public void DeleteSpellList(int id) {
            var target = _spellLists.FindBy(sl => sl.SpellListId == id).Single();

            _spellLists.Delete(target);
            
            _spellLists.Save();
        }


    }
}

