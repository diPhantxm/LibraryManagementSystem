using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context)
        {
            
        }

        public new async Task AddAsync(Book book)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var find = FindByCondition(b => b.ISBN == book.ISBN);
                    if (find.Count() > 0)
                    {
                        var bookToUpdate = find.Take(1).Single();
                        bookToUpdate.Amount++;
                    }
                    else
                    {
                        _context.Books.Add(book);
                    }

                    await SaveAsync();
                });
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<Book>> FindByNameAsync(string[] keyWords)
        {
            return await Task.Run(() =>
            {
                return FindByConditionAsync(b => keyWords.Contains(b.Title)).Result
                .OrderBy(x => x.Title);
            }); 
        }

        public async Task<IEnumerable<Book>> GetByAuthorAsync(string author)
        {
            return await FindByConditionAsync(b => b.Author == author);
        }

        public async Task<IEnumerable<Book>> GetByCategoryAsync(string category)
        {
            return await FindByConditionAsync(b => b.Category == category);
        }

        public async Task<IEnumerable<Book>> GetByLanguageAsync(string language)
        {
            return await FindByConditionAsync(b => b.Language == language);
        }

        public async Task<IEnumerable<Book>> GetByRatingAsync(double rating)
        {
            return await Task.Run(() =>
            {
                return FindByConditionAsync(b => b.Rating >= rating).Result
                .OrderBy(x => x.Rating);
            });
        }

        public async Task<IEnumerable<Book>> GetByReleaseDateAsync(DateTime releaseDate)
        {
            return await Task.Run(() =>
            {
                return FindByConditionAsync(b => b.ReleaseDate >= releaseDate).Result
                        .OrderBy(x => x.ReleaseDate);
            });
        }

        public async Task UpdateAsync(Book updatedBook)
        {
            var booksToUpdate = FindByCondition(b => b.Id == updatedBook.Id);
            if (booksToUpdate.Count() == 0 || booksToUpdate.Count() > 1)
            {
                throw new KeyNotFoundException("Book-To-Update not found.");
            }
            var bookToUpdate = booksToUpdate.Single();

            bookToUpdate = updatedBook;
            await SaveAsync();
        }

        public async Task TakeOne(Book book)
        {
            var bookToUpdate = (await FindByConditionAsync(b => b.Id == book.Id)).Take(1).Single();
            if (bookToUpdate.Amount > 1)
            {
                bookToUpdate.Amount--;
            }
            else
            {
                bookToUpdate.ChangeAvailability();
            }
            
            await SaveAsync();
        }

        public async Task ReturnOne(Book book)
        {
            var bookToUpdate = FindByCondition(b => b.Id == book.Id).Take(1).Single();
            if (!bookToUpdate.Available)
            {
                bookToUpdate.ChangeAvailability();
            }
            else
            {
                bookToUpdate.Amount++;
            }

            await SaveAsync();
        }
    }
}
