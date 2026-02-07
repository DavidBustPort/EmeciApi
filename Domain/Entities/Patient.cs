namespace Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }

        public Patient() { }

        public Patient(string fullName, DateTime birthdate)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new Exception("El nombre es obligatorio");

            if (birthdate > DateTime.Now)
                throw new Exception("La fecha de nacimiento no puede ser futura");

            Id = new Guid();
            FullName = fullName;
            BirthDate = birthdate;
        }

        public int GetAge() => DateTime.Now.Year - BirthDate.Year;
    }
}
