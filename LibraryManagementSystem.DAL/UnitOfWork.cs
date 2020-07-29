using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Repositories;
using System;

namespace LibraryManagementSystem.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public LibraryDbContext DbContext;
        public BookRepository Books { get; private set; }
        public UserRepository Users { get; private set; }
        public RentRepository Rents { get; private set; }

        public UnitOfWork(LibraryDbContext context)
        {
            DbContext = context;
            Books = new BookRepository(context);
            Users = new UserRepository(context);
            Rents = new RentRepository(context);
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
