using Microsoft.AspNetCore.Mvc;
using aniwiki_backend.Services;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly JikanService _jikanService;

    public AnimeController(JikanService jikanService)
    {
        _jikanService = jikanService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAnime(string query, int page)
    {
        var result = await _jikanService.SearchAnimeAsync(query, page);
        return Content(result, "application/json");
    }

    [HttpGet("anime/{id}")]
    public async Task<IActionResult> GetAnime(string id)
    {
        var result = await _jikanService.SearchAnimeById(id);
        return Content(result, "application/json");
    }
    
    
}