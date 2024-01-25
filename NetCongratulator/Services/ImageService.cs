using NetCongratulator.Models;
using NetCongratulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace NetCongratulator.Services;

public class ImageService(UserCardContext context, IWebHostEnvironment webHostEnvironment)
{
    private readonly UserCardContext _context = context;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;



    public async Task<Image?> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new InvalidOperationException("Invalid or empty file");

        var fileName = Path.GetFileName(file.FileName);
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        var contentType = file.ContentType;
        if (contentType != "image/png")
        {
            if (contentType != "image/jpeg")
            {
                throw new InvalidOperationException("Image type is invalid, jpeg or png required, but received " + file.ContentType);
            }
            else
            {
                fileName = timestamp + ".jpg";
            }
        }
        else
        {
            fileName = timestamp + ".png";
        }

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

        return image;
    }

    public Image? GetImage(int id)
    {
        var image = _context.Images.FirstOrDefault(i => i.Id == id) ?? throw new InvalidOperationException("Image does not exist");

        return image;

    }
}