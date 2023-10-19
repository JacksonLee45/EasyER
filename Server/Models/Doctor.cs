namespace EasyER.Server.Models
{
    public class Doctor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool OnCall { get; set; }

        public int DoctorId { get; set; }

        public string Email { get; set; }

        public int? CurrentPatientId { get; set; }


        public Doctor()
        {
            this.CurrentPatientId = 0;
        }

        public Doctor(string firstName, string lastName, int DoctorId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Doctor WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public Doctor WithId(int id)
        {
            DoctorId = id;
            return this;
        }

        public Doctor WithEmail(string email)
        {
            Email = email;
            return this;
        }

    }
}