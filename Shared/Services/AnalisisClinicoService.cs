using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp3.Shared;

public class AnalisisClinicoService
{
    private readonly HttpClient _httpClient;

    public AnalisisClinicoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CrearAnalisisClinico(AnalisisClinico analisisClinico)
    {
        await _httpClient.PostAsJsonAsync("api/AnalisisClinico", analisisClinico);
    }

    public async Task EliminarAnalisisClinico(int id)
    {
        await _httpClient.DeleteAsync($"api/AnalisisClinico/{id}");
    }

    public async Task ActualizarAnalisisClinico(AnalisisClinico analisisClinico)
    {
        await _httpClient.PutAsJsonAsync($"api/AnalisisClinico/{analisisClinico.AnalisisID}", analisisClinico);
    }
}

