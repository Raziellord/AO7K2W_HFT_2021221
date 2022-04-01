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
        public int TankId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Model { get; set; }
        
        public string Nickname { get; set; }

        public int Eliminations { get; set; }

        [Required]
        public int CrewSpace { get; set; }

        [Required]
        public DateTime StartOfService { get; set; }

        [JsonIgnore]
        public virtual Conflict Conflict { get; set; }
        

        [ForeignKey(nameof(Conflict))]
        public int ConflictId { get; set; }


        [JsonIgnore]
        public virtual ICollection<Crew> Crews { get; set; }

        public Tank()
        {
            Crews = new HashSet<Crew>();
        }

        public Tank(string line)
        {
            string[] split = line.Split('#');
            TankId = int.Parse(split[0]);
            Model = split[1];
            Nickname = split[2];
            Eliminations = int.Parse(split[3]);
            CrewSpace = int.Parse(split[4]);
            StartOfService = DateTime.Parse(split[5].Replace('*', '.'));
            ConflictId = int.Parse(split[6]);
            Crews = new HashSet<Crew>();
        }

        public  string ToString()
        {
            return "Model: " + Model + "\n" + "Start of service: " + StartOfService.ToString() + " \n" + "Crew space: " + CrewSpace;
        }
    }
}
