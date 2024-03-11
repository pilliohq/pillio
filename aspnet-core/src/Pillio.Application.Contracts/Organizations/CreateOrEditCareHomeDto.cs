namespace Pillio.Organizations.Dtos
{
    public class CreateOrEditCareHomeDto
    {

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Floors { get; set; }

        public string? Notes { get; set; }

        public DayOfWeek DeliveryDay { get; set; } = DayOfWeek.Monday;

        public TimeSpan DeliveryTime { get; set; } = new TimeSpan(8, 0, 0);

        public Guid? CareHomeTenantId { get; set; }

        public Guid? AvatarId { get; set; }

    }
}