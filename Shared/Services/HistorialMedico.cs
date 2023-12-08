using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp3.Shared;

public class HistorialMedicoService
{
    private readonly HttpClient _httpClient;

    public HistorialMedicoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CrearHistorialMedico(HistorialMedico historialMedico)
    {
        await _httpClient.PostAsJsonAsync("api/HistorialMedico", historialMedico);
    }

    public async Task EliminarHistorialMedico(int id)
    {
        await _httpClient.DeleteAsync($"api/HistorialMedico/{id}");
    }

    public async Task ActualizarHistorialMedico(HistorialMedico historialMedico)
    {
        await _httpClient.PutAsJsonAsync($"api/HistorialMedico/{historialMedico.HistorialID}", historialMedico);
    }
}

