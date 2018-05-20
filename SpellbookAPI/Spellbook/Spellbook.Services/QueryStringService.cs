﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spellbook.Models;

namespace Spellbook.Services
{
    class QueryStringService
    {
        private string _queryString { get; set; }


        public QueryStringService(string qs)
        {
            _queryString = qs;
        }

        public void StringPredicate(string filter, out Expression<Func<Spell, bool>> predicate)
        {
            string[] querySplit;
            switch (filter)
            {
                case "Classes":
                {
                    int inputBit = new BitwiseService().ClassConverter(_queryString);
                    predicate = (x => (inputBit & x.ClassesAsInt) != 0);
                    break;
                }
                case "Schools":
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
    }
}
