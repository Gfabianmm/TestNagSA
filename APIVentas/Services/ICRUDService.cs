using APIVentas.Extensions;
using System.Threading.Tasks;

namespace APIVentas.Services;

public interface ICRUDService<T, F, R> where F : IQueryFilter where T : IEntity where R : IResource
{
    Task<T?> GetId(F filter);
    Task<List<T>> Get(F filter);
    Task<T> Post(R value);
    Task<T?> Put(R value);
    Task <bool> Delete(R value);
}
