// En BlazorApp3.Shared/MedicoService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp3.Shared;

public class MedicoService
{
    private readonly HttpClient _httpClient;

    public MedicoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CrearMedico(Medico medico)
    {
        await _httpClient.PostAsJsonAsync("api/Medico", medico);
    }

    public async Task EliminarMedico(int id)
    {
        await _httpClient.DeleteAsync($"api/Medico/{id}");
    }

    public async Task ActualizarMedico(Medico medico)
    {
        await _httpClient.PutAsJsonAsync($"api/Medico/{medico.MedicoID}", medico);
    }
    public async Task<Medico> ObtenerMedico(int id)
    {
        return await _httpClient.GetFromJsonAsync<Medico>($"api/Medico/{id}");
    }
}

