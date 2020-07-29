using LibraryManagementSystem.DAL.Models;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Reader> AuthenticateAsync(string login, string password);
    }
}
