using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly POIContext _context;
        private readonly DbSet<T> _entities;

        public Repository(POIContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<T> Get(int id)
        {
            var data = await _entities.FindAsync(id) ?? throw new NullReferenceException();
            return data;
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Create(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            await _entities.AddAsync(entity);

            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Remove(entity);

            await SaveAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            _entities.Update(entity);

            await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T> GetLast()
        {
            var data = await _entities.OrderByDescending(e => e.Id).FirstOrDefaultAsync() ?? throw new NullReferenceException();
            return data;
        }
    }
}
