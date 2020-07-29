using LibraryManagementSystem.DAL.Models;
using System;
using System.Globalization;

namespace LibraryManagementSystem.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        protected Book Book;
        public BookViewModel(MainViewModel mainView, Book book)
        {
            MainView = mainView;
            Book = book;

            Title = book.Title;
            Description = book.Description;
            Author = book.Author;
            Publisher = book.Publisher;
            Language = book.Language;
            Category = book.Category;
            Pages = book.Pages.ToString();
            Price = book.Price.ToString(CultureInfo.CurrentCulture);
            Rating = book.Rating.ToString();
            Weight = book.Weight.ToString(CultureInfo.CurrentCulture);
            Dimensions = book.Dimensions.ToString();
            ReleaseDate = book.ReleaseDate.ToShortDateString();
        }

        private string _title;
        private string _description;
        private string _author;
        private string _publisher;
        private string _language;
        private string _category;
        private string _pages;
        private string _price;
        private string _rating;
        private string _weight;
        private string _dimensions;
        private string _releaseDate;


        public string Title
        {
            get { return _title; }
            set
            {
                _title = String.Format($"Title: {value}");
                NotifyOfPropertyChange(() => Title);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = String.Format($"Description: {value}");
                NotifyOfPropertyChange(() => Description);
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = String.Format($"Author: {value}");
                NotifyOfPropertyChange(() => Author);
            }
        }
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = String.Format($"Publisher: {value}");
                NotifyOfPropertyChange(() => Publisher);
            }
        }
        public string Language
        {
            get { return _language; }
            set
            {
                _language = String.Format($"Language: {value}");
                NotifyOfPropertyChange(() => Language);
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = String.Format($"Category: {value}");
                NotifyOfPropertyChange(() => Category);
            }
        }
        public string Pages
        {
            get { return _pages; }
            set
            {
                _pages = String.Format($"Pages: {value}");
                NotifyOfPropertyChange(() => Pages);
            }
        }
        public string Price
        {
            get { return _price; }
            set
            {
                _price = String.Format($"Price: {value}");
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Rating
        {
            get { return _rating; }
            set
            {
                _rating = String.Format($"Rating: {value}");
                NotifyOfPropertyChange(() => Rating);
            }
        }
        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = String.Format($"Weight: {value}");
                NotifyOfPropertyChange(() => Weight);
            }
        }
        public string Dimensions
        {
            get { return _dimensions; }
            set
            {
                _dimensions = String.Format($"Dimensions: {value}");
                NotifyOfPropertyChange(() => Dimensions);
            }
        }
        public string ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = String.Format($"Release Date: {value}");
                NotifyOfPropertyChange(() => ReleaseDate);
            }
        }


        public void Back()
        {
            SwitchView(new BooksListViewModel(MainView));
        }

    }
}
