// En BlazorApp3.Shared/PacienteService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorApp3.Shared;

public class PacienteService
{
    private readonly HttpClient _httpClient;

    public PacienteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CrearPaciente(Paciente paciente)
    {
        await _httpClient.PostAsJsonAsync("api/Paciente", paciente);
    }

    public async Task EliminarPaciente(int id)
    {
        await _httpClient.DeleteAsync($"api/Paciente/{id}");
    }

    public async Task ActualizarPaciente(Paciente paciente)
    {
        await _httpClient.PutAsJsonAsync($"api/Paciente/{paciente.PacienteID}", paciente);
    }
}
