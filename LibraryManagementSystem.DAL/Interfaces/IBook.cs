using LibraryManagementSystem.DAL.Models;
using System;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IBook
    {
        string          Title { get; }
        string          Description { get; }
        string          Author { get; }
        string          Publisher { get; }
        string          Language { get; }
        string          Category { get; }
        DateTime        ReleaseDate { get; }
        short           Pages { get; }
        short           Price { get; }
        float           Rating { get; }
        float           Weight  { get; }
        BookDimensions  Dimensions { get; }
    }
}
