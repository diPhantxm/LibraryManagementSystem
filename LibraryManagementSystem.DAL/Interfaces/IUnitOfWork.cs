using LibraryManagementSystem.DAL.Repositories;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        BookRepository Books { get; }
        UserRepository Users { get; }
        RentRepository Rents { get; }
    }
}
