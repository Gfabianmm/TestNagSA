using TestNagSAApp.Domain.Factura;
using TestNagSAApp.Domain.Producto;

namespace TestNagSAApp.Data;

public class FacturaService
{

    private HttpClient _httpClient;
    private IConfiguration _configuration;

    public FacturaService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("url"));
    }

    public async Task<FacturaDTO[]?> GetAsync()
    {
        return await _httpClient.GetFromJsonAsync<FacturaDTO[]>("api/Factura");
    }

    public async Task<Tuple<bool, string?>> PostAsync(FacturaDTO value)
    {
        try
        {

            var response = await _httpClient.PostAsJsonAsync("api/Factura", value);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new Tuple<bool, string?>(true, null);
            }
            else
            {
                var error=await response.Content.ReadAsStringAsync();
                return new Tuple<bool, string?>(false, error);
            }
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string?>(false, ex.Message);
        }

    }
}