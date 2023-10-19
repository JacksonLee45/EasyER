namespace EasyER.Shared
{
    public class Nurse 
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int NurseId { get; set; }

        public string Email { get; set; }

        public Nurse() //default constructor
        {

        }

        public Nurse(string firstName,string lastName, int NurseId) //parameterized constructor
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
}
