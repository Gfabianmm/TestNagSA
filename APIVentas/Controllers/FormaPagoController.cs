using APIVentas.Models;
using APIVentas.Resources.FormaPagoProfile;
using APIVentas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIVentas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FormaPagoController : ControllerBase
{

    private readonly ICRUDService<FormaPago, FormaPagoQuery, FormaPagoResource> _service;
    private readonly IMapper _mapper;
    public FormaPagoController(ICRUDService<FormaPago, FormaPagoQuery, FormaPagoResource> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<FormaPagoResource>>> Get(FormaPagoQuery filter)
    {
        try
        {
            return Ok(_mapper.Map<List<FormaPagoResource>>(await _service.Get(filter)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<FormaPagoResource>> Get(Guid id)
    {
        try
        {
            return Ok(_mapper.Map<FormaPagoResource>(await _service.GetId(new FormaPagoQuery() { IdFormaPago = id })));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost]
    public async Task<ActionResult<FormaPagoResource>> Post([FromBody] FormaPagoResource value)
    {
        try
        {
            return Ok(_mapper.Map<FormaPagoResource>(await _service.Post(value)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FormaPagoResource>> Put(Guid id, [FromBody] FormaPagoResource value)
    {
        try
        {
            if (id != value.IdFormaPago)
                return BadRequest("El id no coincide con el objeto");

            var _obj = await _service.Put(value);

            if (_obj == null)
                return NotFound();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    ///TODO: Esto es solo un ejemplo de eliminacion, no se debe eliminar físicamente los registros de la base de datos
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            if (!await _service.Delete(new FormaPagoResource(id)))
                return NotFound();

            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
