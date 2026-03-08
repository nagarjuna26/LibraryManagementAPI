using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services;
using Moq;

namespace LibraryManagementSystem.Tests
{
    public class MemberServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturnMembers()
        {
            var repoMock = new Mock<IMemberRepository>();
            repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Member>
        {
            new Member { Id = 1, Name = "Alice", Email = "alice@email.com", PhoneNumber = "1234567890" }
        });

            var service = new MemberService(repoMock.Object);
            var result = await service.GetAllAsync();

            Assert.Single(result);
            Assert.Equal("Alice", result.First().Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMember()
        {
            var repoMock = new Mock<IMemberRepository>();
            repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Member { Id = 1, Name = "Alice" });

            var service = new MemberService(repoMock.Object);
            var result = await service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<IMemberRepository>();
            var service = new MemberService(repoMock.Object);
            var dto = new MemberDto { Id = 1, Name = "Alice", Email = "alice@email.com", PhoneNumber = "1234567890" };

            await service.AddAsync(dto);

            repoMock.Verify(r => r.AddAsync(It.Is<Member>(m => m.Name == "Alice")), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<IMemberRepository>();
            var service = new MemberService(repoMock.Object);
            var dto = new MemberDto { Id = 2, Name = "Alice Updated", Email = "alice@email.com", PhoneNumber = "1234567890" };

            await service.UpdateAsync(dto);

            repoMock.Verify(r => r.UpdateAsync(It.Is<Member>(m => m.Name == "Alice Updated")), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldCallRepository()
        {
            var repoMock = new Mock<IMemberRepository>();
            repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Member { Id = 1, Name = "Alice" });

            var service = new MemberService(repoMock.Object);
            await service.DeleteAsync(1);

            repoMock.Verify(r => r.DeleteAsync(It.Is<Member>(m => m.Id == 1)), Times.Once);
        }
    }
}
