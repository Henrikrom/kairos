namespace Kairos.BlazorApp;

public interface IAuthHelper
{
    public Task<string> GetUserId();
}
