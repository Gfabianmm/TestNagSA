using APIVentas.Models;
using APIVentas.Resources.FacturaProfile;
using APIVentas.Resources.ProductoProfile;
using APIVentas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIVentas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{

    private readonly ICRUDService<Factura, FacturaQuery, FacturaResource> _service;
    private readonly IMapper _mapper;
    public FacturaController(ICRUDService<Factura, FacturaQuery, FacturaResource> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<FacturaResource>>> Get([FromQuery] FacturaQuery filter)
    {
        try
        {
            return Ok(_mapper.Map<List<FacturaResource>>(await _service.Get(filter)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<FacturaResource>> Get(Guid id)
    {
        try
        {
            return Ok(_mapper.Map<FacturaResource>(await _service.GetId(new FacturaQuery(id))));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost]
    public async Task<ActionResult<FacturaResource>> Post([FromBody] FacturaResource value)
    {
        try
        {
            return Ok(_mapper.Map<FacturaResource>(await _service.Post(value)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FacturaResource>> Put(Guid id, [FromBody] FacturaResource value)
    {
        try
        {
            if (id != value.IdFactura)
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
            if (!await _service.Delete(new FacturaResource(id)))
                return NotFound();

            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
