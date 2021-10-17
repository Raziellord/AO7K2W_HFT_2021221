using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Models
{
    [Table("conflicts")]
    public class Conflict
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string NameOfConflict { get; set; }

        [Required]
        public DateTime DateOfConflict { get; set; }

        public int Casualties { get; set; }

        public string Winner { get; set; }

        public virtual ICollection<Tank> Tanks { get; set; }

        public Conflict()
        {
            Tanks = new HashSet<Tank>();
        }
        
    }
}
