using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace IntractiveTask.UI.Services;

public class ApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    private HttpClient CreateClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("https://localhost:7256"); // can changed beacuse of port

        var token = _httpContextAccessor.HttpContext?.Session.GetString("JwtToken");
        if (!string.IsNullOrWhiteSpace(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return client;
    }

    // GET
    public async Task<T?> GetAsync<T>(string url)
    {
        var client = CreateClient();
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    // POST
    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
    {
        var client = CreateClient();
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    // PUT
    public async Task<bool> PutAsync<TRequest>(string url, TRequest data)
    {
        var client = CreateClient();
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PutAsync(url, content);
        return response.IsSuccessStatusCode;
    }

    // DELETE
    public async Task<bool> DeleteAsync(string url)
    {
        var client = CreateClient();
        var response = await client.DeleteAsync(url);
        return response.IsSuccessStatusCode;
    }
}