using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class BuildRepository : Repository<Build>, IBuildRepository
    {
        public BuildRepository(POIContext context) : base(context)
        {

        }
    }
}
