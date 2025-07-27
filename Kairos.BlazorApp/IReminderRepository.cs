namespace Kairos.BlazorApp;

public interface IReminderRepository
{
    public Task<List<Reminder>> Get(string userId);
}
