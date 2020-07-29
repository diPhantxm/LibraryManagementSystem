using LibraryManagementSystem.DAL.Models;
using System;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IRent
    {
        Reader       Reader { get; }
        Book       Book { get; }
        DateTime    ExpireDate { get; }
    }
}
