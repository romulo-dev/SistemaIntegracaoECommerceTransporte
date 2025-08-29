using System.Text.Json;

namespace ECommerceInterno.Services;

public class ExternalApiService : IExternalApiService
{
    private readonly HttpClient _http;
    public ExternalApiService(HttpClient http) => _http = http;

    public async Task<T?> GetAsync<T>(string path, CancellationToken ct = default)
    {
        var resp = await _http.GetAsync(path, ct);
        resp.EnsureSuccessStatusCode();
        using var stream = await resp.Content.ReadAsStreamAsync(ct);
        return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, ct);
    }
}
