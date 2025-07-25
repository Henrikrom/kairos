using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Kairos.BlazorApp;

public class AuthHelper(AuthenticationStateProvider AuthProvider)
{
    public async Task<string> GetUserId() {
        var authState = await AuthProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        string? userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) {
            throw new Exception("Could not retrieve a user id from the auth provider");
        }

        return userId;
    }
    
}
