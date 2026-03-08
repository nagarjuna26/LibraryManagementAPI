using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController(ITransactionService service) : ControllerBase
    {
        private readonly ITransactionService _service = service;

        /// <summary>
        /// Retrieves all transactions.
        /// </summary>
        /// <returns>A list of all transaction DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<List<TransactionDto>>> GetAll() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Retrieves a transaction by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the transaction to retrieve.</param>
        /// <returns>The transaction DTO if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetById(int id)
        {
            var transaction = await _service.GetByIdAsync(id);
            if (transaction == null) return NotFound();
            return Ok(transaction);
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="dto">The transaction DTO to create.</param>
        /// <returns>The created transaction DTO with a location header.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(TransactionDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="id">The ID of the transaction to update.</param>
        /// <param name="dto">The updated transaction DTO.</param>
        /// <returns>No content if successful; otherwise, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TransactionDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a transaction by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the transaction to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
