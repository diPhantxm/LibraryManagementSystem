using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Core;
using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.Core.Models.Tests
{
    [TestClass()]
    public class UserManagerTests
    {

        [TestMethod()]
        public async Task RegisterAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());

                var um = new UserManager(unitOfWork);
                await um.RegisterAsync("Test", "123456", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            
        }

        [TestMethod()]
        public async Task AuthenticateAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());

                var um = new UserManager(unitOfWork);

                var user = await um.AuthenticateAsync("Test", "123456");

                Assert.IsNotNull(user);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task DeleteAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());

                var um = new UserManager(unitOfWork);

                await um.AuthenticateAsync("Test", "123456");
                await um.DeleteAsync(um.CurrentUser.Id);

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task EditAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());

                var um = new UserManager(unitOfWork);

                var prev = (await unitOfWork.Users.FindByConditionAsync(u => u.Login == "Test")).Take(1).Single();

                await um.AuthenticateAsync("Test", "123456");
                var editedUser = prev;
                editedUser.FirstName = "asdf";
                await um.EditAsync(editedUser);

                var after = (await unitOfWork.Users.FindByConditionAsync(u => u.Login == "Test")).Take(1).Single();

                Assert.AreEqual(after.FirstName, prev.FirstName);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}