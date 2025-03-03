using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfosecLearningSystem_Backend.Services.Interfaces
{
    public interface IDataService<TDTO> where TDTO : class
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO?> GetByIdAsync(int id);
        Task AddAsync(TDTO entity);
        Task UpdateAsync(TDTO entity);
        Task DeleteAsync(int id);
        IEnumerable<TDTO> GetAll();
        TDTO? GetById(int id);
        void Add(TDTO entity);
        void Delete(int id);
        void Update(TDTO entity);
    }
}
