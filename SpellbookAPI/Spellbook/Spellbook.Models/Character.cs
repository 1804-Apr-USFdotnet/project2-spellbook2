using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellbook.Models
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId {get; set;}
        public string Name { get; set; }
        public int Level {get; set;}
        //public virtual User {get; set;}
       // public virtual Spellbook {get; set;}    NOT YET! soon though
    }
}
