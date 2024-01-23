namespace NetCongratulator.Models;

public class EmailAddress
{
    public int Id { get; set;}
	
	public DateTime? CreatedAt {get; set;}
	
	public DateTime? UpdatedAt {get; set;}
	
	public UserCard? UserCard {get; set;}
	
    public string? EmailAddressText {get; set;}
}