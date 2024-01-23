using System.ComponentModel.DataAnnotations;

namespace NetCongratulator.Models;

public class Avatar
{
    public int Id { get; set;}
	
	public DateTime? CreatedAt {get; set;}
	
	public DateTime? UpdatedAt {get; set;}
	
    [Required]
    [MaxLength(100)]
    public string? AvatarBlob {get; set;}
}