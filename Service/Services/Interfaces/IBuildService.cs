using Service.DTOs.Build;

namespace Service.Services.Interfaces
{
    public interface IBuildService
    {
        Task<BuildDto> GetAsync(int id);
        Task<List<BuildListDto>> GetAllAsync();
        Task CreateAsync(BuildCreateDto buildCreateDto);
        Task UpdateAsync(int id, BuildUpdateDto buildUpdateDto);
        Task DeleteAsync(int id);
        Task<BuildDto> GetLastAsync();
    }
}

