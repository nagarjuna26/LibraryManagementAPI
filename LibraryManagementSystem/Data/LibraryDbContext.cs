using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Book)
                .WithMany(b => b.Transactions)
                .HasForeignKey(t => t.BookId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Member)
                .WithMany(m => m.Transactions)
                .HasForeignKey(t => t.MemberId);

            modelBuilder.Entity<Member>()
                .HasIndex(m => m.PhoneNumber)
                .IsUnique();
        }
    }

}
