namespace ECommerceInterno.Services;

public interface IExternalApiService
{
    Task<T?> GetAsync<T>(string path, CancellationToken ct = default);
}
