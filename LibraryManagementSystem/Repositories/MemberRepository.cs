using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository(LibraryDbContext context) : IMemberRepository
    {
        private readonly LibraryDbContext _context = context;

        /// <summary>
        /// Retrieves all members from the database asynchronously.
        /// </summary>
        /// <returns>A list of all <see cref="Member"/> entities.</returns>
        public async Task<List<Member>> GetAllAsync()
        {
            return await _context.Members.ToListAsync();
        }

        /// <summary>
        /// Retrieves a member by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the member.</param>
        /// <returns>The <see cref="Member"/> entity if found; otherwise, <c>null</c>.</returns>
        public async Task<Member?> GetByIdAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        /// <summary>
        /// Adds a new member to the database asynchronously.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> entity to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing member in the database asynchronously.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task UpdateAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a member from the database asynchronously.
        /// </summary>
        /// <param name="member">The <see cref="Member"/> entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task DeleteAsync(Member member)
        {
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
        }
    }

}
