using LibraryManagementSystem.DTOs;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetAllAsync();
        Task<TransactionDto?> GetByIdAsync(int id);
        Task AddAsync(TransactionDto dto);
        Task UpdateAsync(TransactionDto dto);
        Task DeleteAsync(int id);
    }

}
