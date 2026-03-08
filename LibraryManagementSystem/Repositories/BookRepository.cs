using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context to use for data operations.</param>
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all books from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Book}"/> containing all books.</returns>
        public async Task<List<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>The <see cref="Book"/> with the specified ID, or <c>null</c> if not found.</returns>
        public async Task<Book?> GetByIdAsync(int id) => await _context.Books.FindAsync(id);

        /// <summary>
        /// Adds a new book to the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> to add.</param>
        public async Task AddAsync(Book book) 
        { 
            _context.Books.Add(book); 
            await _context.SaveChangesAsync(); 
        }

        /// <summary>
        /// Updates an existing book in the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> to update.</param>
        public async Task UpdateAsync(Book book) 
        {
            _context.Books.Update(book); 
            await _context.SaveChangesAsync(); 
        }

        /// <summary>
        /// Deletes a book from the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> to delete.</param>
        public async Task DeleteAsync(Book book) 
        { 
            _context.Books.Remove(book); 
            await _context.SaveChangesAsync(); 
        }
    }

}
