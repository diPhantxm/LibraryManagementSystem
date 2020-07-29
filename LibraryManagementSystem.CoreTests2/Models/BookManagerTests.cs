using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.Core.Models.Tests
{
    [TestClass()]
    public class BookManagerTests
    {

        [TestMethod()]
        public async Task BuyAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());
                var bm = new BookManager(unitOfWork);

                var book = (await unitOfWork.Books.GetAllAsync()).Take(1).Single();
                var user = (await unitOfWork.Users.GetAllAsync()).Take(1).Single();

                await bm.BuyAsync(book, user);

                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task GiftAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());
                var bm = new BookManager(unitOfWork);

                await bm.GiftAsync(new Book(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now, 1, 11, 12, 11, new DAL.Models.BookDimensions(5, 5, 5), true));

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task RentAsyncTestAsync()
        {
            try
            {
                var uow = new UnitOfWork(new LibraryDbContext());

                var um = new UserManager(uow);
                var bm = new BookManager(uow);

                var user = (await uow.Users.GetAllAsync()).Take(1).Single();
                var book = (await uow.Books.GetAllAsync()).Take(1).Single();

                await bm.RentAsync(book, user);

                if ((await uow.Rents.FindByConditionAsync(r => r.Reader.Id == user.Id && r.Book.Id == book.Id)).Take(1).Single() != null)
                {
                    Assert.IsTrue(true);
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public async Task ReturnAsyncTestAsync()
        {
            try
            {
                var unitOfWork = new UnitOfWork(new LibraryDbContext());
                var bm = new BookManager(unitOfWork);

                var rent = (await unitOfWork.Rents.GetAllAsync()).Take(1).Single();

                var user = rent.Reader;
                var book = rent.Book;

                await bm.ReturnAsync(book, user);
                var rents = (await unitOfWork.Rents.FindByConditionAsync(r => r.Reader.Id == user.Id && r.Book.Id == book.Id));

                if (rents.Count() == 0)
                {
                    Assert.IsTrue(true);
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}