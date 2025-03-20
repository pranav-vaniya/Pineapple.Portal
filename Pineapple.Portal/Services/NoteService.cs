using System.Text.Json;
using Pineapple.Portal.Models;

namespace Pineapple.Portal.Services;

public class NoteService
{
    private readonly HttpClient _httpClient;
    private readonly CookieService _cookieService;

    public NoteService(HttpClient httpClient, CookieService cookieService)
    {
        _httpClient = httpClient;
        _cookieService = cookieService;
    }

    public async Task<List<NoteEntity>> GetAllNotes()
    {
        string? userPayloadToken = await _cookieService.GetPayloadToken();

        if (userPayloadToken is not null)
        {
            try
            {
                string query = "notes?depth=0&limit=100000";

                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, query);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userPayloadToken);

                using HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseBody = await responseMessage.Content.ReadAsStringAsync();

                    var noteResponse = JsonSerializer.Deserialize<NoteResponseDto>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (noteResponse is not null)
                    {
                        return noteResponse.Docs;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Notes service: " + ex.Message);
            }
        }

        return new List<NoteEntity>();
    }
}
