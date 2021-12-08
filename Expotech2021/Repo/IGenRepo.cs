using System.Collections.Generic;
using System.Threading.Tasks;
using Expotech2021.models;
using Microsoft.EntityFrameworkCore;

namespace Expotech2021.Repo
{
    public interface IGenRepo<T> where T : class, IModelBase
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }


    public class GenRepo<T> : IGenRepo<T> where T : class, IModelBase 
    {
        private readonly ApplicationBDContext _context;

        protected GenRepo(ApplicationBDContext context)
        {
            this._context = context;
        }

        async Task<T> IGenRepo<T>.Add(T entity)
        {

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        async Task<T> IGenRepo<T>.Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        async Task<T> IGenRepo<T>.Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        async Task<List<T>> IGenRepo<T>.GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        async Task<T> IGenRepo<T>.Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
