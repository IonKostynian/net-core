using System.ComponentModel.DataAnnotations;

namespace lab7.Shared
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public int TicketNumber { get; set; }
    }
}
