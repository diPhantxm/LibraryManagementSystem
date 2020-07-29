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

        public async Task ChangeAvailability(Book book)
        {
            (await FindByConditionAsync(b => b.Id == book.Id)).Take(1).Single().ChangeAvailability();
            await SaveAsync();
        }
    }
}
