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
    public class UpdateDialogViewModel : Screen
    {
        // Visibility Fields
        private bool _userInfoVisibility;
        private bool _bookInfoVisibility;
        private bool _rentInfoVisibility;

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
        private double _price;
        private double _weight;
        private float _length;
        private float _width;
        private float _height;
        private string _description;
        private string _author;
        private double _rating;
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
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public double Weight
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
        public double Rating
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
        private DateTime _expireDate;

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
        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set
            {
                _expireDate = value;
                NotifyOfPropertyChange(() => ExpireDate);
            }
        }

        // Objects to Update
        private Reader ReaderToUpdate;
        private Book BookToUpdate;
        private Rent RentToUpdate;


        public UpdateDialogViewModel(object objectToUpdate, bool userInfo = false, bool bookInfo = false, bool rentInfo = false)
        {
            if (!userInfo && !bookInfo && !rentInfo)
            {
                throw new ArgumentException("You must pass one true boolean.");
            }

            if (userInfo && bookInfo || userInfo && rentInfo || bookInfo && rentInfo)
            {
                throw new ArgumentException("You cannot pass two or more true boolean.");
            }

            if (objectToUpdate is Reader)
            {
                ReaderToUpdate = objectToUpdate as Reader;
                SetUserInterface();
            }
            else if (objectToUpdate is Book)
            {
                BookToUpdate = objectToUpdate as Book;
                SetBookInterface();
            }
            else if (objectToUpdate is Rent)
            {
                RentToUpdate = objectToUpdate as Rent;
                SetRentInterface();
            }
            else
            {
                throw new ArgumentException("Object-To-Update must be type of Reader, Book or Rent", nameof(objectToUpdate));
            }
                

            UserInfoVisibility = userInfo;
            BookInfoVisibility = bookInfo;
            RentInfoVisibility = rentInfo;
        }

        public void Close()
        {
            TryClose(false);
        }

        public async Task Update()
        {
            if (UserInfoVisibility)
            {
                CheckUserFields();
                SetUserNewProps();
                await Managers.UnitOfWork.Users.UpdateAsync(ReaderToUpdate);
            }
            if (BookInfoVisibility)
            {
                CheckBookFields();
                SetBookNewProps();
                await Managers.UnitOfWork.Books.UpdateAsync(BookToUpdate);
            }
            if (RentInfoVisibility)
            {
                CheckRentFields();
                SetRentNewProps();
                await Managers.UnitOfWork.Rents.UpdateAsync(RentToUpdate);
            }

            TryClose(true);
        }

        private void SetUserInterface()
        {
            Login = ReaderToUpdate.Login;
            FirstName = ReaderToUpdate.FirstName;
            LastName = ReaderToUpdate.LastName;
            Password = ReaderToUpdate.Password;
            PhoneNumber = ReaderToUpdate.PhoneNumber;
        }
        private void CheckUserFields()
        {
            if (String.IsNullOrWhiteSpace(Login))
            {
                throw new ArgumentNullException("Login cannot be emtpy.", nameof(Login));
            }
            if (String.IsNullOrWhiteSpace(Password))
            {
                throw new ArgumentNullException("Password cannot be emtpy.", nameof(Password));
            }
            if (String.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentNullException("First name cannot be emtpy.", nameof(FirstName));
            }
            if (String.IsNullOrWhiteSpace(LastName))
            {
                throw new ArgumentNullException("Last Name cannot be emtpy.", nameof(LastName));
            }
            if (String.IsNullOrWhiteSpace(PhoneNumber))
            {
                throw new ArgumentNullException("Phone Number cannot be emtpy.", nameof(PhoneNumber));
            }
        }
        private void SetUserNewProps()
        {
            ReaderToUpdate.Login = Login;
            ReaderToUpdate.FirstName = FirstName;
            ReaderToUpdate.LastName = LastName;
            ReaderToUpdate.Password = Password;
            ReaderToUpdate.PhoneNumber = PhoneNumber;
        }

        private void SetBookInterface()
        {
            BookName = BookToUpdate.Title;
            Description = BookToUpdate.Description;
            Author = BookToUpdate.Author;
            BookISBN = BookToUpdate.ISBN;
            Rating = BookToUpdate.Rating;
            Price = BookToUpdate.Price;
            Weight = BookToUpdate.Weight;
            Height = BookToUpdate.Dimensions.Height;
            Width = BookToUpdate.Dimensions.Width;
            Length = BookToUpdate.Dimensions.Length;
            Publisher = BookToUpdate.Publisher;
            Pages = BookToUpdate.Pages;
            Amount = BookToUpdate.Amount;
            ReleaseDate = BookToUpdate.ReleaseDate;
            Category = BookToUpdate.Category;
        }
        private void CheckBookFields()
        {
            if (String.IsNullOrWhiteSpace(BookName))
            {
                throw new ArgumentNullException("Book Name cannot be empty.", nameof(BookName));
            }
            if (String.IsNullOrWhiteSpace(BookISBN))
            {
                throw new ArgumentNullException("Book ISBN cannot be empty.", nameof(BookISBN));
            }
            if (String.IsNullOrWhiteSpace(Author))
            {
                throw new ArgumentNullException("Author cannot be empty.", nameof(Author));
            }
            if (String.IsNullOrWhiteSpace(Publisher))
            {
                throw new ArgumentNullException("Publisher cannot be empty.", nameof(Publisher));
            }
            if (String.IsNullOrWhiteSpace(Language))
            {
                throw new ArgumentNullException("Language cannot be empty.", nameof(Language));
            }
            if (String.IsNullOrWhiteSpace(Category))
            {
                throw new ArgumentNullException("Category cannot be empty.", nameof(Category));
            }
            if (Pages <= 0)
            {
                throw new ArgumentOutOfRangeException("Pages cannot be less or equal 0.", nameof(Pages));
            }
            if (Amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be less than 0.", nameof(Amount));
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException("Price cannot be less than 0.", nameof(Price));
            }
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight cannot be less or equal 0.", nameof(Weight));
            }
            if (Length <= 0)
            {
                throw new ArgumentOutOfRangeException("Length cannot be less or equal 0.", nameof(Length));
            }
            if (Width <= 0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be less or equal 0.", nameof(Width));
            }
            if (Height <= 0)
            {
                throw new ArgumentOutOfRangeException("Height cannot be less or equal 0.", nameof(Height));
            }
            if (Rating < 0)
            {
                throw new ArgumentOutOfRangeException("Rating cannot be negative.", nameof(Rating));
            }
        }
        private void SetBookNewProps()
        {
            BookToUpdate.Title = BookName;
            BookToUpdate.ISBN = BookISBN;
            BookToUpdate.Author = Author;
            BookToUpdate.Publisher = Publisher;
            BookToUpdate.Category = Category;
            BookToUpdate.Language = Language;
            BookToUpdate.Pages = Pages;
            BookToUpdate.Price = Price;
            BookToUpdate.Rating = Rating;
            BookToUpdate.Weight = Weight;
            BookToUpdate.Description = Description;
            BookToUpdate.Amount = Amount;
            BookToUpdate.ReleaseDate = ReleaseDate;
            BookToUpdate.Dimensions = new BookDimensions(Length, Width, Height);
        }

        private void SetRentInterface()
        {
            User_Id = RentToUpdate.Reader_Id;
            Book_Id = RentToUpdate.Book_Id;
            ExpireDate = RentToUpdate.ExpireDate;
        }
        private void CheckRentFields()
        {
            if (User_Id == 0)
            {
                throw new ArgumentNullException("User Id cannot be 0.", nameof(User_Id));
            }
            if (Book_Id == 0)
            {
                throw new ArgumentNullException("Book Id cannot be 0.", nameof(Book_Id));
            }
            if (ExpireDate < DateTime.Now)
            {
                throw new ArgumentNullException("Expire date cannot be before now", nameof(ExpireDate));
            }
        }
        private void SetRentNewProps()
        {
            RentToUpdate.Book_Id = Book_Id;
            RentToUpdate.Book = Managers.UnitOfWork.Books.FindByCondition(b => b.Id == Book_Id).Single();
            RentToUpdate.Reader_Id = User_Id;
            RentToUpdate.Reader = Managers.UnitOfWork.Users.FindByCondition(u => u.Id == User_Id).Single();
            RentToUpdate.ExpireDate = ExpireDate;
        }
    }
}
