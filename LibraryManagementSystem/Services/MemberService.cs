using LibraryManagementSystem.DTOs;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using LibraryManagementSystem.Services.Interfaces;

namespace LibraryManagementSystem.Services
{
    public class MemberService(IMemberRepository repository) : IMemberService
    {
        private readonly IMemberRepository _repository = repository;

        /// <summary>
        /// Retrieves all members from the repository and maps them to MemberDto objects.
        /// </summary>
        /// <returns>A list of MemberDto representing all members.</returns>
        public async Task<List<MemberDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();
            return [.. members.Select(m => new MemberDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    PhoneNumber = m.PhoneNumber
                })];
        }

        /// <summary>
        /// Retrieves a member by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>A MemberDto if found; otherwise, null.</returns>
        public async Task<MemberDto?> GetByIdAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);
            if (member == null) return null;

            return new MemberDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber
            };
        }

        /// <summary>
        /// Adds a new member to the repository.
        /// </summary>
        /// <param name="dto">The MemberDto containing member information.</param>
        /// <exception cref="ArgumentNullException">Thrown if dto, Name, or Email is null.</exception>
        public async Task AddAsync(MemberDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "MemberDto cannot be null.");

            if (dto.Name == null)
                throw new ArgumentNullException(nameof(dto), "Name cannot be null.");

            if (dto.Email == null)
                throw new ArgumentNullException(nameof(dto), "Email cannot be null.");

            var member = new Member
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                JoinedDate = DateTime.UtcNow,
                Transactions = new List<Transaction>()
            };
            await _repository.AddAsync(member);
        }

        /// <summary>
        /// Updates an existing member in the repository.
        /// </summary>
        /// <param name="dto">The MemberDto containing updated member information.</param>
        /// <exception cref="ArgumentNullException">Thrown if dto, Name, or Email is null.</exception>
        public async Task UpdateAsync(MemberDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "MemberDto cannot be null.");
            if (dto.Name == null)
                throw new ArgumentNullException(nameof(dto), "Name cannot be null.");
            if (dto.Email == null)
                throw new ArgumentNullException(nameof(dto), "Email cannot be null.");

            var member = new Member
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                JoinedDate = DateTime.UtcNow,
                Transactions = new List<Transaction>()
            };
            await _repository.UpdateAsync(member);
        }

        /// <summary>
        /// Deletes a member from the repository by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the member to delete.</param>
        public async Task DeleteAsync(int id)
        {
            var member = await _repository.GetByIdAsync(id);
            if (member != null)
                await _repository.DeleteAsync(member);
        }
    }

}
