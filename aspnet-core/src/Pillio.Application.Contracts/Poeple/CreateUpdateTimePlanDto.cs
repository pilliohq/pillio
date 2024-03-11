namespace Pillio.People
{
    public class CreateUpdateTimePlanDto
    {
        public int? TenantId { get; set; }

        [Required]
        public TimeSpan WakeupTime { get; set; }

        [Required]
        public TimeSpan SleepTime { get; set; }

        [Required]
        public TimeSpan DosingSchedule1Value { get; set; }

        [Required]
        public TimeSpan DosingSchedule2Value { get; set; }

        [Required]
        public TimeSpan DosingSchedule3Value { get; set; }

        public TimeSpan? DosingSchedule4 { get; set; }

        // Add any additional properties or methods as needed
    }
}
