using Anime_store.Data;
using Anime_store.Exceptions;
using Anime_store.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Anime_store.Services
{
    public class DbService<T> : IDbService<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public DbService(ApplicationDbContext context)
        {
            _context = context;
        }

        // <inheritdoc />
        public async Task<bool> Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _context.Set<T>().AddAsync(entity);

            int result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                throw new FailedToCreateException<T>();
            }

            return true;
        }

        // <inheritdoc />
        public async Task<List<T>> GetAll()
        {
            List<T> entities = await _context.Set<T>().ToListAsync();

            if (entities.Count == 0)
            {
                throw new NoDataFoundException();
            }

            return entities;
        }

        // <inheritdoc />
        public async Task<T?> Get(int id)
        {
            ArgumentNullException.ThrowIfNull(id);

            T? entity = await _context.Set<T>().FindAsync(id);
            return entity ?? throw new NoDataFoundException();
        }

        // <inheritdoc />
        public async Task<bool> Update(T entity)
        {
            T? existingEntity = await _context.Set<T>().FindAsync(entity) ?? throw new NullReferenceException();
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            int result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                throw new FailedToUpdateException<T>();
            }

            return true;
        }

        // <inheritdoc />
        public async Task<bool> Delete(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id) ?? throw new NullReferenceException();
            _context.Set<T>().Remove(entity);
            int result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                throw new FailedToDeleteException<T>();
            }

            return true;
        }
    }
}
