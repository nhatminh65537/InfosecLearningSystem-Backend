using InfosecLearningSystem_Backend.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfosecLearningSystem_Backend.Application.Interfaces;
using AutoMapper;
using InfosecLearningSystem_Backend.Domain.MappingProfiles;

namespace InfosecLearningSystem_Backend.Application.Services
{
    public class DataService<TModel, TDTO> : IDataService<TDTO> 
        where TDTO : class
        where TModel : class
    {
        protected readonly IRepository<TModel> _repository;
        protected readonly IMapper _mapper;

        public DataService(IRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
        { 
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDTO>>(entities);
        }

        public IMapper Get_mapper()
        {
            return _mapper;
        }

        public async Task<TDTO?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDTO>(entity);
        }

        public async Task AddAsync(TDTO entity)
        {
            await _repository.AddAsync(_mapper.Map<TModel>(entity));
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(TDTO entity)
        {
            await _repository.UpdateAsync(_mapper.Map<TModel>(entity));
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }

        public IEnumerable<TDTO> GetAll()
        {
            var entities = _repository.GetAll();
            return _mapper.Map<IEnumerable<TDTO>>(entities);
        }

        public TDTO? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<TDTO>(entity);
        }

        public void Add(TDTO entity)
        {
            _repository.Add(_mapper.Map<TModel>(entity));
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public void Update(TDTO entity)
        {
            _repository.Update(_mapper.Map<TModel>(entity));
            _repository.Save();
        }
    }
}
