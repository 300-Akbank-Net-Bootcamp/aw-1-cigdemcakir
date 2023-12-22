using Microsoft.AspNetCore.Mvc;
using VbApi.Filters;
using VbApi.Models;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidationFilter]
public class StaffController : ControllerBase
{
    public StaffController()
    {
    }

    [HttpPost]
    public IActionResult Post([FromBody] Staff value)
    {
        return Ok(value);
    }
}