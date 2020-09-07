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
        private bool _isAdmin = false;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                NotifyOfPropertyChange(() => IsAdmin);
            }
        }


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
            Managers.SecutiryManager = new Core.Models.SecurityManager(Managers.UnitOfWork);
            Managers.RentManager = new Core.Models.RentManager(Managers.UnitOfWork);
        }

        public void OpenAdminPanel()
        {
            CurrentView = new AdminPanelViewModel(this);
            ActivateItem(CurrentView);
        }
    }
}
