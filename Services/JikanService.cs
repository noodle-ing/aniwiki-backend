using Newtonsoft.Json.Linq;

namespace aniwiki_backend.Services;

public class JikanService
{
    private readonly HttpClient _httpClient;

    public JikanService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.jikan.moe/v4/");
    }


    public async Task<string> SearchAnimeAsync(string query, int page)
    {
        var response = await _httpClient.GetAsync($"anime?q={query}&page={page}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }

    public async Task<string> SearchAnimeById(string id)
    {
        var response = await _httpClient.GetAsync($"anime/{id}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return content;
    }
    
    public async Task<List<dynamic>> GetTopAnime()
    {
        var response = await _httpClient.GetStringAsync("https://api.jikan.moe/v4/top/anime");

        var jsonResponse = JObject.Parse(response);

        var topAnime = jsonResponse["data"]
            .OrderByDescending(a => (double)a["score"])
            .Take(10)
            .Select(a => new
            {
                Title = a["title"].ToString(),
                Score = (double)a["score"],
                Rank = (int)a["rank"],
                ImageUrl = a["images"]["jpg"]["image_url"].ToString(),
                Synopsis = a["synopsis"]?.ToString() 
            })
            .ToList();

        return topAnime.Cast<dynamic>().ToList();
    }
}