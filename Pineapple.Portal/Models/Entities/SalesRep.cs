namespace Pineapple.Portal.Models;

public class SalesRep
{
    public SalesRep()
    {
        List<string> leadStatuses = LeadStatuses.GetAll();

        foreach (string status in leadStatuses)
        {
            StatCounts[status] = 0;
        }
    }

    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public Dictionary<string, int> StatCounts { get; set; } = new Dictionary<string, int>();
}
