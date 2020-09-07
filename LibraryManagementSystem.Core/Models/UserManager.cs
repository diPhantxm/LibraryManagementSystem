using LibraryManagementSystem.Core.Models.Interfaces;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class UserManager : Manager, IUserManager
    {
        public Reader CurrentUser { get; private set; }

        public UserManager(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            RegisterStartAdmin();
        }

        public async Task<IUser> RegisterAsync(string login, string password, string firstName, string lastName, string phoneNumber, 
            Role role = null)
        {
            var rnd = new Random();

            var length = rnd.Next() % 20 + 8;
            var iterations = rnd.Next() % 10 + 1;

            // generate salt with specific length
            var salt = SecurityManager.GenerateSalt(length);

            // get Hash with salt
            var hash = SecurityManager.GetHash(password, salt, iterations);
            
            // set hash of password
            var newUser = new Reader(login, hash, firstName, lastName,
                phoneNumber, salt, iterations, role);

            // Add new user to database
            if (role == null) role = await Database.Roles.GetRoleAsync("Reader");
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
            var hash = SecurityManager.GetHash(password, salt, iterations).ToString();

            // set current user
            CurrentUser = await Database.Users.AuthenticateAsync(login, hash);
            return CurrentUser;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var userToDelete = (await Database.Users.FindByConditionAsync(u => u.Id == id)).Take(1).Single();
                await Database.Users.DeleteAsync(userToDelete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(string login)
        {
            var userToDelete = (await Database.Users.FindByConditionAsync(u => u.Login == login)).Take(1).Single();
            await Database.Users.DeleteAsync(userToDelete);
        }

        public async Task EditAsync(Reader user)
        {
            var userToUpdate = Database.Users.FindByCondition(u => u.Id == user.Id).Take(1).Single();
            userToUpdate = user;
            await Database.Users.SaveAsync();
        }

        private void RegisterStartAdmin()
        {
            var adminFound = Database.Users.FindByCondition(user => user.Login == "Admin");

            if (adminFound.Count() > 0) return;
            else
            {
                try
                {
                    var salt = SecurityManager.GenerateSalt(20);
                    var hash = SecurityManager.GetHash("test", salt, 5);

                    var adminRole = Database.Roles.FindByCondition(role => role.Name == "Admin").Take(1).Single();
                    var admin = new Reader("Admin", hash, "Admin", "Admin", "", salt, 5, adminRole);
                    Database.Users.Add(admin);
                }
                catch (Exception)
                {

                }
            }

            
            
        }

    }
}
