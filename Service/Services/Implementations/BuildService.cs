using AutoMapper;
using Repository;
using Repository.Repositories.Interfaces;
using Service.DTOs.Build;
using Service.Extentions;
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

        public async Task CreateAsync(BuildCreateDto buildCreateDto)
        {
            Build building = buildCreateDto.File.ConvertGeoJsonToObject<Build>();

            await _buildRepository.Create(_mapper.Map<Build>(building));
        }

        public async Task DeleteAsync(int id)
        {
            await _buildRepository.Delete(await _buildRepository.Get(id));
        }

        public async Task<List<BuildListDto>> GetAllAsync()
        {
            return _mapper.Map<List<BuildListDto>>(await _buildRepository.GetAll());
        }

        public async Task<BuildDto> GetAsync(int id)
        {
            return _mapper.Map<BuildDto>(await _buildRepository.Get(id));
        }

        public async Task<BuildDto> GetLastAsync()
        {
            return _mapper.Map<BuildDto>(await _buildRepository.GetLast());
        }

        public async Task UpdateAsync(int id, BuildUpdateDto buildUpdateDto)
        {
            var dbBuild = await _buildRepository.Get(id);

            Build building = buildUpdateDto.File.ConvertGeoJsonToObject<Build>();

            _mapper.Map(building, dbBuild);

            await _buildRepository.Update(dbBuild);
        }
    }
}
