namespace Kairos.BlazorApp;

public class Reminder
{
   public string? Id { get; set; } = Guid.NewGuid().ToString();
   public string? Text { get; set; } 
   public DateTime? ScheduledTime { get; set; }
   public TimeSpan RepetitonGap { get; set; }
}
