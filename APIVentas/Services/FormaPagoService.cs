using APIVentas.DataAccess;
using APIVentas.Models;
using APIVentas.Resources.FormaPagoProfile;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVentas.Services;

public class FormaPagoService : ICRUDService<FormaPago, FormaPagoQuery, FormaPagoResource>
{
    private readonly VentasDBContext _context;
    private readonly IMapper _mapper;
    public FormaPagoService(VentasDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FormaPago?> GetId(FormaPagoQuery filter)
        => 
        await _context.FormaPago.FirstOrDefaultAsync(a => a.IdFormaPago == filter.IdFormaPago);

    public async Task<List<FormaPago>> Get(FormaPagoQuery filter)
    {
        var _query = _context.FormaPago.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Estado))
            _query = _query.Where(a => a.Estado == filter.Estado);

        if (!string.IsNullOrEmpty(filter.Descripcion))
            _query = _query.Where(a => a.Descripcion.Contains(filter.Descripcion));

        return await _query.ToListAsync();
    }

    public async Task<FormaPago?> Put(FormaPagoResource value)
    {
        var _formaPago = await _context.FormaPago.FirstOrDefaultAsync(a => a.IdFormaPago == value.IdFormaPago);

        if (_formaPago == null)
            return null;

        _mapper.Map(value,_formaPago);

        _formaPago.FechaModificacion = DateTime.Now;
        _formaPago.UsuarioModificacion = "sistema";
        await _context.SaveChangesAsync();
        return _formaPago;
    }

    public async Task<FormaPago> Post(FormaPagoResource value)
    {
        var _formaPago = new FormaPago();
        _mapper.Map(value, _formaPago);

        _formaPago.FechaIngreso = DateTime.Now;
        _formaPago.UsuarioIngreso = "sistema";
        
        _formaPago.IdFormaPago = Guid.NewGuid();

        await _context.FormaPago.AddAsync(_formaPago);
        await _context.SaveChangesAsync();
        return _formaPago;
    }

    public async Task<bool> Delete(FormaPagoResource value)
    {
        var _formaPago = await _context.FormaPago.FirstOrDefaultAsync(a => a.IdFormaPago == value.IdFormaPago);
        if (_formaPago == null)
            return false;

        _context.FormaPago.Remove(_formaPago);
        return true;
    }

}
