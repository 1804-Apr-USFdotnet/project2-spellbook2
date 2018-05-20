using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spellbook.Services
{
    class BitwiseService
    {
        public int ClassConverter(string classes)
        {
            string[] splitClasses = classes.Split(',');

            for (int j = 0; j < splitClasses.Length; j++)
            {
                splitClasses[j] = Regex.Replace(splitClasses[j], "[^a-zA-Z0-9.]+", "", RegexOptions.Compiled);
            }

            int bitValue = 0;
            foreach (var k in splitClasses)
            {
                switch (k)
                {
                    case "Bard":
                        bitValue += 1;
                        break;
                    case "Cleric":
                        bitValue += 2;
                        break;
                    case "Druid":
                        bitValue += 4;
                        break;
                    case "Paladin":
                        bitValue += 8;
                        break;
                    case "Ranger":
                        bitValue += 16;
                        break;
                    case "Sorcerer":
                        bitValue += 32;
                        break;
                    case "Warlock":
                        bitValue += 64;
                        break;
                    case "Wizard":
                        bitValue += 128;
                        break;
                    default:
                        break;

                }
            }

            return bitValue;
        }
    }
}
