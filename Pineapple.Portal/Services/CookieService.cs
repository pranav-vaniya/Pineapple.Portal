using Microsoft.JSInterop;

namespace Pineapple.Portal.Services;

public class CookieService
{
    private readonly IJSRuntime _jSRuntime;
    private const string PayloadUserTokenKey = "PayloadUserToken";


    public CookieService(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }

    public async Task SetPayloadToken(string? token)
    {
        await _jSRuntime.InvokeVoidAsync("setCookie", PayloadUserTokenKey, token);
    }

    public async Task<string?> GetPayloadToken()
    {
        return await _jSRuntime.InvokeAsync<string?>("getCookie", PayloadUserTokenKey);
    }
}
