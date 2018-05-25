using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Spellbook.Models;

namespace Spellbook.Services
{
    public interface ISpellbookService
    {
        SpellDTO GetSpellBy(int id);

        List<SpellDTO> GetSpellBy(SpellQuery query);

        SpellListDTO GetSpellListBy(int id);

        void AddSpellList(SpellListDTO spellList);

        void EditSpellList(SpellListDTO newSpellList);

        void DeleteSpellList(int id);

        List<CharacterDTO> GetAllCharacters();

        CharacterDTO GetCharacterBy(int id);

        void AddCharacter(CharacterDTO c);

        void DeleteCharacter(int id);

        void EditCharacter(CharacterDTO c);
    }   
}       
