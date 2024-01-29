using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace NetCongratulator.Domain;

public class EditImage
{
    public int Id { get; set; }
    [Required]
    public IFormFile? File { get; set; }
}