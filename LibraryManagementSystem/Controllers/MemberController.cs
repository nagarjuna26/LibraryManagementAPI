using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController(IMemberService service) : ControllerBase
    {
        private readonly IMemberService _service = service;

        /// <summary>
        /// Retrieves all members from the system.
        /// </summary>
        /// <returns>A list of <see cref="MemberDto"/> representing all members.</returns>
        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        /// <summary>
        /// Retrieves a member by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>The <see cref="MemberDto"/> if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetById(int id)
        {
            var member = await _service.GetByIdAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        /// <summary>
        /// Creates a new member in the system.
        /// </summary>
        /// <param name="dto">The member data transfer object containing member details.</param>
        /// <returns>A response with the location of the created member.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(MemberDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Updates an existing member's information.
        /// </summary>
        /// <param name="id">The unique identifier of the member to update.</param>
        /// <param name="dto">The updated member data transfer object.</param>
        /// <returns>No content if successful; otherwise, BadRequest if the IDs do not match.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MemberDto dto)
        {
            if (id != dto.Id) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a member from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the member to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
