using InfosecLearningSystem_Backend.Domain.MappingProfiles;
using InfosecLearningSystem_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfosecLearningSystem_Backend.Controllers
{
    public class DataController<TModel> : ControllerBase where TModel : class
    {
        protected readonly IDataService<TModel> _dataService;

        public DataController(IDataService<TModel> dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var entities = await _dataService.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _dataService.GetByIdAsync(id);
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TModel entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dataService.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TModel entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (GetEntityId(entity) != id)
            {
                return BadRequest();
            }

            await _dataService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dataService.DeleteAsync(id);
            return NoContent();
        }

        private int GetEntityId(TModel entity)
        {
            var propertyInfo = typeof(TModel).GetProperty("Id");
            return (int)(propertyInfo?.GetValue(entity) ?? 0);
        }
    }
}
