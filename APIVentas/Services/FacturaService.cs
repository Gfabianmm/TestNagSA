using APIVentas.DataAccess;
using APIVentas.Models;
using APIVentas.Resources.FacturaProfile;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.Services;

public class FacturaService : ICRUDService<Factura, FacturaQuery, FacturaResource>
{
    private readonly VentasDBContext _context;
    private readonly IMapper _mapper;
    public FacturaService(VentasDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Factura?> GetId(FacturaQuery filter)
        =>
        await _context.Factura.FirstOrDefaultAsync(a => a.IdFactura == filter.IdFactura);

    public async Task<List<Factura>> Get(FacturaQuery filter)
    {
        var _query = _context.Factura.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Estado))
            _query = _query.Where(a => a.Estado == filter.Estado);

        if (!string.IsNullOrEmpty(filter.Cliente))
            _query = _query.Where(a => a.Cliente.Contains(filter.Cliente));

        return await _query.ToListAsync();
    }

    public async Task<Factura?> Put(FacturaResource value)
    {
        var _obj = await _context.Factura.FirstOrDefaultAsync(a => a.IdFactura == value.IdFactura);

        if (_obj == null)
            return null;

        _mapper.Map(value, _obj);


        _obj.FechaModificacion = DateTime.Now;
        _obj.UsuarioModificacion = "sistema";
        _obj.FacturaDetalle.ForEach(a =>
        {
            a.FechaModificacion = DateTime.Now;
            a.UsuarioModificacion = "sistema";
        });

        _obj.FacturaFormaPago.ForEach(a =>
        {
            a.FechaModificacion = DateTime.Now;
            a.UsuarioModificacion = "sistema";
        });

        await _context.SaveChangesAsync();
        return _obj;
    }

    public async Task<Factura> Post(FacturaResource value)
    {
        var _obj = new Factura();
        _mapper.Map(value, _obj);
        _obj.IdFactura = Guid.NewGuid();
        _obj.FechaIngreso = DateTime.Now;
        _obj.UsuarioIngreso = "sistema";

        _obj.FacturaDetalle.ForEach(a =>
        {
            a.Producto = null;
            a.Estado = "A";
            a.FechaIngreso = DateTime.Now;
            a.UsuarioIngreso = "sistema";
        });

        _obj.FacturaFormaPago.ForEach(a =>
        {
            a.Estado = "A";
            a.FormaPago = null;
            a.FechaIngreso = DateTime.Now;
            a.UsuarioIngreso = "sistema";
        });

        await _context.Factura.AddAsync(_obj);
        await _context.SaveChangesAsync();
        return _obj;
    }

    public async Task<bool> Delete(FacturaResource value)
    {
        var _obj = await _context.Factura.FirstOrDefaultAsync(a => a.IdFactura == value.IdFactura);
        if (_obj == null)
            return false;

        _context.Factura.Remove(_obj);
        return true;
    }
}
