using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class TransactionRepository(LibraryDbContext context) : ITransactionRepository
    {
        private readonly LibraryDbContext _context = context;

        /// <summary>
        /// Retrieves all transactions from the database, including related Book and Member entities.
        /// </summary>
        /// <returns>A list of all <see cref="Transaction"/> entities.</returns>
        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a transaction by its unique identifier, including related Book and Member entities.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <returns>The <see cref="Transaction"/> entity if found; otherwise, <c>null</c>.</returns>
        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.Book)
                .Include(t => t.Member)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Adds a new transaction to the database.
        /// </summary>
        /// <param name="transaction">The <see cref="Transaction"/> entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing transaction in the database.
        /// </summary>
        /// <param name="transaction">The <see cref="Transaction"/> entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a transaction from the database.
        /// </summary>
        /// <param name="transaction">The <see cref="Transaction"/> entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

    }
}
