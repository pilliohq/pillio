namespace Pillio.People;
[Table("TimePlans")]
public class TimePlan : Entity<int>
{
    public int? TenantId { get; set; }

    public virtual TimeSpan WakeupTime { get; set; }

    public virtual TimeSpan SleepTime { get; set; }

    public virtual TimeSpan DosingSchedule1Value { get; set; }

    public virtual TimeSpan DosingSchedule2Value { get; set; }

    public virtual TimeSpan DosingSchedule3Value { get; set; }

    public virtual TimeSpan? DosingSchedule4 { get; set; }

    public override string ToString()
    {
        return $"{DosingSchedule1Value} | {DosingSchedule2Value} | {DosingSchedule3Value}";
    }
}
