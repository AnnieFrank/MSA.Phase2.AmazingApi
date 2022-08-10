using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.AmazingApi.model;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly HttpClient _client;
    /// <summary />
    public PokemonController(IHttpClientFactory clientFactory)
    {
        if (clientFactory is null)
        {
            throw new ArgumentNullException(nameof(clientFactory));
        }
        _client = clientFactory.CreateClient("pokemon");
    }
    /// <summary>
    /// Gets the raw JSON for the given pokemon name
    /// </summary>
    /// <returns>A JSON object representing the pokemon name/returns>
    [HttpGet("{name}")]
    [Route("raw")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetByName(string name)
    {
        var res = await _client.GetAsync("/api/v2/pokemon/"+name);
        var content = await res.Content.ReadAsStringAsync();
        return Ok(content);
    }
}