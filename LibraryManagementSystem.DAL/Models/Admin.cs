namespace LibraryManagementSystem.DAL.Models
{
    public class Admin : Reader
    {
        public Admin(string login, string password, string firstName, string lastName, string phoneNumber, byte[] salt, int iterations)
            : base(login, password, firstName, lastName, phoneNumber, salt, iterations)
        {

        }

        public Admin()
        {

        }
    }
}
