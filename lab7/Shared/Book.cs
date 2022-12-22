using System.ComponentModel.DataAnnotations;

namespace lab7.Shared
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int? Price { get; set; }
    }
}
