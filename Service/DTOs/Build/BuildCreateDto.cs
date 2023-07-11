using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Build
{
    public class BuildCreateDto
    {
        public IFormFile File { get; set; } = null!;
    }
}
