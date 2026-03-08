using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public static class DataSeeder
    {
        public static void Seed(LibraryDbContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book { Id = 1, Title = "Solid Principles", Author = "Robert C. Martin", PublishedYear = 2008 },
                    new Book { Id = 2, Title = "Domain-Driven Design", Author = "Eric Evans", PublishedYear = 2003 },
                    new Book { Id = 3, Title = "Refactoring", Author = "Martin Fowler", PublishedYear = 1999 },
                    new Book { Id = 4, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", PublishedYear = 1999 },
                    new Book { Id = 5, Title = "Design Patterns", Author = "GoF", PublishedYear = 1994 }
                );
            }

            if (!context.Members.Any())
            {
                context.Members.AddRange(
                    new Member { Id = 1, Name = "Ajay", PhoneNumber = "9876543210" },
                    new Member { Id = 2, Name = "Bhargavi", PhoneNumber = "9123456780", Email = "bob@example.com" },
                    new Member { Id = 3, Name = "Charlie", PhoneNumber = "9988776655" },
                    new Member { Id = 4, Name = "Donald", PhoneNumber = "8899776655", Email = "diana@example.com" },
                    new Member { Id = 5, Name = "Ethan", PhoneNumber = "7766554433" }
                );
            }

            if (!context.Transactions.Any())
            {
                context.Transactions.AddRange(
                    new Transaction { Id = 1, BookId = 1, MemberId = 1, BorrowedDate = DateTime.UtcNow.AddDays(-10) },
                    new Transaction { Id = 2, BookId = 2, MemberId = 2, BorrowedDate = DateTime.UtcNow.AddDays(-5), ReturnedDate = DateTime.UtcNow.AddDays(-1) },
                    new Transaction { Id = 3, BookId = 3, MemberId = 3, BorrowedDate = DateTime.UtcNow.AddDays(-2) },
                    new Transaction { Id = 4, BookId = 4, MemberId = 4, BorrowedDate = DateTime.UtcNow.AddDays(-7) },
                    new Transaction { Id = 5, BookId = 5, MemberId = 5, BorrowedDate = DateTime.UtcNow.AddDays(-3) }
                );

            }

            context.SaveChanges();
        }
    }
}
