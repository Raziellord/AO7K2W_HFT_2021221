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
    [Table("Crews")]
    public class Crew
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Profession { get; set; }
        
        [Required]
        public int Age { get; set; }
        [Required]
        public string Rank { get; set; }

        [ForeignKey(nameof(Tank))]
        public int TankId { get; set; }
           
        [NotMapped]
        [JsonIgnore]
        public virtual Tank Tank { get; set; }

    }
}
