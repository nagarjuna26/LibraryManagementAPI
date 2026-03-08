using Xunit;
using Moq;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;

public class BookServiceTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnBooks()
    {
        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Book>
        {
            new Book { Id = 1, Title = "Book A", Author = "Author A", PublishedYear = 2020 }
        });

        var service = new BookService(repoMock.Object);
        var result = await service.GetAllAsync();

        Assert.Single(result);
        Assert.Equal("Book A", result.First().Title);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnBook()
    {
        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Book { Id = 1, Title = "Book A" });

        var service = new BookService(repoMock.Object);
        var result = await service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task AddAsync_ShouldCallRepository()
    {
        var repoMock = new Mock<IBookRepository>();
        var service = new BookService(repoMock.Object);
        var dto = new BookDto { Id = 1, Title = "Book A", Author = "Author A", PublishedYear = 2020 };

        await service.AddAsync(dto);

        repoMock.Verify(r => r.AddAsync(It.Is<Book>(b => b.Title == "Book A")), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallRepository()
    {
        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetByIdAsync(3)).ReturnsAsync(new Book { Id = 3, Title = "Old", Author = "A", PublishedYear = 2020 });

        var service = new BookService(repoMock.Object);
        await service.UpdateAsync(new BookDto { Id = 3, Title = "Book A Updated", Author = "Author A", PublishedYear = 2021 });

        repoMock.Verify(r => r.UpdateAsync(It.Is<Book>(b => b.Title == "Book A Updated")), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldCallRepository()
    {
        var repoMock = new Mock<IBookRepository>();
        repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new Book { Id = 1, Title = "Book A" });

        var service = new BookService(repoMock.Object);
        await service.DeleteAsync(1);

        repoMock.Verify(r => r.DeleteAsync(It.Is<Book>(b => b.Id == 1)), Times.Once);
    }

}