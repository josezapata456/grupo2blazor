using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp3.Shared;

public class CitaService
{
    private readonly HttpClient _httpClient;

    public CitaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CrearCita(Cita cita)
    {
        await _httpClient.PostAsJsonAsync("api/Cita", cita);
    }

    public async Task EliminarCita(int id)
    {
        await _httpClient.DeleteAsync($"api/Cita/{id}");
    }

    public async Task ActualizarCita(Cita cita)
    {
        await _httpClient.PutAsJsonAsync($"api/Cita/{cita.CitaID}", cita);
    }
}

