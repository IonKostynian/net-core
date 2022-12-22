using lab7.Shared;
using Microsoft.EntityFrameworkCore;

namespace lab7.Server.Database
{
    public class ReadersContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        public DbSet<Reader> Readers { get; set; } = null!;

        public ReadersContext(DbContextOptions<ReadersContext> options) : base(options)
        {
            
        }
    }
}
