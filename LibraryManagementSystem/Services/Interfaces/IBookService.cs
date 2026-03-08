using LibraryManagementSystem.DTOs;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task AddAsync(BookDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
    }


}
