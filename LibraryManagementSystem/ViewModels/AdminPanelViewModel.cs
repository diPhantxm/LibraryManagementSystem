using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewModels
{
    public class AdminPanelViewModel : BaseViewModel
    {
        public IEnumerable<string> TablesNames { get; set; }
        public DbSet DataTable { get; set; }

        private ObservableCollection<Reader> _readers;
        private ObservableCollection<Book> _books;
        private ObservableCollection<Rent> _rents;

        private bool _readersVisibility;
        private bool _booksVisibility;
        private bool _rentsVisibility;

        public ObservableCollection<Reader> Readers
        {
            get
            {
                return _readers;
            }
            set
            {
                _readers = value;
                NotifyOfPropertyChange(() => Readers);
            }
        }
        public ObservableCollection<Book> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
                NotifyOfPropertyChange(() => Books);
            }
        }
        public ObservableCollection<Rent> Rents
        {
            get
            {
                return _rents;
            }
            set
            {
                _rents = value;
                NotifyOfPropertyChange(() => Rents);
            }
        }

        public bool ReadersVisibility
        {
            get { return _readersVisibility; }
            set
            {
                _readersVisibility = value;
                NotifyOfPropertyChange(() => ReadersVisibility);
            }
        }
        public bool BooksVisibility
        {
            get { return _booksVisibility; }
            set
            {
                _booksVisibility = value;
                NotifyOfPropertyChange(() => BooksVisibility);
            }
        }
        public bool RentsVisibility
        {
            get { return _rentsVisibility; }
            set
            {
                _rentsVisibility = value;
                NotifyOfPropertyChange(() => RentsVisibility);
            }
        }

        public AdminPanelViewModel(MainViewModel mainView)
        {
            MainView = mainView;

            TablesNames = new string[] { "Users", "Books", "Rents" }.ToList();
            ReadersVisibility = false;
            BooksVisibility = false;
            RentsVisibility = false;
        }

        public async Task ChangeTable(string table)
        {
            await Task.Run(async () =>
            {
                switch (table)
                {
                    case "Users":
                        HideAllTables();
                        Readers = new ObservableCollection<Reader>(await Managers.UnitOfWork.Users.GetAllAsync());
                        ReadersVisibility = true;
                        break;
                    case "Books":
                        HideAllTables();
                        Books = new ObservableCollection<Book>(await Managers.UnitOfWork.Books.GetAllAsync());
                        BooksVisibility = true;
                        break;
                    case "Rents":
                        HideAllTables();
                        Rents = new ObservableCollection<Rent>(await Managers.UnitOfWork.Rents.GetAllAsync());
                        RentsVisibility = true;
                        break;
                    default:
                        break;
                }
            });
            
        }

        private void HideAllTables()
        {
            ReadersVisibility = false;
            BooksVisibility = false;
            RentsVisibility = false;
        }

        public void Add()
        {

        }

        public void Remove()
        {
            OpenIdBoxDialog();
        }

        public void Update()
        {
            OpenIdBoxDialog();
        }

        private void OpenIdBoxDialog()
        {
            
        }
    }
}
