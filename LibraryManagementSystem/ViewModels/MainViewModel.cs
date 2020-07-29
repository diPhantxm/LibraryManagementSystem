using Caliburn.Micro;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.ViewModels
{
    public class MainViewModel : Conductor<Screen>.Collection.OneActive
    {
        private Screen _currentView;

        public Screen CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                NotifyOfPropertyChange(() => CurrentView);
            }
        }


        public MainViewModel()
        {
            CurrentView = new LoginViewModel(this);
            ActivateItem(CurrentView);
       
            Managers.UnitOfWork = new DAL.UnitOfWork(new DAL.LibraryDbContext());
            Managers.UserManager = new Core.Models.UserManager(Managers.UnitOfWork);
            Managers.BookManager = new Core.Models.BookManager(Managers.UnitOfWork);
        }
    }
}
