using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class UserRepository : Repository<Reader>, IUserRepository
    {
        public UserRepository(LibraryDbContext context) : base(context)
        {

        }

        public new async Task AddAsync(Reader reader)
        {
            await Task.Run(() => _context.Readers.Add(reader));
            await SaveAsync();
        }

        public async Task AddRentAsync(Reader reader, Rent rent)
        {
            var rentingReader = (await FindByConditionAsync(r => r.Id == reader.Id)).Take(1).Single();

            if (rentingReader == null) return;

            rentingReader.Rents.Add(rent);

            await SaveAsync();
        }

        public async Task DeleteRentAsync(Reader reader, Rent rent)
        {
            var rentingReader = (await FindByConditionAsync(r => r.Id == reader.Id)).SingleOrDefault();

            if (rentingReader == null) return;

            rentingReader.Rents.Remove(rent);
            _context.Rents.Remove(rent);

            await SaveAsync();
        }

        public async Task<Reader> AuthenticateAsync(string login, string password)
        {
            return await Task.Run(() =>
            {
                var result = FindByConditionAsync(u => u.Login == login && u.Password == password).Result;

                if (result == null) return null;

                return result.SingleOrDefault();
            });
            
        }

        public async Task<byte[]> GetSaltAsync(string login)
        {
            var user = (await FindByConditionAsync(u => u.Login == login)).Take(1).Single();
            return user.Salt;
        }

        public async Task<int> GetIterationsAsync(string login)
        {
            return await Task.Run(() =>
            {
                var user = FindByConditionAsync(u => u.Login == login).Result;

                if (user == null && user.Count() == 0)
                {
                    return 0;
                }
                else
                {
                    return user.Take(1).SingleOrDefault().Iterations;
                }
            });
        }

        public async Task UpdateAsync(Reader updatedReader)
        {
            var readersToUpdate = FindByCondition(r => r.Id == updatedReader.Id);
            if (readersToUpdate.Count() == 0 || readersToUpdate.Count() > 1)
            {
                throw new KeyNotFoundException("Reader-To-Update not found.");
            }
            var readerToUpdate = readersToUpdate.Single();

            readerToUpdate = updatedReader;

            await SaveAsync();
        }
    }
}
