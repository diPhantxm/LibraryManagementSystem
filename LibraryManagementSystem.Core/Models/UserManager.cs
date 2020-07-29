using LibraryManagementSystem.Core.Models.Interfaces;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class UserManager : Manager, IUserManager
    {
        public Reader CurrentUser { get; private set; }

        public UserManager(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IUser> RegisterAsync(string login, string password, string firstName, string lastName, string phoneNumber)
        {
            var rnd = new Random();

            var length = rnd.Next() % 20 + 8;
            var iterations = rnd.Next() % 10 + 1;

            // generate salt with specific length
            var salt = generateSalt(length);

            // get Hash with salt
            var hash = getHash(password, salt, iterations);
            
            // set hash of password
            var newUser = new Reader(login, hash, firstName, lastName,
                phoneNumber, salt, iterations);

            // Add new user to database
            await Database.Users.AddAsync(newUser);

            return newUser;
        }

        public async Task<IUser> AuthenticateAsync(string login, string password)
        {
            if (String.IsNullOrWhiteSpace(login) || String.IsNullOrWhiteSpace(password)) return null;

            // get salt of user's hash
            var salt = await Database.Users.GetSaltAsync(login);

            // get iterations of user's hash
            var iterations = await Database.Users.GetIterationsAsync(login);

            // get user's password hash
            var hash = getHash(password, salt, iterations).ToString();

            // set current user
            CurrentUser = await Database.Users.AuthenticateAsync(login, hash);
            return CurrentUser;
        }

        public async Task DeleteAsync()
        {
            await Database.Users.DeleteAsync(CurrentUser);
        }

        public async Task EditAsync(Reader user)
        {
            await Database.Users.Update(user);
        }



        private byte[] generateSalt(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }
        private string getHash(string password, byte[] salt, int iterations)
        {
            string hash = String.Empty;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                hash = Convert.ToBase64String(deriveBytes.GetBytes(salt.Length));
            }

            return hash;
        }
    }
}
