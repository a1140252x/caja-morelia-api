using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class ApiKeyMiddleware {

    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "X-API-KEY";
    private readonly string? _apiKey;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration) {
        _next = next;
        //_apiKey = configuration.GetValue<string>("ApiKey"); // lee desde appsettings.json
        _apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? throw new ArgumentNullException("API_KEY no configurada");
    }

    public async Task InvokeAsync(HttpContext context) {

        if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey)) {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("API Key faltante");
            return;
        }

        if (!string.Equals(_apiKey, extractedApiKey, StringComparison.Ordinal)) {
            context.Response.StatusCode = 403; // Prohibido
            await context.Response.WriteAsync("API Key inválida");
            return;
        }

        await _next(context);

    }
}
