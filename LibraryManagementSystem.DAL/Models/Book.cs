using LibraryManagementSystem.DAL.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.DAL.Models
{
    public class Book : IEntity
    {
        public int Id { get; set; }

        public string   ISBN { get; set; }

        public string   Title { get; set; }

        public string   PicPath { get; set; }

        public string   Description { get; set; }

        public string   Author { get; set; }

        public string   Publisher { get; set; }

        public string   Language { get; set; }

        public string   Category { get; set; }

        public int      Amount { get; set; }

        public DateTime ReleaseDate { get; set; }

        public short    Pages { get; set; }

        public double    Price { get; set; }

        public double Rating { get; set; }

        public double Weight { get; set; }

        public virtual BookDimensions Dimensions { get; set; }

        public bool     Available { get; set; }

        public virtual Rent Rent { get; set; }


        public Book(string title, string isbn, int amount, string picPath, string description, string author, string publisher, string language, string category, 
            DateTime releaseDate, short pages, float price, float rating, float weight, BookDimensions dimensions, bool available)
        {
            #region Input Check

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Title can't be empty.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(picPath))
            {
                throw new ArgumentNullException("PicPath can't be empty", nameof(picPath));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException("Description can't be empty.", nameof(description));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException("Author can't be empty.", nameof(author));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentNullException("Publisher can't be empty.", nameof(publisher));
            }

            if (string.IsNullOrWhiteSpace(language))
            {
                throw new ArgumentNullException("Language can't be empty.", nameof(language));
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                throw new ArgumentNullException("Category can't be empty.", nameof(category));
            }

            if (releaseDate.Ticks == 0)
            {
                throw new ArgumentNullException("Release Date can't be 0.", nameof(releaseDate));
            }

            if (pages == 0)
            {
                throw new ArgumentNullException("Pages amount can't be 0.", nameof(pages));
            }
            
            if (weight == 0)
            {
                throw new ArgumentNullException("Weight can't be 0.", nameof(weight));
            }

            if (dimensions.Height == 0 || dimensions.Length == 0 || dimensions.Width == 0)
            {
                throw new ArgumentNullException("Dimensions can't be null.", nameof(dimensions));
            }
            
            #endregion

            Title = title;
            ISBN = isbn;
            Amount = amount;
            PicPath = picPath;
            Description = description;
            Author = author;
            Publisher = publisher;
            Language = language;
            Category = category;
            ReleaseDate = releaseDate;
            Pages = pages;
            Price = price;
            Rating = rating;
            Weight = weight;
            Dimensions = dimensions;
            Available = available;
        }

        public Book()
        {

        }

        public void ChangeAvailability()
        {
            Available = !Available;
        }
    }
}
