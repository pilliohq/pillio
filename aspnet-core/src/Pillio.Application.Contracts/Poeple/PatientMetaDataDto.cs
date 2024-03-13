namespace Pillio.People
{
    public class PatientMetaDataDto
    {
        public List<string> HealthStatuses { get; set; } = new List<string>();

        public string BloodPressure { get; set; }

        public float BloodPressureIncrease { get; set; }

        public float BloodSugarIncrease { get; set; }

        public string BloodSugar { get; set; }

        public List<string> Symptoms { get; set; } = new List<string>();

        public List<string> CommonSymptomsAndSideEffects = new List<string>();
    }
}
