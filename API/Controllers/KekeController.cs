using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keke.Controllers;

[Route("api/[controller]")]
public class KekeController : ApiController
{
    [HttpGet]
    [Authorize]
    public IActionResult ListKekes()
    {
        return Ok(Array.Empty<string>());
    }
}