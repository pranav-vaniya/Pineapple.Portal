namespace Pineapple.Portal.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Role { get; set; } = string.Empty;
    public int? ReportsTo { get; set; }
    public int? CreatedBy { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = string.Empty;
    public int LoginAttempts { get; set; }
}

public class MeInnerUser
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Role { get; set; } = string.Empty;
    public User? ReportsTo { get; set; }
    public User? CreatedBy { get; set; }
    public User? ModifiedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = string.Empty;
    public int LoginAttempts { get; set; }
    public string Collection { get; set; } = string.Empty;
}

public class MeUser
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Role { get; set; } = string.Empty;
    public MeInnerUser? ReportsTo { get; set; }
    public MeInnerUser? CreatedBy { get; set; }
    public MeInnerUser? ModifiedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; } = string.Empty;
    public int LoginAttempts { get; set; }
    public string Collection { get; set; } = string.Empty;
}

class UserApiResponse
{
    public List<User> Docs { get; set; } = new List<User>();
    public int TotalDocs { get; set; }
}
