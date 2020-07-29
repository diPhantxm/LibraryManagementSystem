namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IUser
    {
        string Login { get; }
        string Password { get; }
        string FirstName { get; }
        string LastName { get; }
        string PhoneNumber { get; }
        byte[] Salt { get; }
        int Iterations { get; }
    }
}
