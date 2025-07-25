namespace Kairos.BlazorApp;

public class UserData
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public List<Reminder> Reminders { get; set; } = [];
}
