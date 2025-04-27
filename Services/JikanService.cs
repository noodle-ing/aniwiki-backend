namespace aniwiki_backend.Services;

public class JikanService
{
    private readonly HttpClient _httpClient;

    public JikanService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.jikan.moe/v4/");
    }

    public async Task<string> SearchAnimeAsync(string query)
    {
        var response = await _httpClient.GetAsync($"anime?q={query}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
}