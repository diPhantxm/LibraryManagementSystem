using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public LibraryDbContext DbContext;
        public BookRepository Books { get; private set; }
        public UserRepository Users { get; private set; }
        public RentRepository Rents { get; private set; }
        public RoleRepository Roles { get; private set; }

        public UnitOfWork(LibraryDbContext context)
        {
            DbContext = context;
            Books = new BookRepository(context);
            Users = new UserRepository(context);
            Rents = new RentRepository(context);
            Roles = new RoleRepository(context);

            if (Roles.FindByCondition(role => role.Name == "Admin").Count() == 0)
            {
                Roles.Add(new Role("Admin"));
            }

            if (Roles.FindByCondition(role => role.Name == "Reader").Count() == 0)
            {
                Roles.Add(new Role("Reader"));
            }
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
