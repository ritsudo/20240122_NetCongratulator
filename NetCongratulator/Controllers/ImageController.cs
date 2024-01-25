using NetCongratulator.Models;
using NetCongratulator.Services;
using Microsoft.AspNetCore.Mvc;
using NetCongratulator.Data;

namespace NetCongratulator.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController(ImageService service) : ControllerBase
{

    private readonly ImageService _service = service;

    /// <summary>
    /// Добавить изображение
    /// </summary>
    /// <returns>ID добавленного изображения</returns>
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        try
        {
            var image = await _service.UploadImage(file);
            return Ok(image);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Получить изображение
    /// </summary>
    /// <returns>Файл изображения</returns>
    [HttpGet("{id}")]
    public ActionResult<Image> GetImage(int id)
    {
        var image = _service.GetImage(id) ?? throw new InvalidOperationException("Image does not exist");

        if (image.FilePath is not null && image.ContentType is not null)
        {
            var fileStream = new FileStream(image.FilePath, FileMode.Open);
            return File(fileStream, image.ContentType);
        }
        else
        {
            return NotFound();
        }
    }



}
