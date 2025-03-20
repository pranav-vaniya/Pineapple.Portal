namespace Pineapple.Portal.Models;

public class Me
{
    public MeUser User { get; set; } = new MeUser();
    public string Collection { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
