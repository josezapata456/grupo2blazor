
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorApp3.Shared;

namespace BlazorApp3.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            /*builder.Services.AddScoped<PacienteService>();
            builder.Services.AddScoped<MedicoService>();
            builder.Services.AddScoped<CitaService>();
            builder.Services.AddScoped<HistorialMedicoService>();
            builder.Services.AddScoped<AnalisisClinicoService>();*/

           await builder.Build().RunAsync();
        }
    }
}

