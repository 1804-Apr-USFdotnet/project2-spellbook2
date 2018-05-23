using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Spellbook.Models;
using Spellbook.Repositories;

namespace Spellbook.Services
{
    public partial class SpellbookService
    {
        private readonly SpellRepository _spells = new SpellRepository();

        public SpellDTO GetSpellBy(int id)
        {
            Expression<Func<Spell, bool>> predicate = (x => x.SpellId == id);
            var spell = _spells.FindBy(predicate).FirstOrDefault();
            var spelldto = Mapper.Map<SpellDTO>(spell);
            return spelldto;
        }

        public List<SpellDTO> GetSpellBy(SpellQuery query)
        {
            try
            {
                Expression<Func<Spell, bool>> predicate;
                QueryStringService queryHelper = new QueryStringService(query);
                queryHelper.CompoundQuery(out predicate);
                var spellContainer = _spells.FindBy(predicate).ToList();
                return Mapper.Map<List<SpellDTO>>(spellContainer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
<<<<<<< HEAD:SpellbookAPI/Spellbook/Spellbook.Services/SpellbookService.cs

        public SpellList GetSpellListBy(int id)
        {
            throw new NotImplementedException();
        }

        public Character GetCharacterBy(int id)
        {
            Expression<Func<Character, bool>> predicate = (x => x.CharacterId == id);
            return _characters.FindBy(predicate).FirstOrDefault();
        }

        public void AddCharacter(Character c)
        {
            _characters.Add(c);
        }

        public void DeleteCharacter(Character c)
        {
            _characters.Delete(c);
        }

        public void EditCharacter(Character c)
        {
            _characters.Edit(c);
        }

=======
>>>>>>> master:SpellbookAPI/Spellbook/Spellbook.Services/SpellService.cs
    }
}
