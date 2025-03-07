using InfosecLearningSystem_Backend.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InfosecLearningSystem_Backend.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entities", ex);
            }
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _dbSet.Where(expression).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entities", ex);
            }
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Could not retrieve entity with id {id}", ex);
            }
        }

        public async Task<T?> GetFirstWhereAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(expression);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entity", ex);
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not add entity", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not update entity", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found");
                }
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Could not delete entity with id {id}", ex);
            }
        }

        public async Task DeleteWhereAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                var entities = await _dbSet.Where(expression).ToListAsync();
                _dbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not delete entities", ex);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not save changes", ex);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entities", ex);
            }
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _dbSet.Where(expression).ToList();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entities", ex);
            }
        }

        public T? GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Could not retrieve entity with id {id}", ex);
            }
        }

        public T? GetFirstWhere(Expression<Func<T, bool>> expression)
        {
            try
            {
                return _dbSet.FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not retrieve entity", ex);
            }
        }

        public void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not add entity", ex);
            }
        }
        
        public void Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not update entity", ex);
            }
        }
        
        public void Delete(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found");
                }
                _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Could not delete entity with id {id}", ex);
            }
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entities = _dbSet.Where(predicate).ToList();
                _dbSet.RemoveRange(entities);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not delete entities", ex);
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("Could not save changes", ex);
            }
        }
    }

}
