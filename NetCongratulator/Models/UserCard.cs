namespace NetCongratulator.Models;

public class UserCard
{
    public int Id { get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public DateTime? BirthdayDate {get; set;}
    public Avatar? Avatar {get; set;}
}