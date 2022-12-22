using System.ComponentModel.DataAnnotations;

namespace lab7.Shared
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public int TicketNumber { get; set; }
    }
}
