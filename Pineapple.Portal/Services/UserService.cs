namespace Pineapple.Portal.Services;

using System.Net;
using System.Text;
using System.Text.Json;
using Pineapple.Portal.Models;

public class UserService
{
    private readonly HttpClient _httpClient;
    private readonly CookieService _cookieService;

    public UserService(HttpClient httpClient, CookieService cookieService)
    {
        _httpClient = httpClient;
        _cookieService = cookieService;
    }

    public async Task<List<User>> GetAllUsers()
    {
        string? userPayloadToken = await _cookieService.GetPayloadToken();

        if (userPayloadToken is not null)
        {
            try
            {
                string query = "users?limit=10000&depth=0";

                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, query);
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userPayloadToken);

                using HttpResponseMessage responseMessage = await _httpClient.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseBody = await responseMessage.Content.ReadAsStringAsync();

                    var userResponse = JsonSerializer.Deserialize<UserApiResponse>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (userResponse is not null)
                    {
                        return userResponse.Docs;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in User Service: " + ex.Message);
            }
        }

        return new List<User>();
    }

    public async Task<bool> AddNewUser(AddNewUserDto addNewUserDto)
    {
        string? userPayloadToken = await _cookieService.GetPayloadToken();

        if (userPayloadToken is not null)
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "users");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userPayloadToken);
                request.Content = new StringContent(
                    JsonSerializer.Serialize(addNewUserDto, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                return response.StatusCode == HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Users Service: " + ex.Message);
            }
        }

        return false;
    }
}
