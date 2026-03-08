using LibraryManagementSystem.DTOs;

namespace LibraryManagementSystem.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllAsync();
        Task<MemberDto?> GetByIdAsync(int id);
        Task AddAsync(MemberDto dto);
        Task UpdateAsync(MemberDto dto);
        Task DeleteAsync(int id);
    }

}
