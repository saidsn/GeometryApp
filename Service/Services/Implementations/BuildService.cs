using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.Build;
using Service.Services.Interfaces;

namespace Service.Services.Implementations
{
    public class BuildService : IBuildService
    {
        private readonly IBuildRepository _buildRepository;
        private readonly IMapper _mapper;

        public BuildService(IBuildRepository buildRepository, IMapper mapper)
        {
            _buildRepository = buildRepository;
            _mapper = mapper;
        }

        public async Task<BuildDto> GetAsync(int id)
        {
            return _mapper.Map<BuildDto>(await _buildRepository.Get(id));
        }
    }
}
