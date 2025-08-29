namespace ECommerceInterno.Services;

public interface IExternalApiService
{
    Task<T?> GetAsync<T>(string path, CancellationToken ct = default);

    // public async Task<T?> GetAsync<T>(string endpoint)
    // {
    //     var response = await _httpClient.GetAsync(endpoint);
    //     response.EnsureSuccessStatusCode();
    //     var json = await response.Content.ReadAsStringAsync();
    //     return JsonSerializer.Deserialize<T>(json);
    // }
}
