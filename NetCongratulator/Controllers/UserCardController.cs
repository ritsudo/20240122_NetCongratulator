using NetCongratulator.Services;
using NetCongratulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]

public class UserCardController : ControllerBase
{
    UserCardService _service;

    public UserCardController(UserCardService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<UserCard> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<UserCard> GetById(int id)
    {
        var userCard = _service.GetById(id);

        if (userCard is not null)
        {
            return userCard;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Create(UserCard newUserCard)
    {
        var userCard = _service.Create(newUserCard);
        return CreatedAtAction(nameof(GetById), new { id = userCard!.Id }, userCard);
    }

    [HttpPut("{id}/updatedata")]
    public IActionResult UpdateData(int id, string UserCardName, string UserCardSurname, DateTime UserCardDateTime)
    {
        var userCardToUpdate = _service.GetById(id);

        if(userCardToUpdate is not null)
        {
            _service.UpdateData(id, UserCardName, UserCardSurname, UserCardDateTime);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}/updateavatar")]
    public IActionResult UpdateAvatar(int id, int avatarId)
    {
        var userCardToUpdate = _service.GetById(id);

        if(userCardToUpdate is not null)
        {
            _service.UpdateAvatar(id, avatarId);
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
        var userCard = _service.GetById(id);

        if(userCard is not null)
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