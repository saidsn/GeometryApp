using Microsoft.AspNetCore.Http;

namespace Service.DTOs.Build
{
    public class BuildUpdateDto
    {
        public IFormFile File { get; set; } = null!;
    }
}
