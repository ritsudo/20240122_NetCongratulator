using System.ComponentModel.DataAnnotations;

namespace NetCongratulator.Models;

public class EditImage
{
    public int Id { get; set; }
    [Required]
    public IFormFile? File { get; set; }
}