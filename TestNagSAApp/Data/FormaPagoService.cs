using Microsoft.AspNetCore.Components;
using System.ComponentModel.Design;
using System.Net.Http;
using TestNagSAApp.Domain.FormaPago;

namespace TestNagSAApp.Data;

public class FormaPagoService
{

    private HttpClient _httpClient;
    private IConfiguration _configuration;

    public FormaPagoService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("url"));
    }

    public async Task<FormaPagoDTO[]?> GetAsync()
    {
        return await _httpClient.GetFromJsonAsync<FormaPagoDTO[]>("api/FormaPago");
    }

    public async Task<Tuple<bool, string?>> PostAsync(FormaPagoDTO value)
    {
        try
        {

            var response = await _httpClient.PostAsJsonAsync("api/FormaPago", value);
            return new Tuple<bool, string?>(true, null);
        }
        catch (Exception ex)
        {
            return new Tuple<bool, string?>(false, ex.Message);
        }

    }
}