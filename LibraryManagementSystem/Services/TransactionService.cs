using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class TransactionService(ITransactionRepository repository) : ITransactionService
    {
        private readonly ITransactionRepository _repository = repository;

        /// <summary>
        /// Retrieves all transactions from the repository and maps them to DTOs.
        /// </summary>
        /// <returns>A list of <see cref="TransactionDto"/> representing all transactions.</returns>
        public async Task<List<TransactionDto>> GetAllAsync()
        {
            var transactions = await _repository.GetAllAsync();
            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                BookId = t.BookId,
                MemberId = t.MemberId,
                BorrowedDate = t.BorrowedDate,
                ReturnedDate = t.ReturnedDate
            }).ToList();
        }

        /// <summary>
        /// Retrieves a transaction by its unique identifier and maps it to a DTO.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction.</param>
        /// <returns>
        /// A <see cref="TransactionDto"/> if found; otherwise, <c>null</c>.
        /// </returns>
        public async Task<TransactionDto?> GetByIdAsync(int id)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction == null) return null;

            return new TransactionDto
            {
                Id = transaction.Id,
                BookId = transaction.BookId,
                MemberId = transaction.MemberId,
                BorrowedDate = transaction.BorrowedDate,
                ReturnedDate = transaction.ReturnedDate
            };
        }

        /// <summary>
        /// Adds a new transaction to the repository using the provided DTO.
        /// </summary>
        /// <param name="dto">The <see cref="TransactionDto"/> representing the transaction to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = dto.Id,
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowedDate = dto.BorrowedDate,
                ReturnedDate = dto.ReturnedDate
            };
            await _repository.AddAsync(transaction);
        }

        /// <summary>
        /// Updates an existing transaction in the repository using the provided DTO.
        /// </summary>
        /// <param name="dto">The <see cref="TransactionDto"/> representing the transaction to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(TransactionDto dto)
        {
            var transaction = new Transaction
            {
                Id = dto.Id,
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowedDate = dto.BorrowedDate,
                ReturnedDate = dto.ReturnedDate
            };
            await _repository.UpdateAsync(transaction);
        }

        /// <summary>
        /// Deletes a transaction from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(int id)
        {
            var transaction = await _repository.GetByIdAsync(id);
            if (transaction != null)
            {
                await _repository.DeleteAsync(transaction);
            }
        }
    }
}
