using System.Reflection;

namespace Pineapple.Portal.Models;

public static class UserRoles
{
    public const string ClientAdmin = "Client Administrator";
    public const string Manager = "Manager";
    public const string SalesRep = "Sales Representative";

    public static List<string> GetAll()
    {
        return typeof(LeadSources)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
            .Select(fi => fi.GetRawConstantValue()?.ToString()!)
            .ToList();
    }
}

public static class LeadSources
{
    public const string Referral = "Referral";
    public const string SocialMedia = "Social Media";
    public const string Website = "Website";
    public const string Event = "Event";
    public const string Advertisement = "Advertisement";

    public static List<string> GetAll()
    {
        return typeof(LeadSources)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
            .Select(fi => fi.GetRawConstantValue()?.ToString()!)
            .ToList();
    }
}

public static class LeadStatuses
{
    public const string New = "New";
    public const string Contacted = "Contacted";
    public const string FollowUp = "Follow Up";
    public const string Converted = "Converted";
    public const string Lost = "Lost";

    public static List<string> GetAll()
    {
        return typeof(LeadStatuses)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
            .Select(fi => fi.GetRawConstantValue()?.ToString()!)
            .ToList();
    }
}
