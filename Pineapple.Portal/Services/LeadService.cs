using System.Text.Json;
using Pineapple.Portal.Models;

namespace Pineapple.Portal.Services;

public class LeadService
{
    private readonly HttpClient _httpClient;
    private readonly CookieService _cookieService;

    public LeadService(HttpClient httpClient, CookieService cookieService)
    {
        _httpClient = httpClient;
        _cookieService = cookieService;
    }

    public async Task<List<Lead>> GetAllLeads()
    {
        string? userPayloadToken = await _cookieService.GetPayloadToken();

        if (userPayloadToken is not null)
        {
            try
            {
                string query = "leads?depth=0&limit=100000&select[assignedTo]=false&select[createdBy]=false&select[modifiedBy]=false";

                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, query);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userPayloadToken);

                using HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseBody = await responseMessage.Content.ReadAsStringAsync();

                    var leadResponse = JsonSerializer.Deserialize<LeadResponse>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (leadResponse is not null)
                    {
                        return leadResponse.Docs;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Leads Service: " + ex.Message);
            }
        }

        return new List<Lead>();
    }
}
