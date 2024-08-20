using System.ComponentModel.DataAnnotations;

namespace DaigFlow.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        public int DaigId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsSuccessful { get; set; }
        public Daig Daig { get; set; }
    }
}
