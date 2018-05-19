using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spellbook.Models;

namespace Spellbook.Services
{
    class QueryStringService
    {
        public string queryString { get; set; }

        public QueryStringService(string qs)
        {
            queryString = qs;
        }

        public Expression<Func<Spell, bool>> StringHashSet(string filter)
        {
            string[] querySplit;
            switch (filter)
            {
                case "Classes":
                {
                    querySplit = queryString.Split(',');

                    break;
                }
                case "Schools":
                {
                    querySplit = queryString.Split(',');
                    break;
                }
                default:
                {
                    break;
                }
            }
            return
    }
}
