using APIVentas.Models;
using APIVentas.Resources.ProductoProfile;
using APIVentas.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIVentas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{

    private readonly ICRUDService<Producto, ProductoQuery, ProductoResource> _service;
    private readonly IMapper _mapper;
    public ProductoController(ICRUDService<Producto, ProductoQuery, ProductoResource> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductoResource>>> Get(ProductoQuery filter)
    {
        try
        {
            return Ok(_mapper.Map<List<ProductoResource>>(await _service.Get(filter)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoResource>> Get(string id)
    {
        try
        {
            return Ok(_mapper.Map<ProductoResource>(await _service.GetId(new ProductoQuery(id))));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }


    [HttpPost]
    public async Task<ActionResult<ProductoResource>> Post([FromBody] ProductoResource value)
    {
        try
        {
            return Ok(_mapper.Map<ProductoResource>(await _service.Post(value)));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductoResource>> Put(string id, [FromBody] ProductoResource value)
    {
        try
        {
            if (id != value.IdProducto)
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
    public async Task<ActionResult> Delete(string id)
    {
        try
        {
            if (!await _service.Delete(new ProductoResource(id)))
                return NotFound();

            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
