namespace Pineapple.Portal.Models;

public class Lead
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Note { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class LeadResponse
{
    public List<Lead> Docs { get; set; } = new List<Lead>();
    public int TotalDocs { get; set; }
}
