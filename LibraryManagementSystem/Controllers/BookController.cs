using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(IBookService service) : ControllerBase
    {
        private readonly IBookService _service = service;

        /// <summary>
        /// Retrieves all books from the system.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing a list of all books.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retrieves a book by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the book.</param>
        /// <returns>An <see cref="IActionResult"/> containing the book if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _service.GetByIdAsync(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        /// <summary>
        /// Adds a new book to the system.
        /// </summary>
        /// <param name="dto">The data transfer object containing book information.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(BookDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Updates an existing book in the system.
        /// </summary>
        /// <param name="id">The unique identifier of the book to update.</param>
        /// <param name="dto">The data transfer object containing updated book information.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a book from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the book to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
