using System;

namespace Spellbook.Models
{
    public class SpellDTO
    {
        public int SpellDTOId { get; set; }

        public string Name { get; set; }

        public string School { get; set; }

        public int Level { get; set; }

        public Boolean Ritual { get; set; }

        public string CastingTime { get; set; }

        public string Source { get; set; }

        public string Range { get; set; }

        //public string Classes { get; set; }

        public string Components { get; set; }

        public string Duration { get; set; }

        public string AtHigherLevel { get; set; }

        public Boolean Concentration { get; set; }

        //public string Slug { get; set; }

        public int? Page { get; set; }

        public string Description { get; set; }

        public int ClassesAsInt { get; set; }

        //public virtual ICollection<SpellListSpells> Spellbooks { get; set; }
    }
}
