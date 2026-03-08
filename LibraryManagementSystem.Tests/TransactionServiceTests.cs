using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services;
using Moq;

namespace LibraryManagementSystem.Tests
{
    public class TransactionServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturnTransactions()
        {
            var repoMock = new Mock<ITransactionRepository>();
            repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Transaction>
        {
            new Transaction { Id = 1, BookId = 1, MemberId = 1 }
        });

            var service = new TransactionService(repoMock.Object);
            var result = await service.GetAllAsync();

            Assert.Single(result);
            Assert.Equal(1, result.First().BookId);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTransaction()
        {
            var repoMock = new Mock<ITransactionRepository>();
            repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Transaction { Id = 1, BookId = 1, MemberId = 1 });

            var service = new TransactionService(repoMock.Object);
            var result = await service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<ITransactionRepository>();
            var service = new TransactionService(repoMock.Object);
            var dto = new TransactionDto { Id = 1, BookId = 1, MemberId = 1, BorrowedDate = DateTime.UtcNow };

            await service.AddAsync(dto);

            repoMock.Verify(r => r.AddAsync(It.Is<Transaction>(t => t.BookId == 1 && t.MemberId == 1)), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<ITransactionRepository>();
            var service = new TransactionService(repoMock.Object);
            var dto = new TransactionDto { Id = 2, BookId = 1, MemberId = 1, BorrowedDate = DateTime.UtcNow };

            await service.UpdateAsync(dto);

            repoMock.Verify(r => r.UpdateAsync(It.Is<Transaction>(t => t.Id == 2)), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<ITransactionRepository>();
            repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Transaction { Id = 1, BookId = 1, MemberId = 1 });

            var service = new TransactionService(repoMock.Object);
            await service.DeleteAsync(1);

            repoMock.Verify(r => r.DeleteAsync(It.Is<Transaction>(t => t.Id == 1)), Times.Once);
        }
    }
}
