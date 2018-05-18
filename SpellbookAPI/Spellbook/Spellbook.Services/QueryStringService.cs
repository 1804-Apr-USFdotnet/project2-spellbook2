using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spellbook.Services
{
    class QueryStringService
    {
        public string queryString { get; set; }

        public QueryStringService(string qs)
        {
            queryString = qs;
        }

        public HashSet<string> queryStringasString()
        {
            string pattern = "";
            Regex rgx = new Regex(pattern);
        }
    }
}
