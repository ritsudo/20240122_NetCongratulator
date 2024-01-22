namespace NetCongratulator.Models;

public class Avatar
{
    public int Id { get; set;}
	
    public string? TaskName {get; set;}
	
	public DateTime SendTime {get; set;}
	
	public ICollection<EmailAddress>? Addresses {get; set;}
}