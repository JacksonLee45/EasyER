namespace EasyER.Shared
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

        //public Nurse? nurse { get; set; }
        public int? NurseId { get; set; }

        //public Doctor? doctor { get; set; } //should be nullable
        public int? DoctorId { get; set; }

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

    }
}
