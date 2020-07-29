using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T Entity);
        Task SaveAsync();
        Task<int> CountAllAsync();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> condition);
    }
}
