namespace Kairos.BlazorApp;

public class ReminderRepositoryMock : IReminderRepository
{
    public Task<List<Reminder>> Get(string userId)
    {
        List<Reminder> reminders =
        [
            new Reminder
            {
                Text = "Go for walk",
                ScheduledTime = DateTime.Now.AddHours(2),
                RepetitonGap = TimeSpan.FromDays(1)
            },
            new Reminder
            {
                Text = "Make call",
                ScheduledTime = DateTime.Today.AddHours(18), // 6 PM today
                RepetitonGap = TimeSpan.FromDays(7)
            },
            new Reminder
            {
                Text = "Team stand-up meeting",
                ScheduledTime = DateTime.Today.AddHours(9), // 9 AM today
                RepetitonGap = TimeSpan.FromDays(1)
            },
            new Reminder
            {
                Text = "Pay electricity bill",
                ScheduledTime = DateTime.Today.AddDays(2).AddHours(12), // Noon in 2 days
                RepetitonGap = TimeSpan.FromDays(30)
            }
        ];
        
        return Task.FromResult(reminders);
    }
}
