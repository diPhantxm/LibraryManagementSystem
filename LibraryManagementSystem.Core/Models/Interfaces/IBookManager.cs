using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models.Interfaces
{
    public interface IBookManager
    {
        Task RentAsync(Book book, Reader user);
        Task ReturnAsync(Book book, Reader user);
        Task GiftAsync(Book book);
        Task BuyAsync(Book book, Reader user);
    }
}
