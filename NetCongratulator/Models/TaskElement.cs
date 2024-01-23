namespace NetCongratulator.Models;

public class TaskElement
{
    public int Id { get; set;}
	
	public DateTime? CreatedAt {get; set;}
	
	public DateTime? UpdatedAt {get; set;}
	
    public string? TaskName {get; set;}
	
	public DateTime SendTime {get; set;}
	
	public ICollection<EmailAddress>? Addresses {get; set;}
}