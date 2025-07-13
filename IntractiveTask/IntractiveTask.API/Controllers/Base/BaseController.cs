using AutoMapper;
using IntractiveTask.Entity.Dtos.Base;
using IntractiveTask.Entity.Helpers;
using IntractiveTask.Entity.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.API.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TModel, TDto, TCreateDto, TUpdateDto, TDeleteDto> : ControllerBase
        where TModel : class, ISoftDelete
        where TDto : BaseDto
        where TCreateDto : BaseCreateDto
        where TUpdateDto : BaseUpdateDto
        where TDeleteDto : BaseDeleteDto

{
    protected readonly IManager<TModel> _manager;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService;


    public BaseController(IManager<TModel> manager, IMapper mapper, ICacheService cacheService)
    {
        _manager = manager;
        _mapper = mapper;
        _cacheService = cacheService;


    }

    // GET: api/[controller]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
    {
        string cacheKey = typeof(TModel)
            + "-" + "[GetAll]";

        //var cachedData = await _cacheService.GetAsync<List<TDto>>(cacheKey);
        //if (cachedData != null)
        //{
        //    return Ok(cachedData);
        //}

        var result = await _manager.GetAllAsync();
        var dtoResult = _mapper.Map<List<TDto>>(result);

        string modelName = typeof(TModel).Name;

        await _cacheService.SetAsync(cacheKey, dtoResult, CacheHelper.GetCacheExpirationForModel(modelName));
        return Ok(dtoResult);
    }

    // GET: api/[controller]/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TDto>> GetById(int id)
    {
        var entity = await _manager.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        var dto = _mapper.Map<TDto>(entity);
        return Ok(dto);
    }

    // POST: api/[controller]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] TCreateDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid entity");

        var entity = _mapper.Map<TModel>(dto);
        await _manager.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity }, dto);
    }

    // PUT: api/[controller]
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] TUpdateDto dto)
    {
        if (dto == null)
            return BadRequest("Invalid entity");

        var entity = _mapper.Map<TModel>(dto);
        await _manager.UpdateAsync(entity);
        return Ok(entity);
    }

    // DELETE: api/[controller]/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var entity = await _manager.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        entity.IsDeleted = true;
        entity.IsActive = false;
        entity.DeletedDate = DateTime.Now;

        await _manager.RemoveAsync(entity);
        return Ok();
    }
}
