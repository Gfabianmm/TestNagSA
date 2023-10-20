using APIVentas.DataAccess;
using APIVentas.Models;
using APIVentas.Resources.ProductoProfile;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.Services;

public class ProductoService : ICRUDService<Producto, ProductoQuery, ProductoResource>
{
    private readonly VentasDBContext _context;
    private readonly IMapper _mapper;
    public ProductoService(VentasDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Producto?> GetId(ProductoQuery filter)
        =>
        await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == filter.IdProducto);

    public async Task<List<Producto>> Get(ProductoQuery filter)
    {
        var _query = _context.Producto.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Estado))
            _query = _query.Where(a => a.Estado == filter.Estado);

        if (!string.IsNullOrEmpty(filter.Descripcion))
            _query = _query.Where(a => a.Descripcion.Contains(filter.Descripcion));

        return await _query.ToListAsync();
    }

    public async Task<Producto?> Put(ProductoResource value)
    {
        var _obj = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == value.IdProducto);

        if (_obj == null)
            return null;

        _mapper.Map(value, _obj);


        _obj.FechaModificacion = DateTime.Now;
        _obj.UsuarioModificacion = "sistema";
        await _context.SaveChangesAsync();
        return _obj;
    }

    public async Task<Producto> Post(ProductoResource value)
    {
        var _obj = new Producto();
        _mapper.Map(value, _obj);


        _obj.FechaIngreso = DateTime.Now;
        _obj.UsuarioIngreso = "sistema";


        _obj.IdProducto = await ObtenerSecuencial();

        await _context.Producto.AddAsync(_obj);
        await _context.SaveChangesAsync();
        return _obj;
    }

    public async Task<bool> Delete(ProductoResource value)
    {
        var _obj = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == value.IdProducto);
        if (_obj == null)
            return false;

        _context.Producto.Remove(_obj);
        return true;
    }


    private async Task<string> ObtenerSecuencial()
    {

        /// TODO: Lo ideal es obtenerlo de una tabla de secuenciales, por tiempo no se hará
        /*
        var _secuencial = await _context.Secuencial.FirstOrDefaultAsync(a => a.IdSecuencial == 1);
        _secuencial.Secuencial = _secuencial.Secuencial + 1;
        await _context.SaveChangesAsync();
        return _secuencial.Secuencial.ToString().PadLeft(10, '0');
        */

        /// TODO: Para hacerlo más rápido, cuento la cantidad de registros y le sumo 1 para generar un secuencial
        
        return $"PV{((await _context.Producto.CountAsync())+1).ToString("D3")}";

    }
}
