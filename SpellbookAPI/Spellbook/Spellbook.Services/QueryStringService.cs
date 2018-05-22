using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Spellbook.Models;

namespace Spellbook.Services
{
    class QueryStringService
    {
        private string _queryString { get; }
        private SpellQuery _spellQuery { get; }


        public QueryStringService(string qs)
        {
            _queryString = qs;
        }

        public QueryStringService(SpellQuery sq)
        {
            _spellQuery = sq;
        }

        public void StringPredicate(string filter, out Expression<Func<Spell, bool>> predicate)
        {
            string[] querySplit;
            switch (filter)
            {
                case "classes":
                {
                    int inputBit = new BitwiseService().ClassConverter(_queryString);
                    predicate = (x => (inputBit & x.ClassesAsInt) == inputBit);
                    break;
                }
                case "schools":
                {
                    querySplit = _queryString.Split(',');
                    predicate = (x => querySplit.Contains(x.School));
                    break;
                }
                default:
                {
                    querySplit = _queryString.Split(',');
                    predicate = (x => querySplit.Contains(x.School));
                    break;
                }
            }
        }
        public void IntPredicate( out Expression<Func<Spell, bool>> predicate)
        {
            string[] querySplit = _queryString.Split(',');
            HashSet<int> levels = new HashSet<int>();

            foreach (string s in querySplit)
            {
                levels.Add(Int32.Parse(s));
            }

            predicate = (x => levels.Contains(x.Level));

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
