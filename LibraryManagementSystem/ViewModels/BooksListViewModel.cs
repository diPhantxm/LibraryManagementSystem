using Caliburn.Micro;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManagementSystem.ViewModels
{
    public class BooksListViewModel : BaseViewModel
    {
        private BindableCollection<Book> _books;
        public BindableCollection<Book> Books
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



        public BooksListViewModel(MainViewModel mainView)
        {
            MainView = mainView;
            LoadBooks();
        }

        private async void LoadBooks()
        {
            Books = new BindableCollection<Book>((await Managers.UnitOfWork.Books.GetAllAsync()).ToList());
        }

        public void OpenBook(StackPanel sender, MouseButtonEventArgs args)
        {
            var book = sender.DataContext as Book;
            SwitchView(new BookViewModel(MainView, book));
        }


    }
}
