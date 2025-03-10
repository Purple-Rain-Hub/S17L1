using Microsoft.EntityFrameworkCore;
using S17L1.Models;

namespace S17L1.Data
{
    public class EpiBooksDbContext : DbContext
    {
        public EpiBooksDbContext(DbContextOptions<EpiBooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
