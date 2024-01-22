using NetCongratulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]
public class AvatarController : ControllerBase
{

    public AvatarController()
    {
    }

    [HttpGet("{id}")]
    public IEnumerable<Avatar> GetById()
    {
        return null;
    }

    [HttpPost]
    public IEnumerable<Avatar> Create()
    {
        return null;
    }

    [HttpPut("{id}/updateblob")]
    public IEnumerable<Avatar> Update()
    {
        return null;
    }
    
    [HttpDelete("{id}")]
    public IEnumerable<Avatar> Delete()
    {
        return null;
    }
}
