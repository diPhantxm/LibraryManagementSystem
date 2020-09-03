using LibraryManagementSystem.Core.Models;
using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public static class Managers
    {
        public static UnitOfWork UnitOfWork;
        public static BookManager BookManager;
        public static UserManager UserManager;
        public static SecurityManager SecutiryManager;
    }
}
