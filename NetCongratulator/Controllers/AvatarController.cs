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
    public IActionResult Create(Avatar newAvatar)
    {
        var avatar = _service.Create(newAvatar);
        return CreatedAtAction(nameof(GetById), new { id = avatar!.Id }, avatar);
    }

    [HttpPut("{id}/updateavatar")]
    public IActionResult UpdateAvatar(int id, string avatarBlob)
    {
        var avatarToUpdate = _service.GetById(id);

        if (avatarToUpdate is not null)
        {
            _service.UpdateAvatar(id, avatarBlob);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
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
