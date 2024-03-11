namespace Pillio.People
{
    public class TimePlanDto : EntityDto<Guid>
    {
        public int? TenantId { get; set; }

        public TimeSpan WakeupTime { get; set; }

        public TimeSpan SleepTime { get; set; }

        public TimeSpan DosingSchedule1Value { get; set; }

        public TimeSpan DosingSchedule2Value { get; set; }

        public TimeSpan DosingSchedule3Value { get; set; }

        public TimeSpan? DosingSchedule4 { get; set; }

        public string DisplaySchedule => $"{DosingSchedule1Value} | {DosingSchedule2Value} | {DosingSchedule3Value}";

        // Add any additional properties or methods as needed
    }
}
