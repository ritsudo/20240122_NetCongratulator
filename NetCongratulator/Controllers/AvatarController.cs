using NetCongratulator.Models;
using NetCongratulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]
public class AvatarController : ControllerBase
{
    AvatarService _service;

    public AvatarController(AvatarService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Avatar> GetById(int id)
    {
        var avatar = _service.GetById(id);

        if (avatar is not null)
        {
            return avatar;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(IFormFile file)
    {
        var avatar = _service.Create(file);
        return CreatedAtAction(nameof(GetById), new { id = avatar!.Id }, avatar);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var avatar = _service.GetById(id);

        if (avatar is not null)
        {
            _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}
