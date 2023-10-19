namespace EasyER.Server.Models
{
    public class Nurse 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NurseId { get; set; }

        public string Email { get; set; }

        public Nurse()
        {

        }

        public Nurse(string firstName,string lastName, int NurseId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Nurse WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public Nurse WithId(int id)
        {
            NurseId = id;
            return this;
        }

        public Nurse WithEmail(string email)
        {
            Email = email;
            return this;
        }


    }
}
