using Caliburn.Micro;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewModels
{
    public class AddDialogViewModel : Screen
    {
        // Visibility Fields
        private bool _userInfoVisibility = false;
        private bool _bookInfoVisibility = false;
        private bool _rentInfoVisibility = false;

        public bool UserInfoVisibility
        {
            get { return _userInfoVisibility; }
            set
            {
                _userInfoVisibility = value;
                NotifyOfPropertyChange(() => UserInfoVisibility);
            }
        }
        public bool BookInfoVisibility
        {
            get { return _bookInfoVisibility; }
            set
            {
                _bookInfoVisibility = value;
                NotifyOfPropertyChange(() => BookInfoVisibility);
            }
        }
        public bool RentInfoVisibility
        {
            get { return _rentInfoVisibility; }
            set
            {
                _rentInfoVisibility = value;
                NotifyOfPropertyChange(() => RentInfoVisibility);
            }
        }

        // Fields for a new User
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }

        // Fields for a new Book
        private string _bookName;
        private string _bookISBN;
        private string _publisher;
        private string _language;
        private string _category;
        private short _pages;
        private int _amount;
        private float _price;
        private float _weight;
        private float _length;
        private float _width;
        private float _height;
        private string _description;
        private string _author;
        private float _rating;
        private DateTime _releaseDate;

        public string BookName
        {
            get { return _bookName; }
            set
            {
                _bookName = value;
                NotifyOfPropertyChange(() => BookName);
            }
        }
        public string BookISBN
        {
            get { return _bookISBN; }
            set
            {
                _bookISBN = value;
                NotifyOfPropertyChange(() => BookISBN);
            }
        }
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = value;
                NotifyOfPropertyChange(() => Publisher);
            }
        }
        public string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                NotifyOfPropertyChange(() => Language);
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyOfPropertyChange(() => Category);
            }
        }
        public short Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                NotifyOfPropertyChange(() => Pages);
            }
        }
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                NotifyOfPropertyChange(() => Amount);
            }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public float Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                NotifyOfPropertyChange(() => Weight);
            }
        }
        public float Length
        {
            get { return _length; }
            set
            {
                _length = value;
                NotifyOfPropertyChange(() => Length);
            }
        }
        public float Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }
        public float Height
        {
            get { return _height; }
            set
            {
                _height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                NotifyOfPropertyChange(() => Author);
            }
        }
        public float Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                NotifyOfPropertyChange(() => Rating);
            }
        }
        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
                NotifyOfPropertyChange(() => ReleaseDate);
            }
        }

        // Fields for a new Rent
        private int _user_Id;
        private int _book_Id;

        public int User_Id
        {
            get { return _user_Id; }
            set
            {
                _user_Id = value;
                NotifyOfPropertyChange(() => User_Id);
            }
        }
        public int Book_Id
        {
            get { return _book_Id; }
            set
            {
                _book_Id = value;
                NotifyOfPropertyChange(() => Book_Id);
            }
        }

        // New Objects
        public Reader NewReader { get; private set; }
        public Book NewBook { get; private set; }
        public Rent NewRent { get; private set; }


        public AddDialogViewModel(bool userInfo = false, bool bookInfo = false, bool rentInfo = false)
        {
            if (!userInfo && !bookInfo && !rentInfo)
            {
                throw new ArgumentException("You must pass one true boolean.");
            }

            if (userInfo && bookInfo || userInfo && rentInfo || bookInfo && rentInfo)
            {
                throw new ArgumentException("You cannot pass two or more true boolean.");
            }

            UserInfoVisibility = userInfo;
            BookInfoVisibility = bookInfo;
            RentInfoVisibility = rentInfo;
        }

        public void Close()
        {
            TryClose(false);
        }

        public async Task Add()
        {
            if (UserInfoVisibility)
            {
                await Managers.UserManager.RegisterAsync(Login, Password, FirstName, LastName, PhoneNumber);
            }
            if (BookInfoVisibility)
            {
                var dimensions = new BookDimensions(Length, Width, Height);
                var book = new Book(BookName, BookISBN, Amount, BookISBN, Description, Author, Publisher, Language, Category, ReleaseDate, Pages, Price, Rating, Weight, dimensions, true);
                await Managers.UnitOfWork.Books.AddAsync(book);
            }
            if (RentInfoVisibility)
            {
                var readers = Managers.UnitOfWork.Users.FindByCondition(u => u.Id == User_Id);
                if (readers.Count() == 0)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                var reader = readers.Single();
                var books = Managers.UnitOfWork.Books.FindByCondition(b => b.Id == Book_Id);
                if (books.Count() == 0)
                {
                    throw new KeyNotFoundException("Book not found.");
                }

                var book = books.Single();

                var rent = new Rent(reader, book, DateTime.Now.AddDays(7));
                await Managers.UnitOfWork.Rents.AddAsync(rent);
            }

            TryClose(true);
        }
    }
}
