using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagementSystem.DAL.Models;

namespace LibraryManagementSystem.DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetByAuthorAsync(string author);
        Task<IEnumerable<Book>> GetByCategoryAsync(string category);
        Task<IEnumerable<Book>> FindByNameAsync(string[] keyWords);
        Task<IEnumerable<Book>> GetByLanguageAsync(string language);
        Task<IEnumerable<Book>> GetByRatingAsync(double rating);
        Task<IEnumerable<Book>> GetByReleaseDateAsync(DateTime releaseDate);
    }
}
