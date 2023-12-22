using Microsoft.AspNetCore.Mvc;
using VbApi.Filters;
using VbApi.Models;

namespace VbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidationFilter]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee value)
    {
        return Ok(value);
    }
}