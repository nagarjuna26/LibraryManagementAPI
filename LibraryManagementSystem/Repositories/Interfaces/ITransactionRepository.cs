using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task AddAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(Transaction transaction);
    }

}
