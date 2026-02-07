namespace Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; private set; }
        public string FullName { get; set; } = string.Empty;
        public string Especialty { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public Doctor()
        {
            
        }
    }
}
