using Microsoft.EntityFrameworkCore;
using S17L1.Models;

namespace S17L1.Data
{
    public class EpiBooksDbContext : DbContext
    {
        public EpiBooksDbContext(DbContextOptions<EpiBooksDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrow> Borrows { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrow>().Property(b => b.BorrowDate).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Borrow>().HasOne(b => b.Book).WithOne(b => b.Borrow);
            modelBuilder.Entity<Borrow>().HasOne(b => b.User).WithMany(b => b.Borrows);
        }
    }
}
