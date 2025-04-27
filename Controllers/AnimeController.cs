using aniwiki_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aniwiki_backend.Controllers;

public class AnimeController : ControllerBase
{
    private readonly JikanService _jikanService;

    public AnimeController(JikanService jikanService)
    {
        _jikanService = jikanService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SerachAnimeAsync(string query)
    {
        var result = await _jikanService.SearchAnimeAsync(query);
        return Content(result, "application/json");
    }
}