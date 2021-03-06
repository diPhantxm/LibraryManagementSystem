﻿using LibraryManagementSystem.Core.Models.Interfaces;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public class BookManager : Manager, IBookManager
    {
        public BookManager(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public async Task BuyAsync(Book book, Reader user)
        {
            // TODO: implement card payment

            await Database.Books.TakeOne(book);

            await Database.Books.SaveAsync();
        }

        public async Task GiftAsync(Book book)
        {
            var bookFindResult = Database.Books.FindByCondition(b => b.Id == book.Id);
            if (bookFindResult.Count() == 0)
            {
                await Database.Books.AddAsync(book);
            }
            else
            {
                var foundBook = bookFindResult.Single();
                foundBook.Available = true;
                foundBook.Amount++;
            }

            await Database.Books.SaveAsync();
        }

        public async Task RentAsync(Book book, Reader user)
        {
            var rent = new Rent(user, book, DateTime.Now.AddMonths(2));

            await Database.Rents.AddAsync(rent);
            await Database.Users.AddRentAsync(user, rent);
            await Database.Books.TakeOne(book);
        }

        public async Task ReturnAsync(Book book, Reader user)
        {
            var readers = await Database.Users.FindByConditionAsync(r => r.Id == user.Id);

            if (readers == null || readers.Count() == 0) return;

            var reader = readers.Single();
            var rent = reader.Rents.Where(r => r.Book_Id == book.Id && r.Reader_Id == user.Id).SingleOrDefault();

            await Database.Rents.DeleteAsync(rent);
            await Database.Books.ReturnOne(book);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var books = Database.Books.FindByCondition(b => b.Id == id);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();

            await Database.Books.DeleteAsync(book);
        }

        public async Task DeleteByTitleAsync(string title)
        {
            var books = Database.Books.FindByCondition(b => b.Title == title);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();

            await Database.Books.DeleteAsync(book);
        }

        public async Task DeleteByISBNAsync(string isbn)
        {
            var books = Database.Books.FindByCondition(b => b.ISBN == isbn);
            if (books.Count() == 0)
            {
                return;
            }

            var book = books.Single();

            await Database.Books.DeleteAsync(book);
        }
    }
}
