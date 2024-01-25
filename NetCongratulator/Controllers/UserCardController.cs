using NetCongratulator.Services;
using NetCongratulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]

public class UserCardController(UserCardService service) : ControllerBase
{
    private readonly UserCardService _service = service;

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
    public async Task<IActionResult> Create(UserCard newUserCard)
    {
        var userCard = await _service.Create(newUserCard);
        return CreatedAtAction(nameof(GetById), new { id = userCard!.Id }, userCard);
    }

    [HttpPut("{id}/updatedata")]
    public async Task<IActionResult> UpdateData(int id, string FirstName, string LastName, DateTime BirthdayDate)
    {
        var userCardToUpdate = _service.GetById(id);

        if(userCardToUpdate is not null)
        {
            userCardToUpdate.FirstName = FirstName;
            userCardToUpdate.LastName = LastName;
            userCardToUpdate.BirthdayDate = BirthdayDate;

            await _service.UpdateDataByCard(userCardToUpdate);
            return NoContent();    
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userCard = _service.GetById(id);

        if(userCard is not null)
        {
            await _service.DeleteById(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

}