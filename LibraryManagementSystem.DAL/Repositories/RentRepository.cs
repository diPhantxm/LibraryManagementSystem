using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public RentRepository(LibraryDbContext context) : base(context)
        {

        }
    }
}
