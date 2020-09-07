using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace LibraryManagementSystem.ViewModels
{
    public class AdminPanelViewModel : BaseViewModel
    {
        private readonly WindowManager WindowManager = new WindowManager();

        public IEnumerable<string> TablesNames { get; set; }

        private ObservableCollection<Reader> _readers;
        private ObservableCollection<Book> _books;
        private ObservableCollection<Rent> _rents;

        private bool _readersVisibility;
        private bool _booksVisibility;
        private bool _rentsVisibility;
        private string _selectedTable;

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
        public string SelectedTable
        {
            get
            {
                return _selectedTable;
            }
            set
            {
                _selectedTable = value;
                NotifyOfPropertyChange(() => SelectedTable);
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
                SelectedTable = table;

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

        public async Task Add()
        {
            switch (SelectedTable)
            {
                case "Users":
                    var addUserDialog = new AddDialogViewModel(userInfo: true);
                    var userSuccess = WindowManager.ShowDialog(addUserDialog);

                    if (userSuccess == true)
                    {
                        Readers = new ObservableCollection<Reader>(await Managers.UnitOfWork.Users.GetAllAsync());
                    }
                    break;

                case "Books":
                    var addBookDialog = new AddDialogViewModel(bookInfo: true);
                    var bookSuccess = WindowManager.ShowDialog(addBookDialog);

                    if (bookSuccess == true)
                    {
                        Books = new ObservableCollection<Book>(await Managers.UnitOfWork.Books.GetAllAsync());
                    }
                    break;

                case "Rents":
                    var addRentDialog = new AddDialogViewModel(rentInfo: true);
                    var rentSuccess = WindowManager.ShowDialog(addRentDialog);

                    if (rentSuccess == true)
                    {
                        Rents = new ObservableCollection<Rent>(await Managers.UnitOfWork.Rents.GetAllAsync());
                    }
                    break;

                default:
                    break;
            }
        }

        public async Task Remove()
        {
            switch (SelectedTable)
            {
                case "Users":
                    var removeUserDialog = new RemoveDialogViewModel(userInfo: true);
                    var userSuccess = WindowManager.ShowDialog(removeUserDialog);

                    if (userSuccess == false)
                    {
                        return;
                    }

                    if (removeUserDialog.Id != null)
                    {
                        await Managers.UserManager.DeleteAsync((int)removeUserDialog.Id);
                    }
                    else if (removeUserDialog.Login != String.Empty)
                    {
                        await Managers.UserManager.DeleteAsync(removeUserDialog.Login);
                    }

                    Readers = new ObservableCollection<Reader>(await Managers.UnitOfWork.Users.GetAllAsync());
                    break;

                case "Books":
                    var RemoveBookDialogViewModel = new RemoveDialogViewModel(bookInfo: true);
                    var bookSuccess = WindowManager.ShowDialog(RemoveBookDialogViewModel);

                    if (bookSuccess == false)
                    {
                        return;
                    }

                    if (RemoveBookDialogViewModel.Id != null)
                    {
                        var bookId = RemoveBookDialogViewModel.Id;
                        await Managers.BookManager.DeleteByIdAsync((int)bookId);
                    }
                    else if (RemoveBookDialogViewModel.ISBN != String.Empty)
                    {
                        var bookISBN = RemoveBookDialogViewModel.ISBN;
                        await Managers.BookManager.DeleteByISBNAsync(bookISBN);
                    }
                    else if (RemoveBookDialogViewModel.BookName != String.Empty)
                    {
                        var bookName = RemoveBookDialogViewModel.BookName;
                        await Managers.BookManager.DeleteByTitleAsync(bookName);
                    }

                    Books = new ObservableCollection<Book>(await Managers.UnitOfWork.Books.GetAllAsync());
                    break;

                case "Rents":
                    var RemoveRentDialogViewModel = new RemoveDialogViewModel(rentInfo: true);
                    var rentSuccess = WindowManager.ShowDialog(RemoveRentDialogViewModel);

                    if (rentSuccess == true)
                    {
                        return;
                    }

                    if (RemoveRentDialogViewModel.Id != null)
                    {
                        var user_id = (int)RemoveRentDialogViewModel.Id;

                        if (RemoveRentDialogViewModel.Book_Id != null)
                        {
                            var book_id = (int)RemoveRentDialogViewModel.Book_Id;
                            await Managers.RentManager.DeleteRentAsync(user_id, book_id);
                        }
                        if (RemoveRentDialogViewModel.ISBN != String.Empty)
                        {
                            var bookISBN = RemoveRentDialogViewModel.ISBN;
                            await Managers.RentManager.DeleteRentByISBNAsync(user_id, bookISBN);
                        }
                        if (RemoveRentDialogViewModel.BookName != String.Empty)
                        {
                            var bookName = RemoveRentDialogViewModel.BookName;
                            await Managers.RentManager.DeleteRentByBookTitleAsync(user_id, bookName);
                        }
                    }

                    if (RemoveRentDialogViewModel.Login != String.Empty)
                    {
                        var user_login = RemoveRentDialogViewModel.Login;

                        if (RemoveRentDialogViewModel.Book_Id != null)
                        {
                            var book_id = (int)RemoveRentDialogViewModel.Book_Id;
                            await Managers.RentManager.DeleteRentAsync(user_login, book_id);
                        }
                        if (RemoveRentDialogViewModel.ISBN != String.Empty)
                        {
                            var bookISBN = RemoveRentDialogViewModel.ISBN;
                            await Managers.RentManager.DeleteRentByISBNAsync(user_login, bookISBN);
                        }
                        if (RemoveRentDialogViewModel.BookName != String.Empty)
                        {
                            var bookName = RemoveRentDialogViewModel.BookName;
                            await Managers.RentManager.DeleteRentByBookTitleAsync(user_login, bookName);
                        }
                    }

                    Rents = new ObservableCollection<Rent>(await Managers.UnitOfWork.Rents.GetAllAsync());
                    break;

                default:
                    break;
            }
        }

        public async Task Update()
        {
            switch (SelectedTable)
            {
                case "Users":
                    var userIdDialog = new IdToUpdateDialogViewModel();
                    var userIdSuccess = WindowManager.ShowDialog(userIdDialog);
                    if (userIdSuccess == false)
                    {
                        return;
                    }

                    var userToUpdate = Managers.UnitOfWork.Users.FindByCondition(u => u.Id == userIdDialog.Id).Single();
                    var updateUserDialog = new UpdateDialogViewModel(userToUpdate, userInfo: true);
                    WindowManager.ShowDialog(updateUserDialog);
                    Readers = new ObservableCollection<Reader>(await Managers.UnitOfWork.Users.GetAllAsync());
                    break;

                case "Books":
                    var bookIdDialog = new IdToUpdateDialogViewModel();
                    var bookIdSuccess = WindowManager.ShowDialog(bookIdDialog);
                    if (bookIdSuccess == false)
                    {
                        return;
                    }

                    var bookToUpdate = Managers.UnitOfWork.Books.FindByCondition(b => b.Id == bookIdDialog.Id).Single();
                    var updateBookDialog = new UpdateDialogViewModel(bookToUpdate, bookInfo: true);
                    WindowManager.ShowDialog(updateBookDialog);
                    Books = new ObservableCollection<Book>(await Managers.UnitOfWork.Books.GetAllAsync());
                    break;

                case "Rents":
                    var rentIdDialog = new IdToUpdateDialogViewModel();
                    var rentIdSuccess = WindowManager.ShowDialog(rentIdDialog);
                    if (rentIdSuccess == false)
                    {
                        return;
                    }

                    var rentToUpdate = Managers.UnitOfWork.Rents.FindByCondition(r => r.Reader_Id == rentIdDialog.Id && r.Book_Id == rentIdDialog.Book_Id);
                    var updateRentDialog = new UpdateDialogViewModel(rentToUpdate, rentInfo: true);
                    WindowManager.ShowDialog(updateRentDialog);
                    Rents = new ObservableCollection<Rent>(await Managers.UnitOfWork.Rents.GetAllAsync());
                    break;

                default:
                    break;
            }
        }
    }
}
