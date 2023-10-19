namespace EasyER.Shared
{
    public class Doctor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool OnCall { get; set; }

        public int DoctorId { get; set; }
        
        public string Email { get; set; }

        public int CurrentPatientId { get; set; }


        public Doctor()
        {
            this.CurrentPatientId = 0;
        }

        public Doctor(string firstName, string lastName, int DoctorId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
