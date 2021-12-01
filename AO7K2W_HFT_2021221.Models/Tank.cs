using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AO7K2W_HFT_2021221.Models
{
    [Table("Tanks")]
    public class Tank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Model { get; set; }
        
        public string Nickname { get; set; }

        public int Eliminations { get; set; }

        [Required]
        public int CrewSpace { get; set; }

        [Required]
        public DateTime StartOfService { get; set; }

        
        [NotMapped]
        [JsonIgnore]
        public virtual Conflict Conflict { get; set; }

        [ForeignKey(nameof(Conflict))]
        public int ConflictId { get; set; }
        [NotMapped]
        public virtual ICollection<Crew> Crews { get; set; }

        public Tank()
        {
            Crews = new HashSet<Crew>();
        }

        public override string ToString()
        {
            return "Model: " + Model + "\n" + "Start of service: " + StartOfService.ToString() + " \n" + "Crew space: " + CrewSpace;
        }
    }
}
