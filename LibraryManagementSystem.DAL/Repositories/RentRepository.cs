using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public RentRepository(LibraryDbContext context) : base(context)
        {
            
        }
        
        public async Task UpdateAsync(Rent updatedRent)
        {
            var rentsToUpdate = FindByCondition(r => r.Book_Id == updatedRent.Book_Id && r.Reader_Id == updatedRent.Reader_Id && r.ExpireDate == updatedRent.ExpireDate);
            if (rentsToUpdate.Count() == 0 || rentsToUpdate.Count() > 1)
            {
                throw new KeyNotFoundException("Rent-To-Update not found.");
            }

            var rentToUpdate = rentsToUpdate.Single();
            rentToUpdate = updatedRent;

            await SaveAsync();
        }
    }
}
