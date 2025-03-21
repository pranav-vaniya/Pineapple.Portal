namespace Pineapple.Portal.Models;

public class AddNewUserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Role { get; set; } = string.Empty;
    public int? ReportsTo { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AddNewUserDtoWithoutNullReportsTo
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Role { get; set; } = string.Empty;
    public int ReportsTo { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
