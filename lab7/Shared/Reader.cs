using System.ComponentModel.DataAnnotations;

namespace lab7.Shared
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Person Person { get; set; } = null!;
        public Book Book { get; set; } = null!;
    }
}
