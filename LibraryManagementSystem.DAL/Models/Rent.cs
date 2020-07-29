using LibraryManagementSystem.DAL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.DAL.Models
{
    public class Rent : IRent
    {
        [Key]
        public int Book_Id { get; set; }
        [ForeignKey("Reader")]
        public int Reader_Id { get; set; }

        public DateTime ExpireDate { get; set; }

        public virtual Reader Reader { get; set; }

        public virtual Book Book { get; set; }

        public Rent(Reader reader, Book book, DateTime expireDate)
        {
            Reader = reader;
            Book = book;
            ExpireDate = expireDate;
        }

        public Rent()
        {

        }
    }
}
