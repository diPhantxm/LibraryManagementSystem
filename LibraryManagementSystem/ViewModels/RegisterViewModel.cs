using Caliburn.Micro;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LibraryManagementSystem.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private bool Processing = false;

        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        private Brush _loginBrush = Brushes.Black;
        private Brush _firstNameBrush = Brushes.Black;
        private Brush _lastNameBrush = Brushes.Black;
        private Brush _passwordBrush = Brushes.Black;
        private Brush _phoneNumberBrush = Brushes.Black;

        public Brush LoginBrush
        {
            get { return _loginBrush; }
            set
            {
                _loginBrush = value;
                NotifyOfPropertyChange(() => LoginBrush);
            }
        }
        public Brush FirstNameBrush
        {
            get { return _firstNameBrush; }
            set
            {
                _firstNameBrush = value;
                NotifyOfPropertyChange(() => FirstNameBrush);
            }
        }
        public Brush LastNameBrush
        {
            get { return _lastNameBrush; }
            set
            {
                _lastNameBrush = value;
                NotifyOfPropertyChange(() => LastNameBrush);
            }
        }
        public Brush PasswordBrush
        {
            get { return _passwordBrush; }
            set
            {
                _passwordBrush = value;
                NotifyOfPropertyChange(() => PasswordBrush);
            }
        }
        public Brush PhoneNumberBrush
        {
            get { return _phoneNumberBrush; }
            set
            {
                _phoneNumberBrush = value;
                NotifyOfPropertyChange(() => PhoneNumberBrush);
            }
        }

        public RegisterViewModel(MainViewModel mainView)
        {
            MainView = mainView;
        }

        public async Task Register()
        {
            try
            {
                if (Processing) return;
                else Processing = true;

                var error = false;

                #region Input parameters Check

                if (String.IsNullOrWhiteSpace(Login))
                {
                    LoginBrush = Brushes.Red;
                    error = true;
                }

                if (String.IsNullOrWhiteSpace(Password))
                {
                    PasswordBrush = Brushes.Red;
                    error = true;
                }

                if (String.IsNullOrWhiteSpace(FirstName))
                {
                    FirstNameBrush = Brushes.Red;
                    error = true;
                }

                if (String.IsNullOrWhiteSpace(LastName))
                {
                    LastNameBrush = Brushes.Red;
                    error = true;
                }

                if (String.IsNullOrWhiteSpace(PhoneNumber))
                {
                    PhoneNumberBrush = Brushes.Red;
                    error = true;
                }

                var loginMatches = (List<Reader>)(await Managers.UnitOfWork.Users.FindByConditionAsync(r => r.Login == Login));
                var phoneNumberMatches = (List<Reader>)(await Managers.UnitOfWork.Users.FindByConditionAsync(r => r.PhoneNumber == PhoneNumber));

                if (loginMatches != null && loginMatches.Count != 0)
                {
                    LoginBrush = Brushes.Red;
                    error = true;
                }

                if (phoneNumberMatches != null && phoneNumberMatches.Count != 0)
                {
                    PhoneNumberBrush = Brushes.Red;
                    error = true;
                }

                if (error)
                {
                    Processing = false;
                    return;
                }

                #endregion

                var user = await Managers.UserManager.RegisterAsync(Login, Password, FirstName, LastName, PhoneNumber);

                if (user != null)
                {
                    SwitchView(new BooksListViewModel(MainView));
                    MainView.IsAdmin = user.Role.Name == "Admin" ? true : false;
                }
            }
            catch (Exception)
            {
                Processing = false;
            }
        }

        public void SignIn()
        {
            SwitchView(new LoginViewModel(MainView));
        }
    }
}
