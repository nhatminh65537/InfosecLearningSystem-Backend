using System.Linq.Expressions;

namespace InfosecLearningSystem_Backend.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>>  expression);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetFirstWhereAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteWhereAsync(Expression<Func<T, bool>> expression);
        Task SaveAsync();

        IEnumerable<T> GetAll();
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> expression);
        T? GetById(int id);
        T? GetFirstWhere(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Delete(int id);
        void DeleteWhere(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Save();
    }
}