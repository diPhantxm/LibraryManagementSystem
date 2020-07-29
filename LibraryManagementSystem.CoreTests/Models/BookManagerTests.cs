using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Models;

namespace LibraryManagementSystem.Core.Models.Tests
{
    [TestClass()]
    public class BookManagerTests
    {
        [TestMethod()]
        public void BookManagerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuyAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GiftAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task RentAsyncTestAsync()
        {
            using (var uow = new UnitOfWork(new LibraryDbContext()))
            {
                var um = new UserManager(uow);

                await uow.Users.AddAsync(new Reader(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new byte[] { 1, 2 }, 2));

                await um.RegisterAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                await um.RegisterAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                await um.RegisterAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                await um.RegisterAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
                await um.RegisterAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

                var users = await uow.Users.GetAllAsync();

                var bm = new BookManager(uow);

                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));
                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));
                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));
                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));
                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));

                var books = await uow.Books.GetAllAsync();

                await bm.RentAsync(books.ElementAt(0), users.ElementAt(1));
                await bm.RentAsync(books.ElementAt(1), users.ElementAt(2));
                await bm.RentAsync(books.ElementAt(2), users.ElementAt(3));
                await bm.RentAsync(books.ElementAt(3), users.ElementAt(4));
                await bm.RentAsync(books.ElementAt(4), users.ElementAt(0));

                var rents = await uow.Rents.GetAllAsync();
            }
        }

        [TestMethod()]
        public void ReturnAsyncTest()
        {
            Assert.Fail();
        }
    }
}