using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Models
{
    [Table("Conflicts")]
    public class Conflict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConflictId { get; set; }

        [MaxLength(100)]
        [Required]
        public string NameOfConflict { get; set; }

        [Required]
        public DateTime DateOfConflict { get; set; }
        public int Casualties { get; set; }

        public string Winner { get; set; }

        [NotMapped]
        public virtual ICollection<Tank> Tanks { get; set; }

        public Conflict()
        {
            Tanks = new HashSet<Tank>();
        }
        public Conflict(string line)
        {
            string[] split = line.Split('#');
            ConflictId = int.Parse(split[0]);
            NameOfConflict = split[1];
            DateOfConflict = DateTime.Parse(split[2].Replace('*', '.'));
            Casualties = int.Parse(split[3]);
            Winner = split[4];
            Tanks = new HashSet<Tank>();
        }

        public override string ToString()
        {
            return "Name of conflict: " + NameOfConflict + "\n" + "Date of conflict:" + DateOfConflict.ToString();
        }
    }
}
