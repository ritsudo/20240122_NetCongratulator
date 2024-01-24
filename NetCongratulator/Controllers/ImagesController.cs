using NetCongratulator.Models;
using NetCongratulator.Services;
using Microsoft.AspNetCore.Mvc;
using NetCongratulator.Data;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
    
    private readonly UserCardContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ImagesController(UserCardContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Invalid file");

        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var image = new Image
        {
            FileName = fileName,
            ContentType = file.ContentType,
            FilePath = filePath,
            UploadDate = DateTime.Now
        };

        _context.Images.Add(image);
        await _context.SaveChangesAsync();

        return Ok(image);
    }

    [HttpGet("{id}")]
    public IActionResult GetImage(int id)
    {
        var image = _context.Images.FirstOrDefault(i => i.Id == id);

        if (image == null)
            return NotFound();

        var fileStream = new FileStream(image.FilePath, FileMode.Open);
        return File(fileStream, image.ContentType);
    }
}
