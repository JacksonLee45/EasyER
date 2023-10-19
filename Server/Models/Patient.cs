namespace EasyER.Server.Models
{
    public class Patient
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PatientId { get; set; }

        public int TraumaLevel { get; set; }

        public string InjuryName { get; set; }

        public string InjuryDescription { get; set; }
       
        public bool IsActive { get; set; }

        public bool IsBeingSeen { get; set; }

        public int? NurseId { get; set; } //Foreign Key Relationship 
 
        public int? DoctorId { get; set; } //Foreign Key Relationship

        public DateTime TimeAdmitted { get; set; }

        public Patient()
        {
            this.IsActive = true;
            this.TimeAdmitted = DateTime.Now;
        }

        public Patient(string firstName, string lastName, int traumaLevel, string injuryName, string injuryDescription, bool isActive)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TraumaLevel = traumaLevel;
            this.InjuryName = injuryName;
            this.InjuryDescription = injuryDescription;
            this.IsActive = isActive;
        }

        public Patient WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public Patient WithTraumaLevel(int traumaLevel)
        {
            TraumaLevel = traumaLevel;
            return this;
        }

        public Patient WithIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public Patient WithId(int id)
        {
            PatientId = id;
            return this;
        }

    }
}
