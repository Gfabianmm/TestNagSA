using TestNagSAApp.Domain.Producto;

namespace TestNagSAApp.Data;

public class ProductoService
{

    private HttpClient _httpClient;
    private IConfiguration _configuration;

    public ProductoService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("url"));
    }

    public async Task<ProductoDTO[]?> GetAsync()
    {
        return await _httpClient.GetFromJsonAsync<ProductoDTO[]>("api/Producto");
    }

    public async Task<Tuple<bool, string?>> PostAsync(ProductoDTO value)
    {
        try
        {

            var response = await _httpClient.PostAsJsonAsync("api/Producto", value);
            return new Tuple<bool, string?>(true, null);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string?>(false, ex.Message);
        }

    }
}