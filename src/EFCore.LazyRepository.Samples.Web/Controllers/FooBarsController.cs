using AutoMapper;
using EFCore.LazyRepository.Interfaces.UnitOfWork;
using EFCore.LazyRepository.Samples.Data.Entities;
using EFCore.LazyRepository.Samples.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.LazyRepository.Samples.Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class FooBarsController : Controller
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;

        public FooBarsController(IUoW uoW, IMapper mapper)
        {
            _uoW = uoW;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FooBarDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var entities = await _uoW.Repositories[nameof(FooBar)].Get<FooBar>().ToListAsync();
            var dtos = _mapper.Map<IEnumerable<FooBarDto>>(entities);

            return this.Ok(dtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<FooBarDto>), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _uoW.Repositories[nameof(FooBar)].Get<FooBar>()
                                                                .Where(w => w.Id == id)
                                                                .FirstOrDefaultAsync();
            var dto = _mapper.Map<FooBarDto>(entity);

            return this.Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FooBarDto), 200)]
        public async Task<IActionResult> Post([FromBody] FooBarDto dto)
        {
            var entity = _mapper.Map<FooBar>(dto);

            _uoW.Repositories[nameof(FooBar)].Add(entity);
            await _uoW.Commit();

            dto.Id = entity.Id;

            return this.Ok(dto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(FooBarDto), 200)]
        public async Task<IActionResult> Put([FromBody] FooBarDto dto)
        {
            var entity = await _uoW.Repositories[nameof(FooBar)].Get<FooBar>()
                                                                .Where(w => w.Id == dto.Id)
                                                                .FirstOrDefaultAsync();

            entity.Foo = dto.Foo;
            entity.Bar = dto.Bar;

            _uoW.Repositories[nameof(FooBar)].Update(entity);
            await _uoW.Commit();

            return this.Ok(dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _uoW.Repositories[nameof(FooBar)].Get<FooBar>(w => w.Id == id).FirstOrDefaultAsync();

            _uoW.Repositories[nameof(FooBar)].Remove(entity);
            await _uoW.Commit();

            return this.Ok();
        }
    }
}
