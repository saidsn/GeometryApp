using Service.DTOs.Build;

namespace Service.Services.Interfaces
{
    public interface IBuildService
    {
        Task<BuildDto> GetAsync(int id);
    }
}
