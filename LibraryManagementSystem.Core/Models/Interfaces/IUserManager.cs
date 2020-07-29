using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models.Interfaces
{
    public interface IUserManager
    {
        Reader CurrentUser { get; }

        Task<IUser> AuthenticateAsync(string login, string password);
        Task<IUser> RegisterAsync(string login, string password, string firstName, string lastName, string phoneNumber);
        Task EditAsync(Reader user);
        Task DeleteAsync();
    }
}
