namespace InfosecLearningSystem_Backend.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();

        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
    }
}