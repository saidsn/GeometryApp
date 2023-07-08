using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class PoiReository : Repository<Poi>, IPoiRepository
    {
        public PoiReository(POIContext context) : base(context)
        {

        }
    }
}
