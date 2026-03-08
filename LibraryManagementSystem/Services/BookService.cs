using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class with the specified repository.
        /// </summary>
        /// <param name="repository"></param>
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all books from the repository and maps them to DTOs.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PublishedYear = b.PublishedYear
            }).ToList();
        }

        /// <summary>
        /// Retrieves a book by its unique identifier and maps it to a DTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedYear = book.PublishedYear
            };
        }

        /// <summary>
        /// Adds a new book to the repository using the provided DTO.
        /// </summary>
        /// <param name="dto"></param>
        public async Task AddAsync(BookDto dto)
        {
            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                PublishedYear = dto.PublishedYear
            };
            await _repository.AddAsync(book);
        }

        /// <summary>
        /// Updates an existing book in the repository using the provided DTO. If the book does not exist, the method returns without making any changes.
        /// </summary>
        /// <param name="dto"></param>
        public async Task UpdateAsync(BookDto dto)
        {
            var book = await _repository.GetByIdAsync(dto.Id);
            if (book == null) return;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.PublishedYear = dto.PublishedYear;

            await _repository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return;

            await _repository.DeleteAsync(book);
        }
    }

}
