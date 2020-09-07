using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.DAL;

namespace LibraryManagementSystem.Core.Models
{
    public class RentManager : Manager
    {
        public RentManager(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task DeleteRentAsync(int user_id, int book_id)
        {
            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user_id && r.Book_Id == book_id);
            if (rents.Count() == 0)
            {
                return;
            }

            var rent = rents.Single();


            await Database.Rents.DeleteAsync(rent);
        }

        public async Task DeleteRentAsync(string login, int book_id)
        {
            var users = Database.Users.FindByCondition(u => u.Login == login);
            if (users.Count() == 0)
            {
                return;
            }

            var user = users.Single();
            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user.Id && r.Book_Id == book_id);

            if (rents.Count() == 0)
            {
                return;
            }

            var rent = rents.Single();
            await Database.Rents.DeleteAsync(rent);
        }

        public async Task DeleteRentByISBNAsync(int user_id, string isbn)
        {
            var books = Database.Books.FindByCondition(b => b.ISBN == isbn);
            if (books.Count() == 0)
            {
                return;
            }
            var book = books.Single();

            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user_id && r.Book_Id == book.Id);
            if (rents.Count() == 0)
            {
                return;
            }

            var rent = rents.Single();

            await Database.Rents.DeleteAsync(rent);
        }
        public async Task DeleteRentByISBNAsync(string login, string isbn)
        {
            var books = Database.Books.FindByCondition(b => b.ISBN == isbn);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();
            var users = Database.Users.FindByCondition(u => u.Login == login);
            if (users.Count() == 0)
            {
                return;
            }

            var user = users.Single();
            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user.Id && r.Book_Id == book.Id);
            if (rents.Count() == 0)
            {
                return;
            }

            var rent = rents.Single();

            await Database.Rents.DeleteAsync(rent);
        }

        public async Task DeleteRentByBookTitleAsync(int user_id, string title)
        {
            var books = Database.Books.FindByCondition(b => b.Title == title);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();
            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user_id && r.Book_Id == book.Id);

            if (rents.Count() == 0)
            {
                return;
            }
            var rent = rents.Single();

            await Database.Rents.DeleteAsync(rent);
        }

        public async Task DeleteRentByBookTitleAsync(string login, string title)
        {
            var books = Database.Books.FindByCondition(b => b.Title == title);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();
            var users = Database.Users.FindByCondition(u => u.Login == login);
            if (users.Count() == 0)
            {
                return;
            }

            var user = users.Single();
            var rents = Database.Rents.FindByCondition(r => r.Reader_Id == user.Id && r.Book_Id == book.Id);

            if (rents.Count() == 0)
            {
                return;
            }

            var rent = rents.Single();

            await Database.Rents.DeleteAsync(rent);
        }

    }
}
