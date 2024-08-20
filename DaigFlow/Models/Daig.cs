using System.ComponentModel.DataAnnotations;

namespace DaigFlow.Models
{
    public class Daig
    {
        [Key]
        public int DaigId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } 
        public int Price { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }
}
