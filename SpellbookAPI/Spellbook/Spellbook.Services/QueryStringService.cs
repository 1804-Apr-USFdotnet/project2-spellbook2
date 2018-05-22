using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Spellbook.Models;

namespace Spellbook.Services
{
    class QueryStringService
    {
        private SpellQuery _spellQuery { get; }

        public QueryStringService(SpellQuery sq)
        {
            _spellQuery = sq;
        }

        public void CompoundQuery(out Expression<Func<Spell, bool>> predicate)
        {
            string[] s_levels = _spellQuery.levels.Split(',');
            string[] school = _spellQuery.school.Split(',');
            int classes = new BitwiseService().ClassConverter(_spellQuery.classes);

            HashSet<int> levels = new HashSet<int>();
            foreach (string s in s_levels)
            {
                levels.Add(Int32.Parse(s));
            }

            predicate = (x=> school.Contains(x.School) && levels.Contains(x.Level) && ((classes & x.ClassesAsInt) == classes) );
        }
    }
}
