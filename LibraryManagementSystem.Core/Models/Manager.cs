using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Models
{
    public abstract class Manager
    {
        protected readonly UnitOfWork Database;

        public Manager(UnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
    }
}
