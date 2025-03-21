namespace Pineapple.Portal.Models;

public class AddNewLeadDto
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string LeadSource { get; set; } = string.Empty;
    public string LeadStatus { get; set; } = string.Empty;
    public string? Note { get; set; }
}
