namespace IdentityProvider.Api.Models;

public class UserIdentity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; }
    public List<string> Roles { get; set; } = new();
    public List<string> Permissions { get; set; } = [];
    public string Department { get; set; } = string.Empty;
}